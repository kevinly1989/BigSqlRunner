namespace BigRunner.WinFormsApp
{
	using System;
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Data;
	using System.Data.SqlClient;
	using System.Diagnostics;
	using System.Drawing;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Windows.Forms;

	/// <summary>
	/// This indicates that it is a start point of the program
	/// </summary>
	public partial class Main : Form
	{
		/// <summary>
		/// Initialize BigRunner.WinFormsApp.Main() constructor
		/// </summary>
		public Main()
		{
			/**********************************************
				Initialize these necessary components
			**********************************************/
			InitializeComponent();

			/**********************************************
				Initialize some necessary configurations of
				worker
			**********************************************/
			bwRunBigSqlScript.WorkerSupportsCancellation = true;
		}

		#region Events
		/// <summary>
		/// This indicates that this event occurred when user clicks these buttons which have the value called "..."
		/// </summary>
		/// <param name="sender">sender</param>
		/// <param name="e">e</param>
		private void btnChooseFile_Click(object sender, EventArgs e)
		{
			var button = sender as Button;
			switch (button.Name)
			{
				/**********************************************
					This case will be adopted for the first 
					"Choose File"
				**********************************************/
				case "btnChooseFile":
					ofdDialog1.ShowDialog();
					break;

				/**********************************************
					This case will be adopted for the second 
					"Choose File"
				**********************************************/
				case "btnChooseFile2":
					ofdDialog2.ShowDialog();
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// This event is raised up when the users choose file in Open File Dialog 1
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">CancelEventArgs e</param>
		private void ofdDialog1_FileOk(object sender, CancelEventArgs e)
		{
			/**********************************************
				We only accept the selected and existed files
			**********************************************/
			if (!e.Cancel && ofdDialog1.CheckFileExists)
			{
				txtHugeSqlScript.Text = ofdDialog1.FileName.Trim();
			}
		}

		/// <summary>
		/// This event is raised up when the users choose file in Open File Dialog 2
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">CancelEventArgs e</param>
		private void ofdDialog2_FileOk(object sender, CancelEventArgs e)
		{
			/**********************************************
				We only accept the selected and existed files
			**********************************************/
			if (!e.Cancel && ofdDialog2.CheckFileExists)
			{
				txtLogSqlScript.Text = ofdDialog2.FileName.Trim();
			}
		}

		/// <summary>
		/// This event is raised up when the user clicks Run button
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="args">EventArgs args</param>
		private void btnRun_Click(object sender, EventArgs args)
		{
			/**********************************************
				If the form is valid and background worker
				isn't busy, we will run the script
				file asynchronously
			**********************************************/
			if (IsValidForm())
			{
				if (bwRunBigSqlScript.IsBusy != true)
				{
					bwRunBigSqlScript.RunWorkerAsync();
				}
			}
		}

		/// <summary>
		/// This event is raised up when the user clicks More Connection String link
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">LinkLabelLinkClickedEventArgs e</param>
		private void lbMoreConnectionString_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			/**********************************************
				Navigate to the web site link to provide
				more information about connection strings
			**********************************************/
			lbMoreConnectionString.LinkVisited = true;
			Process.Start("http://connectionstrings.com/");
		}

		/// <summary>
		/// This event is raised up when the user checks into "Enable log to the file"
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">EventArgs e</param>
		private void cbEnableLog_CheckedChanged(object sender, EventArgs e)
		{
			/**********************************************
				Enable/Disable the Log Sql Script Textbox
				and the Choose File 2
			**********************************************/
			txtLogSqlScript.Enabled = btnChooseFile2.Enabled = cbEnableLog.Checked;
		}

		/// <summary>
		/// This event is raised up when the user cancels the running process
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">EventArgs e</param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			/**********************************************
				Cancel the asynchronous operation if current
				worker supports cancellation
			**********************************************/
			if (bwRunBigSqlScript.WorkerSupportsCancellation == true)
			{
				bwRunBigSqlScript.CancelAsync();
			}
		}

		/// <summary>
		/// This event is raised up when the user runs asynchronously
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">DoWorkEventArgs e</param>
		private void bwRunBigSqlScript_DoWork(object sender, DoWorkEventArgs e)
		{
			/**********************************************
				Measure time of running sql script
			**********************************************/
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			/**********************************************
				Initialize as start
			**********************************************/
			var connectionString = txtConnectionString.Text.Trim();
			var enabledLogToFile = false;
			TextWriter logger = null;
			rtbStatus.Text = String.Empty;
			ShowInProgress(false);

			try
			{
				/**********************************************
					Open the connection to the server database 
					if okay
				**********************************************/
				var connection = new SqlConnection(connectionString);
				connection.Open();

				/**********************************************
					Only accept the opening status to database
				**********************************************/
				if (connection.State == ConnectionState.Open)
				{
					/**********************************************
						Initialize the file name path
					**********************************************/
					var fileNamePath = txtHugeSqlScript.Text.Trim();

					/**********************************************
						Enable to write log message to the file
					**********************************************/
					enabledLogToFile = cbEnableLog.Checked;
					var logFileNamePath = String.Empty;
					if (enabledLogToFile)
					{
						logger = GetLogFile(txtLogSqlScript.Text.Trim());
						enabledLogToFile = enabledLogToFile && (logger != null);
						if (enabledLogToFile)
						{
							logger.WriteLine(String.Format("*************** [{0}]****************", DateTime.Now));
							logger.WriteLine(String.Format("Running {0}...", fileNamePath));
						}
					}

					/**********************************************
						Open new stream reader to the script file
					**********************************************/
					var fileReader = new StreamReader(fileNamePath);

					/**********************************************
						Contain line code sql script and next line
						one
					**********************************************/
					string scriptDataline, nextScriptDataLine;
					scriptDataline = nextScriptDataLine = String.Empty;

					/**********************************************
						Count the number of records added to db
					**********************************************/
					var counter = 0;

					/**********************************************
						Count the number of affected when running
						command sql
					**********************************************/
					var numberOfAffectedRows = 0;

					/**********************************************
						Initialize the Sql Command to run the sql
						script
					**********************************************/
					var sqlCommand = new SqlCommand();

					/**********************************************
						Initialize the message to show to the user
					**********************************************/
					var message = String.Empty;

					/**********************************************
						Specify the first times to run the script
					**********************************************/
					var isFirst = true;

					/**********************************************
						Indicate the running status
					**********************************************/
					rtbStatus.AppendText("Running...\n");

					/**********************************************
						Indicate running the script until EOF
					**********************************************/
					while ((nextScriptDataLine = fileReader.ReadLine()) != null)
					{
						try
						{
							/**********************************************
								If true, we will cancel the running thread
								otherwise will continue running
							**********************************************/
							if (bwRunBigSqlScript.CancellationPending == true)
							{
								/**********************************************
									Release these unnecessary resources when
									cancelled
								**********************************************/
								e.Cancel = true;
								fileReader.Close();
								connection.Close();
								break;
							}
							else
							{
								/**********************************************
									Should combine the current line and the new
									line which was read from file to run
								**********************************************/
								scriptDataline = String.Format("{0} {1}", scriptDataline, nextScriptDataLine);

								/**********************************************
									Should trim the line data to avoid extra
									whitespaces between begin and end string
								**********************************************/
								scriptDataline = scriptDataline != null ? scriptDataline.Trim() : scriptDataline;

								/**********************************************
									Run the script right away when seeing GO
									batch. This batch is always sensitive case
								**********************************************/
								if (scriptDataline.EndsWith("GO"))
								{
									/**********************************************
										Cut off the GO string at the end of the line
										data
									**********************************************/
									scriptDataline = scriptDataline.Substring(0, scriptDataline.Length - 2);

									/**********************************************
										Send the script to the database server to
										run
									**********************************************/
									sqlCommand = new SqlCommand(scriptDataline, connection);
									numberOfAffectedRows = sqlCommand.ExecuteNonQuery();

									/**********************************************
										Reset the line data to blank value
									**********************************************/
									scriptDataline = String.Empty;

									/**********************************************
										If having the number of affected rows is
										greater than zero, we will add it into
										counter
									**********************************************/
									if (numberOfAffectedRows > 0)
									{
										counter += numberOfAffectedRows;
									}

									/**********************************************
										Only accept when the counter is greater
										than zero
									**********************************************/
									if (counter > 0)
									{
										/**********************************************
											If this is the first time, we will append
											message to Rich Text Box to update status,
											otherwise, we will replace the counter value
											into message existed in Rich Text Box
										**********************************************/
										if (isFirst)
										{
											message = String.Format("Added {0} row(s)", counter);
											rtbStatus.AppendText(message);
											isFirst = false;
										}
										else
										{
											message = String.Format("Added {0} row(s)", counter - numberOfAffectedRows);
											if (rtbStatus.Text.Contains(message))
											{
												rtbStatus.Text = rtbStatus.Text.Replace(message, String.Format("Added {0} row(s)", counter));
												message = String.Format("Added {0} row(s)", counter);
											}
										}
									}
								}
							}
						}
						catch (SqlException ex)
						{
							WriteExceptionError(ex, logger, enabledLogToFile);
							scriptDataline = String.Empty;
						}
						catch (Exception ex)
						{
							WriteExceptionError(ex, logger, enabledLogToFile);
							break;
						}
					}

					/**********************************************
						Confirm that the sql script file were
						finished running. If enabling the log, we
						will write the current status to the log
						file
					**********************************************/
					if (enabledLogToFile)
					{
						logger.WriteLine("Completed");
						logger.WriteLine(String.Format("Total {0} rows added to database", counter));
					}
					rtbStatus.AppendText("\nCompleted\n");
					rtbStatus.AppendText(String.Format("Total {0} rows added to database\n", counter));

					/**********************************************
						Release unused resources
					**********************************************/
					fileReader.Close();
					connection.Close();
				}
			}
			catch (Exception ex)
			{
				WriteExceptionError(ex, logger, enabledLogToFile);
			}
			finally
			{
				/**********************************************
					Release unused logger
				**********************************************/
				if (enabledLogToFile && logger != null)
				{
					logger.Close();
				}

				/**********************************************
					Stop watch and write the elapsed time to
					Rich Text Box
				**********************************************/
				stopWatch.Stop();
				var timeSpan = stopWatch.Elapsed;
				var elapsedTime = String.Format("Time elapsed: {0:00}:{1:00}:{2:00}.{3:00}",
					timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds,
					timeSpan.Milliseconds / 10);
				rtbStatus.AppendText(elapsedTime);
			}
		}

		/// <summary>
		/// This event is raised up when the background worker has completed
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">RunWorkerCompletedEventArgs e</param>
		private void bwRunBigSqlScript_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			ShowInProgress(true);
		}

		/// <summary>
		/// This event is raised up when user clicks to copy example connection string
		/// </summary>
		/// <param name="sender">object sender</param>
		/// <param name="e">LinkLabelLinkClickedEventArgs e</param>
		private void lbCopyConnectionString_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Clipboard.SetText(lblExampleConnectionString.Text.Replace("e.g:", String.Empty).Trim());
		}
		#endregion Events

		#region Useful methods
		/// <summary>
		/// Enable to show the status of running the script file
		/// </summary>
		/// <param name="isEnable">bool isEnable</param>
		private void ShowInProgress(bool isEnable)
		{
			/**********************************************
				When running the script file, we will
				disable Run and enable Cancel button,
				otherwise, enable Run and disable Cancel
			**********************************************/
			btnRun.Enabled = isEnable;
			btnCancel.Enabled = !isEnable;

			/**********************************************
				Use async to visible the progress bar
			**********************************************/
			MethodInvoker involker = delegate
			{
				progressBar1.Visible = !isEnable;
			};
			progressBar1.BeginInvoke(involker);
		}

		/// <summary>
		/// Checks the form is valid or not?
		/// </summary>
		/// <returns>Return true if it is valid, otherwise false</returns>
		private bool IsValidForm()
		{
			var builder = new StringBuilder();

			/**********************************************
				Check the Connection String textbox
			**********************************************/
			if (String.IsNullOrEmpty(txtConnectionString.Text.Trim()))
			{
				builder.AppendLine("The connection string field is required");
			}

			/**********************************************
				Check the Sql Script File Path textbox
			**********************************************/
			if (String.IsNullOrEmpty(txtHugeSqlScript.Text.Trim()))
			{
				builder.AppendLine("The big sql file path field is required");
			}
			else
			{
				if (!File.Exists(txtHugeSqlScript.Text.Trim()))
				{
					builder.AppendLine("The big sql file hasn't existed");
				}
			}

			/**********************************************
				Check the Enable Log checkbox
			**********************************************/
			if (cbEnableLog.Checked)
			{
				if (String.IsNullOrEmpty(txtLogSqlScript.Text.Trim()))
				{
					builder.AppendLine("The log file path field is required");
				}
				else
				{
					if (Path.GetExtension(txtLogSqlScript.Text.Trim()).ToLower() != ".txt")
					{
						builder.AppendLine("The log file must contain the extension '.txt'");
					}
				}
			}

			/**********************************************
				if the length of data of builder identifier
				is greater than 0, we will show message box
				errors to user
			**********************************************/
			if (builder.ToString().Length > 0)
			{
				MessageBox.Show(builder.ToString(), "Errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return builder.ToString().Length <= 0;
		}

		/// <summary>
		/// Gets and initializes the log file
		/// </summary>
		/// <param name="logFileNamePath">string logFileNamePath</param>
		/// <returns>Return the TextWriter instance if found, otherwise null</returns>
		private TextWriter GetLogFile(string logFileNamePath)
		{
			if (String.IsNullOrEmpty(logFileNamePath) || Path.GetExtension(logFileNamePath).ToLower() != ".txt")
				throw new Exception("The logging file name path is required and must contain the extension '.txt'");
			FileStream fileStream;
			if (!File.Exists(logFileNamePath))
			{
				fileStream = File.Create(logFileNamePath);
			}
			else
			{
				fileStream = new FileStream(logFileNamePath, FileMode.Open);
			}
			return new StreamWriter(fileStream);
		}

		/// <summary>
		/// Write error to the log file and Rich Text Box
		/// </summary>
		/// <param name="ex">Exception ex</param>
		/// <param name="logger">TextWriter logger</param>
		/// <param name="enabledLogToFile">bool enabledLogToFile</param>
		private void WriteExceptionError(Exception ex, TextWriter logger, bool enabledLogToFile)
		{
			/**********************************************
				If enabling the log, we will write the error
				in Exception to the log file
			**********************************************/
			if (enabledLogToFile && logger != null)
			{
				logger.WriteLine(ex.Message);
			}

			/**********************************************
				If the message existed in Rich Text Box,
				we will do nothing, otherwise will append
				this error to Rich Text Box
			**********************************************/
			if (!rtbStatus.Text.Contains(ex.Message))
			{
				rtbStatus.AppendText(ex.Message + "\n");
			}
		}
		#endregion Useful methods
	}
}
