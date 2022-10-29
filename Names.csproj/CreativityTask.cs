using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Names
{
    internal static class CreativityTask
    {
        public static HistogramData MyTest(NameData[] names)
        {
            var minYear = int.MaxValue;
            var maxYear = int.MinValue;
            foreach (var name in names)
            {
                minYear = Math.Min(minYear, name.BirthDate.Year);
                maxYear = Math.Max(maxYear, name.BirthDate.Year);
            }

            var years = new string[maxYear - minYear + 1];

            for (var y = 0; y < years.Length; y++)
                years[y] = (y + minYear).ToString();

            var birthsCounts = new double[maxYear - minYear + 1];

            foreach (var name in names)
            {
                var letter = 'м';
                if (name.Name[0] == Char.ToLower(letter))
                {
                    birthsCounts[name.BirthDate.Year - minYear]++;
                }
            }
                
            return new HistogramData(
                string.Format("Рождаемость людей в годах, имя которых начинается на букву 'м' "),
                years,
                birthsCounts);
        }
    }
}

