using System;
using Repository;
using Domain.Manage;
using System.Collections.Generic;
using Domain.Models;

namespace Domain.Manage
{
    public static class AppManage
    {
        static List<string[]> fileList = new List<string[]>();

        //LIGAS DE PRIMERA DIVISIÓN
        private const string SP1 = @"C:\Users\Oscar\Desktop\Resultados\SP1.csv";
        private const string E0 = @"C:\Users\Oscar\Desktop\Resultados\E0.csv";
        private const string I1 = @"C:\Users\Oscar\Desktop\Resultados\I1.csv";
        private const string D1 = @"C:\Users\Oscar\Desktop\Resultados\D1.csv";
        private const string F1 = @"C:\Users\Oscar\Desktop\Resultados\F1.csv";
        private const string N1 = @"C:\Users\Oscar\Desktop\Resultados\N1.csv";
        private const string P1 = @"C:\Users\Oscar\Desktop\Resultados\P1.csv";
        private const string T1 = @"C:\Users\Oscar\Desktop\Resultados\T1.csv";
        private const string SC0 = @"C:\Users\Oscar\Desktop\Resultados\SC0.csv";
        private const string G1 = @"C:\Users\Oscar\Desktop\Resultados\G1.csv";
        private const string B1 = @"C:\Users\Oscar\Desktop\Resultados\B1.csv";


        //LIGAS DE SEGUNDA DIVISIÓN
        private const string SP2 = @"C:\Users\Oscar\Desktop\Resultados\SP2.csv";
        private const string E1 = @"C:\Users\Oscar\Desktop\Resultados\E1.csv";
        private const string I2 = @"C:\Users\Oscar\Desktop\Resultados\I2.csv";
        private const string D2 = @"C:\Users\Oscar\Desktop\Resultados\D2.csv";
        private const string F2 = @"C:\Users\Oscar\Desktop\Resultados\F2.csv";
        private const string SC1 = @"C:\Users\Oscar\Desktop\Resultados\SC1.csv";


        private static gPartido gPartido = new gPartido();
        private static gEquipo gEquipo = new gEquipo();



        //private static string[] getData()
        //{
        //    string[] lines = System.IO.File.ReadAllLines(SP1);

        //    return lines;
        //}

        private static void loadFiles()
        {

            fileList.Add(System.IO.File.ReadAllLines(SP1));
            fileList.Add(System.IO.File.ReadAllLines(E0));
            fileList.Add(System.IO.File.ReadAllLines(I1));
            fileList.Add(System.IO.File.ReadAllLines(D1));
            fileList.Add(System.IO.File.ReadAllLines(F1));
            fileList.Add(System.IO.File.ReadAllLines(N1));
            fileList.Add(System.IO.File.ReadAllLines(P1));
            fileList.Add(System.IO.File.ReadAllLines(T1));
            fileList.Add(System.IO.File.ReadAllLines(SC0));
            fileList.Add(System.IO.File.ReadAllLines(G1));
            fileList.Add(System.IO.File.ReadAllLines(B1));

            fileList.Add(System.IO.File.ReadAllLines(SP2));
            fileList.Add(System.IO.File.ReadAllLines(E1));
            fileList.Add(System.IO.File.ReadAllLines(D2));
            fileList.Add(System.IO.File.ReadAllLines(F2));
            fileList.Add(System.IO.File.ReadAllLines(SC1));

        }


        public static Partido createMatch(string[] data)
        {
            int aux = 0;
            Partido partido = null;

            if (int.TryParse(data[4], out aux))
            {
                partido = new Partido
                {
                    Liga = data[0],
                    Date = DateTime.Parse(data[1]),
                    HomeTeam = data[2],
                    AwayTeam = data[3],
                    FTHG = Int32.Parse(data[4]),
                    FTAG = Int32.Parse(data[5]),
                    FTR = data[6]
                };
            }

            return partido;
        }


        public static void UpdateTeams()
        {
            var teams = gEquipo.getTeamsFromMatchs(gPartido.getElements());

            foreach (var team in teams)
            {
                if (!gEquipo.exist(team.Nombre))
                {
                    gEquipo.save(team);
                }
               
            }
        }


        public static void UpdateMatchs()
        { 
            loadFiles();

            foreach (var lines in fileList)
            {
                for (int i = 1; i < lines.Length; i++)
                {
                    var data = AppManage.SubArray(lines[i].Split(','), 0, 7);

                    var date = DateTime.Parse(data[1]);
                    var league = data[0];
                    var HomeTeam = data[2];

                    if (!gPartido.exist(date, league, HomeTeam))
                    {
                        var partido = AppManage.createMatch(data);

                        gPartido.save(partido);
                    }
                }
            }

            UpdateTeams  ();
            //var lines = getData();
        }

        public static string[] SubArray(this string[] data, int index, int length)
        {
            string[] result = new string[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}