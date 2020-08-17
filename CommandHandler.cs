using System;
using System.Collections.Generic;
using System.Text;

namespace IonOS
{
    public class CommandHandler
    {

        public static void executeCommand(string command)
        {

            if(command == "help")
            {

                Console.WriteLine("IonOS Help");
                Console.WriteLine("help - Get help");

            }

        }

    }
}
