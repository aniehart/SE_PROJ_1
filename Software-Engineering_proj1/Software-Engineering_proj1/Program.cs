using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Software_Engineering_proj1
{
    class Program
    {
        static void Main(string[] args)
        {
            input i = new input();
            Execution e = new Execution(i.commandArray);
            //Will need to remove the foreach, currently is used just to debug the file read
            foreach (string s in i.commandArray)
            {
                Console.WriteLine(s);
            }
            var waitingSoUserCanReadErrors = Console.ReadLine();
        }
    }
}
