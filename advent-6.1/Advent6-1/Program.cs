var inputFile = File.ReadAllLines("input.txt");
var inputList = new List<string>(inputFile);

int total = 1;

var timeList = inputList[0].Split(":").ToList()[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);
var distanceList = inputList[1].Split(":").ToList()[1].Split(" ", StringSplitOptions.RemoveEmptyEntries);

var amountList = new List<int>();

for(int i = 0; i < timeList.Count(); i++)
{
    int amountOfWaysToWinPerRace = 0;

    int distanceToGo = int.Parse(distanceList[i]);

    int baseTimeUsed = 0;
    int maxTime = int.Parse(timeList[i]); 

    while(baseTimeUsed < maxTime)
    {
        
        int distancePerMillisecond = baseTimeUsed;

        int timeLeft = maxTime - baseTimeUsed;

        if(distancePerMillisecond * timeLeft > distanceToGo)
        {
            amountOfWaysToWinPerRace++;
        }

        baseTimeUsed++;
    }

    amountList.Add(amountOfWaysToWinPerRace);    
}

foreach(int number in amountList)
{
    total = total * number;
}

Console.WriteLine(total);