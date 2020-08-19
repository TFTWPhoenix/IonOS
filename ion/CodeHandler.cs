using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

namespace IonOS.ion
{
    public class CodeHandler
    {

        public static string[] ionData = new string[256];
        public static void execute(string line)
        {

            string[] lineArgs;
            lineArgs = line.Split("(")[1].Split(")")[0].Split(",");
            string command = line.Split("(")[0];
            if(command == "Output.println")
            {

                Console.WriteLine(lineArgs[0].Replace("\"",""));

            } else if (command == "Output.print")
            {

 
                Console.Write(lineArgs[0].Replace("\"", ""));

            } else if (command == "Data.store")
            {

                ionData[int.Parse(lineArgs[0])] = lineArgs[1].Replace("\"","");

            } else if (command == "Output.printdata" || command == "Data.printdata" || command == "Data.output.printdata")
            {

                Console.Write(ionData[int.Parse(lineArgs[0])]);

            }
            

        }

    }
}
