using System;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;

namespace TwentinonethApplication.ConsoleApp
{
    class Program
    {
        public static void Folder()
        {

            while (true)
            {
                try
                {

                    DirectoryInfo dirinfo = new(@"C:\Users\TheDarkKnight\Downloads\TestFolder");
                    if (dirinfo.Exists)
                    {
                        var files = dirinfo.GetFiles();
                        foreach (var file in files)
                        {

                            if (DateTime.Now - file.LastAccessTime > TimeSpan.FromSeconds(30))
                            {
                                file.Delete();
                                Console.WriteLine("Чистим файлы");

                            }
                            else
                            {
                                Console.WriteLine("Не чистим файлы");
                            }
                        }
                        var directories = dirinfo.GetDirectories();
                        foreach (var dir in directories)
                        {

                            if (DateTime.Now - dir.LastAccessTime > TimeSpan.FromSeconds(30))
                            {
                                dir.Delete();
                                Console.WriteLine("Чистим папки");

                            }
                            else
                            {
                                Console.WriteLine("Не чистим папки");
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {

                    Thread.Sleep(TimeSpan.FromSeconds(30));
                }
            }
        }

        static void Main(string[] args)
        {
            Folder();
        }
    }
}
