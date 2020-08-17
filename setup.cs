using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace IonOS
{
    public class setup
    {

        public static void run()
        {

            Console.WriteLine("----------=====IonOS Setup=====----------");
            Console.WriteLine("Select an option:");
            Console.WriteLine("(1) Normal Setup");
            Console.WriteLine("(2) OEM Setup (For Device Manufacturers)");
            Console.Write("Selection: ");
            string type = Console.ReadLine();
            string[] setupArray = {"","","","","false"};
            if(type == "1")
            {

                Console.Write("Username: ");
                info.username = Console.ReadLine();
                Console.WriteLine("Welcome " + info.username + " now we have some important setup to do. We'll be done very soon.");
                setupArray[0] = info.username;
                System.IO.File.WriteAllLines(@"0:\IonOS\main.cfg", setupArray);

            } else if (type == "2")
            {

                Console.WriteLine("OEM Setup");
                Console.Write("Product Name: ");
                setupArray[1] = Console.ReadLine();
                Console.Write("Product Model: ");
                setupArray[2] = Console.ReadLine();
                Console.Write("OEM Company Name: ");
                setupArray[3] = Console.ReadLine();
                Console.WriteLine("The system will start the setup on next boot.");
                info.runSetup = true;
                setupArray[4] = "true";
                System.IO.File.WriteAllLines(@"0:\IonOS\main.cfg", setupArray);
                info.username = "OEM";

            } else
            {

                Console.WriteLine("Select either 1 or 2.");
                run();

            }

        }
        public static void runDefault(string prodName, string prodModel, string oemName)
        {

            Console.WriteLine("Let's set up your " + oemName + " " + prodName + " " + prodModel + "!");
            string[] setupArray = {"", prodName, prodModel, oemName, "false"};
            Console.Write("Username: ");
            info.username = Console.ReadLine();
            Console.WriteLine("Welcome " + info.username + " now we have some important setup to do. We'll be done very soon.");
            setupArray[0] = info.username;
            System.IO.File.WriteAllLines(@"0:\IonOS\main.cfg", setupArray);

        }

    }
}
