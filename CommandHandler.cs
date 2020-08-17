using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Sys = Cosmos.System;

namespace IonOS
{
    public class CommandHandler
    {

        public static void executeCommand(string command)
        {

            if (command == "help")
            {

                Console.WriteLine("IonOS Help");
                Console.WriteLine("help - Get help");
                Console.WriteLine("reboot - Reboot");
                Console.WriteLine("shutdown [-r/--reboot] - Shutdown or reboot if -r or --reboot is used.");
                Console.WriteLine("fsinfo <drive> - Get FileSystem info for the specified drive.");
                Console.WriteLine("sysinfo - Get system info");
                Console.WriteLine("rm <file> - Delete a file");
                Console.WriteLine("rmd <dir> - Delete a directory");
                Console.WriteLine("edit <file> - Edits a file or makes a new one if the file doesn't exist");

            }
            else if (command == "shutdown")
            {

                Console.WriteLine("Shutting down IonOS...");
                Sys.Power.Shutdown();

            }
            else if (command == "reboot" || command == "shutdown -r" || command == "shutdown --reboot")
            {

                Sys.Power.Reboot();
            
            }
            else if (command.StartsWith("ls "))
            {

                string directory = command.Split(" ")[1];
                if(directory == "")
                {

                    directory = @"0:\";

                }
                Console.WriteLine("Directory of " + directory);
                int i = 0;
                string[] files = Directory.GetFiles(directory);
                string[] dirs = Directory.GetDirectories(directory);
                while (i < dirs.Length)
                {

                    Console.WriteLine("[DIR] " + dirs[i]);
                    i++;

                }
                i = 0;
                while(i < files.Length)
                {

                    Console.WriteLine(files[i]);
                    i++;

                }

            } else if (command == "ls")
            {

                string directory = @"0:\";
                Console.WriteLine("Directory of " + directory);
                int i = 0;
                string[] files = Directory.GetFiles(directory);
                string[] dirs = Directory.GetDirectories(directory);
                while (i < dirs.Length)
                {

                    Console.WriteLine("[DIR] " + dirs[i]);
                    i++;

                }
                i = 0;
                while (i < files.Length)
                {

                    Console.WriteLine(files[i]);
                    i++;

                }

            } else if (command.StartsWith("fsinfo "))
            {

                string filesystemtocheck = command.Split(" ")[1];
                bool isOk = filesystemtocheck != "";
                if(!isOk)
                {

                    Console.WriteLine("You need to specify a drive (e.g. 0:/, 1:/)");

                } else
                {

                    Console.WriteLine("File System Information for " + filesystemtocheck);
                    Console.WriteLine("Format: " + Kernel.fs.GetFileSystemType(filesystemtocheck));
                    Console.WriteLine("Free Space: " + Kernel.fs.GetAvailableFreeSpace(filesystemtocheck) / 1024 / 1024 + "MB");
                    Console.WriteLine("Total Space: " + Kernel.fs.GetTotalSize(filesystemtocheck) / 1024 / 1024 + "MB");

                }

            } else if (command == "sysinfo")
            {

                Console.WriteLine("System Information");
                Console.WriteLine("VM Users: System Info breaks in VMs due to the Cosmos Kernel not detecting CPU information properly");
                Console.WriteLine("Processor Vendor: " + Cosmos.Core.CPU.GetCPUVendorName());
                Console.WriteLine("Processor Speed: " + Cosmos.Core.CPU.GetCPUCycleSpeed() + "Hz");
                Console.WriteLine("Uptime: " + Cosmos.Core.CPU.GetCPUUptime());
                Console.WriteLine("RAM: " + Cosmos.Core.CPU.GetAmountOfRAM() + "MB");


            } else if (command.StartsWith("rm "))
            {

                File.Delete(command.Split(" ")[1]);

            } else if (command.StartsWith("rmd "))
            {

                Directory.Delete(command.Split(" ")[1]);

            } else if (command.StartsWith("edit "))
            {

                string file = command.Split(" ")[1];
                if(File.Exists(file))
                {

                    string[] contents = File.ReadAllLines(file);
                    int i = 0;
                    Console.WriteLine("Old Contents");
                    while(i < contents.Length)
                    {

                        Console.WriteLine(contents[i]);
                        i++;

                    }
                    Console.WriteLine("New Contents: ");
                    List<string> newconts = new List<string>();
                    string nextLn = "";
                    while(nextLn != @"\%exit")
                    {

                        nextLn = Console.ReadLine();
                        if(nextLn != @"\%exit")
                        {

                            newconts.Add(nextLn);

                        }

                    }
                    File.WriteAllLines(file, newconts.ToArray());

                } else
                {

                    Console.WriteLine("[NEW FILE]");
                    Console.WriteLine("Contents: ");
                    List<string> newconts = new List<string>();
                    string nextLn = "";
                    while (nextLn != @"\%exit")
                    {

                        nextLn = Console.ReadLine();
                        if (nextLn != @"\%exit")
                        {

                            newconts.Add(nextLn);

                        }

                    }
                    File.WriteAllLines(file, newconts.ToArray());

                }

                
                
            }

        }

    }
}
