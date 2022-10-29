using System;
using System.Xml.Linq;

namespace Names
{
    internal static class HeatmapTask
    {
        public static HeatmapData GetBirthsPerDateHeatmap(NameData[] names)
        {
            var minDayValue = 2;
            var minMonthValue = 1;
            var day = new string[30];
            var month = new string[12];
            var dateBirths = new double[day.Length, month.Length];

            FillDateBirth(month, 1);
            FillDateBirth(day, 2);

            foreach (var human in names)
            {
                if (human.BirthDate.Day != 1)
                    dateBirths[human.BirthDate.Day - minDayValue, human.BirthDate.Month - minMonthValue]++;
            }

            return new HeatmapData(
                "Пример карты интенсивностей",
                dateBirths,
                day,
                month);
        }

        private static void FillDateBirth(string[] dateBirth, int minValue)
        {
            for (int i = 0; i < dateBirth.Length; i++)
            {
                dateBirth[i] = (i + minValue).ToString();
            }
        }
    }
}