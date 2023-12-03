// See https://aka.ms/new-console-template for more information
using System;
using System.IO;

namespace solution
{
    class Program
    {

        static void Main(string[] args)
        {
            string line = "";
            List<string> lines = new List<string>();
            try 
            {
                StreamReader sr = new StreamReader("input.txt");

                while(!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    lines.Add(line);
                }

                int total = 0;
                
                foreach(string listLine in lines)
                {
                    string firstDigit = "none";
                    string lastDigit = "";
                    var lineAsList = listLine.ToList();
                    foreach(char character in lineAsList)
                    {
                        if(Char.IsDigit(character))
                        {
                            if(firstDigit.Equals("none")){
                                firstDigit = character.ToString();
                                lastDigit = character.ToString();
                            }
                            else
                            {
                                lastDigit = character.ToString();
                            }
                        }
                    }
                    string fullNumber = firstDigit + lastDigit;
                    Console.WriteLine(fullNumber);
                    total = total + Int32.Parse(fullNumber);
                }

                Console.WriteLine(total);

                sr.Close();
                Console.ReadLine();                
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }

}
