

using System.Numerics;

namespace AOC.Solutions._2021
{
    internal class Day1 : SolutionBase, ISolution
    {

        private List<int> calorieSums= new List<int>();

        private List<int> GetCalorieSums(List<string> inputLines)
        {
            List<int> calorieSums = new List<int>();
            int currentSum = 0;

            foreach (string line in inputLines)
            {
                if (line.Length == 0)
                {
                    calorieSums.Add(currentSum);
                    currentSum = 0;
                }

                int currentCalories = 0;
                if (int.TryParse(line, out currentCalories))
                {
                    currentSum += currentCalories;
                }
            }

            return calorieSums;
        }

        public override string Part1Solution()
        {

            //List<int> increases = new List<int>();

            //int lastLine = 0;

            //foreach (string line in InputLines)
            //{
            //    if (string.IsNullOrWhiteSpace(line))
            //    {
            //        continue;
            //    }
            //    if (lastLine != 0)
            //    {
            //        if (Convert.ToInt32(line) > lastLine)
            //        {
            //            increases.Add(1);
            //        }

            //        lastLine = Convert.ToInt32(line);
            //    }
            //    else
            //    {
            //        lastLine = Convert.ToInt32(line);
            //    }
            //}

            //Console.WriteLine(sizeof(int) * increases.Count());

            //return increases.Sum().ToString();

            int increases = 0;
            int? lastLine = null;

            foreach(string currentLine in InputLines)
            {

                int currentLineNumber = 0;
                int.TryParse(currentLine, out currentLineNumber);

                if (lastLine.HasValue)
                {
                    if (currentLineNumber > lastLine)
                    {
                        increases++;
                    }
                }

                lastLine = currentLineNumber;
            }

            return increases.ToString();
        }

        public override string Part2Solution()
        {
            List<int> top3 = GetCalorieSums(InputLines)
                .OrderBy(x => x)
                .Reverse()
                .Take(3)
                .ToList();

            return top3.Sum().ToString();
        }
    }
}
