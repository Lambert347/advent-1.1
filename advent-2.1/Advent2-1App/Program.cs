using System.Text.RegularExpressions;

namespace solution 
{
    class Program 
    {
        static void Main(string[] args)
        {
            var inputFile = File.ReadAllLines("input.txt");
            var inputList = new List<string>(inputFile);

            long total = 0;

            foreach(string line in inputList)
            {
                Boolean isValid = true;
                List<string> dividedLine = line.Split(":").ToList();

                List<string> dividedBySemiColon = dividedLine[1].Split(";").ToList();

                foreach(string round in dividedBySemiColon)
                {
                    List<string> dividedByComma = round.Split(",").ToList();

                    foreach(string color in dividedByComma)
                    {
                        List<string> dividedByWhiteSpace = color.Split(" ").ToList();

                        if(color.Contains("red") && int.Parse(dividedByWhiteSpace[1]) > 12)
                        {
                            isValid = false;
                        }
                        if(color.Contains("green") && int.Parse(dividedByWhiteSpace[1]) > 13)
                        {
                            isValid = false;
                        }
                        if(color.Contains("blue") && int.Parse(dividedByWhiteSpace[1]) > 14)
                        {
                            isValid = false;
                        }
                    }
                }

                if(isValid == true)
                {
                    List<string> splitGame = dividedLine[0].Split(" ").ToList();
                    total = total + int.Parse(splitGame[1]);
                }
            }
            Console.WriteLine(total);
        }
    }
}