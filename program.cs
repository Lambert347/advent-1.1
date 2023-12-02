namespace solution
{
    class Program
    {

        static readonly string textFile = @ "/Users/ianlambert/Documents/random-projects/advent-2023/advent-1.1/input.txt";



        static void Main(string[] args)
        {
            if(File.Exists(textFile)){
                string[] lines = File.ReadAllLines(textFile);
                foreach(string line in lines)
                Console.WriteLine(text);
            }
        }
    }

}