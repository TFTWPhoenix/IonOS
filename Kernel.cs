using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace IonOS
{
    public class Kernel : Sys.Kernel
    {
        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        protected override void BeforeRun()
        {
            Console.WriteLine("");
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.Clear();
        }

        protected override void Run()
        {
            while(true)
            {

                string input;
                Console.Write("AuroraSH > ");
                input = Console.ReadLine();
                CommandHandler.executeCommand(input);

            }
        }
    }
}
