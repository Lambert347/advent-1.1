using System.Text.RegularExpressions;

var inputFile = File.ReadAllLines("input.txt");
var inputList = new List<string>(inputFile);

Regex regex = new Regex(@"\s+");

var time = ReplaceWhitespace(inputList[0].Split(":").ToList()[1], regex);
var distance = ReplaceWhitespace(inputList[1].Split(":").ToList()[1], regex);

long amountOfWaysToWinPerRace = 0;

long distanceToGo = Convert.ToInt64(distance);

long baseTimeUsed = 0;
long maxTime = Convert.ToInt64(time); 

while(baseTimeUsed < maxTime)
{   
    long distancePerMillisecond = baseTimeUsed;

    long timeLeft = maxTime - baseTimeUsed;

    if(distancePerMillisecond * timeLeft > distanceToGo)
    {
        amountOfWaysToWinPerRace++;
    }

    baseTimeUsed++;
}

Console.WriteLine(amountOfWaysToWinPerRace);
static string ReplaceWhitespace(string input, Regex regex) 
{
    string replacement = "";
    return regex.Replace(input, replacement);
}