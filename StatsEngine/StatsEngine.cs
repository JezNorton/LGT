using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsEngine
{
    public class StatsManager
    {
        private List<int> _ints;

        public StatsManager(string input)
        {
            _ints = ParseInput(input).ToList();
            if (_ints.Count == 0) throw new Exception("Invalid input");
        }

        private static int? TryParseInt32(string text)
        {
            return int.TryParse(text, out var value) ? value : (int?)null;
        }
        private static IEnumerable<int> ParseInput(string input)
        {
            return from t in input.Split(',')
                   select TryParseInt32(t)
                into x
                   where x.HasValue
                   select x.Value;
        }

        public int Max()
        {
            return _ints.Max();
        }

        public int Min()
        {
            return _ints.Min();
        }

        public double Avg()
        {
            return _ints.Average();
        }

        public double StandardDeviation()
        {
            double standardDeviation = 0;
            var enumerable = _ints.ToArray();
            var count = enumerable.Count();
            if (count <= 1) return standardDeviation;
            var avg = enumerable.Average();
            var sum = enumerable.Sum(d => (d - avg) * (d - avg));
            standardDeviation = Math.Sqrt(sum / count);
            return standardDeviation;
        }

    }
}
