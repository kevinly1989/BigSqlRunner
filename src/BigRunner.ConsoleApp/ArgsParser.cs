using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigRunner.ConsoleApp
{
    public class ArgsParser
    {
        private List<string> unidentifiedArgs;
        private Dictionary<string, string> identifiedArgs;
        public ArgsParser(string[] args)
        {
            unidentifiedArgs = new List<string>();
            identifiedArgs = new Dictionary<string, string>();
            Parse(args);
        }

        private void Parse(string[] args)
        {
            string curr = String.Empty;
            foreach (var arg in args)
            {
                if (IsCommand(arg))
                {
                    if (!String.IsNullOrWhiteSpace(curr))
                    {
                        // add value-less command to dictionary
                        identifiedArgs.Add(curr, String.Empty);
                    }
                    curr = GetKey(arg);
                }
                else
                {
                    if (String.IsNullOrWhiteSpace(curr))
                    {
                        // if value without command was informed it goes to special values list
                        unidentifiedArgs.Add(arg);
                    }
                    else
                    {
                        identifiedArgs.Add(curr, arg);
                        curr = String.Empty;
                    }
                }
            }
            // add stand-alone option if it was the last cmd informed
            if (!String.IsNullOrWhiteSpace(curr))
            {
                identifiedArgs.Add(curr, String.Empty);
            }
        }

        private bool IsCommand(string arg)
        {
            return arg.StartsWith("-") || arg.StartsWith("--");
        }

        private string GetKey(string arg)
        {
            if (!IsCommand(arg))
                return arg;
            else
                if (arg.StartsWith("-"))
                    return arg.Substring(1);
                else
                    return arg.Substring(2);
        }

        public bool HasArg(string arg)
        {
            return identifiedArgs.ContainsKey(GetKey(arg));
        }

        public string GetArg(string arg)
        {
            if (!HasArg(arg))
                throw new ArgumentException(String.Format("Argument %s not found.", arg));
            return identifiedArgs[GetKey(arg)];
        }

        public List<string> GetArgs()
        {
            return unidentifiedArgs;
        }
    }
}
