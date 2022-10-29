using System;
using System.Linq;
using System.Security.Cryptography;

namespace Names
{
    internal static class HistogramTask
    {
        public static HistogramData GetBirthsPerDayHistogram(NameData[] names, string name)
        {
            var minDay = int.MaxValue;
            var maxDay = int.MinValue;
            var minDayValue = 1;

            foreach (var firstName in names)
            {
                minDay = Math.Min(minDay, firstName.BirthDate.Day);
                maxDay = Math.Max(maxDay, firstName.BirthDate.Day);
            }

            var days = new string[maxDay - minDay + 1];

            for (var y = 0; y < days.Length; y++)
                days[y] = (y + minDay).ToString();

            var birthsCounts = new double[maxDay - minDay + 1];

            FillDateBirth(names, name, minDayValue, birthsCounts);

            return new HistogramData(
                string.Format("Рождаемость людей с именем '{0}'", name),
                days,
                birthsCounts);
        }

        private static void FillDateBirth(NameData[] names, string name, int minDayValue, double[] birthsCounts)
        {
            foreach (var firstName in names)
                if (firstName.Name == name && firstName.BirthDate.Day != 1)
                    birthsCounts[firstName.BirthDate.Day - minDayValue]++;
        }
    }
}