using System;
using System.IO;

namespace Filewatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            
                FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\senth\OneDrive\Skrivebord\Test");
                watcher.EnableRaisingEvents = true;
                watcher.IncludeSubdirectories = true;

                //add Event handlers
                watcher.Changed += watcher_Changed;
                watcher.Created += Watcher_Created;
                watcher.Deleted += Watcher_Deleted;
                watcher.Renamed += Watcher_Renamed;

                Console.Read(); //don't forget to stop the program at this line

            static void watcher_Changed(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine("File: {0} changed at time: {1}", e.Name, DateTime.Now.ToLocalTime());
            }
        }

        private static void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: {0} created at time: {1}", e.Name, DateTime.Now.ToLocalTime());
        }

        private static void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine("File: {0} deleted at time: {1}", e.Name, DateTime.Now.ToLocalTime());
        }

        private static void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1} at time: {2}", e.OldName, e.Name, DateTime.Now.ToLocalTime());
        }
    }
}
