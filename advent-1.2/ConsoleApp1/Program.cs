// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;

namespace solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var allDigits = new Dictionary<string, int>()
            {
                {"one" , 1},
                {"two" , 2},
                {"three" , 3},
                {"four" , 4},
                {"five" , 5},
                {"six" , 6},
                {"seven" , 7},
                {"eight" , 8},
                {"nine" , 9},
            };

            for(int i = 1; i < 10; i++)
            {
                allDigits.Add(i.ToString(), i);
            }

            int total = 0;
        
            var inputFile = File.ReadAllLines("input.txt");
            var inputList = new List<string>(inputFile);

                foreach(string listLine in inputList)
                {
                    var firstIndex = listLine.Length;
                    var lastIndex = -1;
                    var firstValue = 0;
                    var lastValue = 0;

                    foreach (var digit in allDigits)
                    {
                        var index = listLine.IndexOf(digit.Key);
                        if (index == -1)
                        {
                            continue;
                        }

                        if (index < firstIndex)
                        {
                            firstIndex = index;
                            firstValue = digit.Value;
                        }

                        index = listLine.LastIndexOf(digit.Key);

                        if (index > lastIndex)
                        {
                            lastIndex = index;
                            lastValue = digit.Value;
                        }
                    }

                    var fullNumber = firstValue * 10 + lastValue;
                    total += fullNumber;                
                }
            Console.WriteLine(total); 
        }
    }
}
