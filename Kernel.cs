using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Sys = Cosmos.System;

namespace IonOS
{
    public class Kernel : Sys.Kernel
    {
        // Create the filesystem
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        protected override void BeforeRun()
        {
            Console.WriteLine("");
            // Register the filesystem.
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.Clear();
        }

        protected override void Run()
        {
            string[] loadArray;
            //Log in the user if not setup run the setup
            if(Directory.Exists(@"0:\IonOS"))
            {

                if(File.Exists(@"0:\IonOS\main.cfg"))
                {

                    loadArray = File.ReadAllLines(@"0:\IonOS\main.cfg");
                    info.username = loadArray[0];
                    if(loadArray[4] == "true")
                    {

                        setup.runDefault(loadArray[1],loadArray[2],loadArray[3]);

                    }

                } else
                {

                    setup.run();

                }

            } else
            {

                setup.run();

            }
            Console.WriteLine(messages.bootMessage);
            while(true)
            {

                string input;
                Console.Write(info.username + "@Aurora > ");
                input = Console.ReadLine();
                CommandHandler.executeCommand(input);

            }
        }
    }
}
