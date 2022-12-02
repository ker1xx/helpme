using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prac7
{
    internal static class chose_disks
    {
        public static void chose()
        {
            while (y.key.Key != ConsoleKey.O)
            {
                DriveInfo[] drivers = DriveInfo.GetDrives();
                foreach (var drive in drivers)
                {
                    float avalible = Convert.ToSingle(drive.AvailableFreeSpace) / 1024 / 1024 / 1024;
                    float total = Convert.ToSingle(drive.TotalSize) / 1024 / 1024 / 1024;
                    avalible = (float)Math.Round(avalible, 0);
                    total = (float)Math.Round(total, 0);
                    Math.Round(total, 0);
                    Console.WriteLine("  " + drive.Name + " " + avalible + " GB / " + total + " GB");
                }
                arrow arrow = new arrow(0, drivers.Count() - 1);
                int pos = arrow.movearrow();
                Console.Clear();
                chumba(drivers[pos].ToString());
                y.key = new ConsoleKeyInfo((char)ConsoleKey.S, ConsoleKey.S, false, false, false);
                pos = 0;
            }

        }
        private static void chumba(string path)
        {
            while (y.key.Key != ConsoleKey.O)
            {
                string[] Directs = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                foreach (string file in Directs)
                {
                    DirectoryInfo info = new DirectoryInfo(file);
                    Console.WriteLine("  " + file + "  "  + info.LastAccessTime);
                }
                foreach (string file in files)
                {
                    FileInfo info = new FileInfo(file);
                    Console.WriteLine("  " + file + "  " + info.LastAccessTime);
                }
                arrow arrow = new arrow(0, Directs.Count() + files.Count() - 1);
                y.key = new ConsoleKeyInfo((char)ConsoleKey.S, ConsoleKey.S, false, false, false);
                int pos = arrow.movearrow();
                Console.Clear();
                int papki_count = Directs.Count();
                if (pos == -1)
                {
                    return;
                }
                else if (pos <= papki_count)
                    chumba(Directs[pos].ToString());
                else
                {
                    Process.Start(new ProcessStartInfo { FileName = files[pos - papki_count], UseShellExecute = true });

                }
            }
        }
    }
}
