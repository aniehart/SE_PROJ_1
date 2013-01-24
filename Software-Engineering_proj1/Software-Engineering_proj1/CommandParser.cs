using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Software_Engineering_proj1
{
    class CommandParser
    {
        private List<string> _result;
        private Stack<string> _stringStack;

        public List<string> commandList
        {
            get { return _result; }
            set { _result = value; }
        }

        public CommandParser(String commandLine)
        {
            string[] supportedCommands = { "push", "rvalue", "lvalue", "pop", ":=", "copy", "label", "goto", "gofalse", "gotrue", "halt", "+", "-", "*", "/", "div", "&", "!", "<>", "<=", ">=", "<", ">", "=", "print", "show", "begin", "end", "call", "return)", "(push", "rvalue", "lvalue", "pop", ":=", "copy", "label", "goto", "gofalse", "gotrue", "halt", "+", "-", "*", "/", "div", "&", "!", "<>", "<=", ">=", "<", ">", "=", "print", "show", "begin", "end", "call", "return" };
            commandList = Parse(commandLine, supportedCommands);
            //commandList = ConsolidateCommands(commandList);
        }

        private List<string> Parse(String input, string[] delimiters)
        {
            int[] nextPosition = delimiters.Select(d => input.IndexOf(d)).ToArray();
            List<string> result = new List<string>();
            int pos = 0;
            while (true)
            {
                int firstPos = int.MaxValue;
                string delimiter = null;
                for (int i = 0; i < nextPosition.Length; i++)
                {
                    if (nextPosition[i] != -1 && nextPosition[i] < firstPos)
                    {
                        firstPos = nextPosition[i];
                        delimiter = delimiters[i];
                    }
                }
                if (firstPos != int.MaxValue)
                {
                    result.Add(input.Substring(pos, firstPos - pos));
                    result.Add(delimiter);
                    pos = firstPos + delimiter.Length;
                    for (int i = 0; i < nextPosition.Length; i++)
                    {
                        if (nextPosition[i] != -1 && nextPosition[i] < pos)
                        {
                            nextPosition[i] = input.IndexOf(delimiters[i], pos);
                        }
                    }
                }
                else
                {
                    result.Add(input.Substring(pos));
                    break;
                }
            }

            return result;
        }

        //Intended to try and consolidate commands that have keywords in side of the show statements...awaiting email response on how to tell when show parameters end..
        //private List<string> ConsolidateCommands(List<string> commandsToConsolidate)
        //{
        //    int pos = 0;
        //    List<string> result = new List<string>();
        //    return commandsToConsolidate;
        //}
    }
}
