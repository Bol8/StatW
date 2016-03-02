using Domain.Manage;
using System;
using Repository;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            gPartido gPartido = new gPartido();
            string path = @"C:\Users\Oscar\Downloads\SP1.csv";

            var lines = Manage.getData(path);

            //foreach (var line in lines)
            //{
            //    var data = Manage.SubArray(line.Split(','), 1, 6);
            //}

            for (int i = 1; i < lines.Length; i++)
            {
                var data = Manage.SubArray(lines[i].Split(','), 1, 6);
                var partido = Manage.createMatch(data);
                gPartido.save(partido);
            }

            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}