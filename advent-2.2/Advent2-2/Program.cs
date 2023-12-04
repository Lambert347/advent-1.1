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
                int fewestRed = 0;
                int fewestGreen = 0;
                int fewestBlue = 0;
                Boolean isValid = true;
                List<string> dividedLine = line.Split(":").ToList();

                List<string> dividedBySemiColon = dividedLine[1].Split(";").ToList();

                foreach(string round in dividedBySemiColon)
                {
                    List<string> dividedByComma = round.Split(",").ToList();

                    foreach(string color in dividedByComma)
                    {
                        List<string> dividedByWhiteSpace = color.Split(" ").ToList();

                        if(color.Contains("red"))
                        {
                            if(fewestRed == 0){
                                fewestRed = int.Parse(dividedByWhiteSpace[1]);
                            }
                            if(fewestRed < int.Parse(dividedByWhiteSpace[1]))
                            {
                                fewestRed = int.Parse(dividedByWhiteSpace[1]);
                            }
                        }
                        if(color.Contains("green"))
                        {
                            if(fewestGreen == 0){
                                fewestGreen = int.Parse(dividedByWhiteSpace[1]);
                            }
                            if(fewestGreen < int.Parse(dividedByWhiteSpace[1]))
                            {
                                fewestGreen = int.Parse(dividedByWhiteSpace[1]);
                            }
                        }
                        if(color.Contains("blue"))
                        {
                            if(fewestBlue == 0){
                                fewestBlue = int.Parse(dividedByWhiteSpace[1]);
                            }
                            if(fewestBlue < int.Parse(dividedByWhiteSpace[1]))
                            {
                                fewestBlue = int.Parse(dividedByWhiteSpace[1]);
                            }
                        }
                    }
                }
                
                if(fewestRed == 0)
                {
                    fewestRed = 1;
                }
                if(fewestGreen == 0)
                {
                    fewestGreen = 1;
                }
                if(fewestBlue == 0)
                {
                    fewestBlue = 1;
                }

                total = total + (fewestRed * fewestGreen * fewestBlue);
            }
            Console.WriteLine(total);
        }
    }
}
