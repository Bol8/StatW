using System;
using Repository;

namespace Domain.Manage
{
    public static class Manage
    {
        public static string[] getData(string path)
        {
            string[] lines = System.IO.File.ReadAllLines(path);

            return lines;
        }

        public static Partido createMatch(string[] data)
        {
            Partido partido = new Partido
            {
                Date = DateTime.Parse(data[0]),
                HomeTeam = data[1],
                AwayTeam = data[2],
                FTHG = Int32.Parse(data[3]),
                FTAG = Int32.Parse(data[4]),
                FTR = data[5]
            };

            return partido;
        }




        public static string[] SubArray(this string[] data, int index, int length)
        {
            string[] result = new string[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}