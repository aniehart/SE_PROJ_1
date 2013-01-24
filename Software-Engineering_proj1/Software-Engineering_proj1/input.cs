using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Software_Engineering_proj1
{
    class input
    {
        private string[] _commandArray;

        public string[] commandArray
        {
            get { return _commandArray; }
            set { _commandArray = value; }
        }

        public input()
        {
            var prompt = "Please input the path of the file to be executed.";
            Console.WriteLine(prompt);
            //var filePath = Console.ReadLine();
            string filePath = "demo.jaz";
            try
            {
                commandArray = File.ReadAllLines(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                var waitingSoUserCanReadErrors = Console.ReadLine();
            }
        }
    }
}
