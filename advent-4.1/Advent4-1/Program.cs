var inputFile = File.ReadAllLines("input.txt");
var inputList = new List<string>(inputFile);

int total = 0;
foreach(string line in inputList){
    int matchCount = 0;

    List<string> gameNumbers = line.Split("|", StringSplitOptions.TrimEntries).ToList()[1].Split(" ", StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
    List<string> winningNumbers = line.Split("|", StringSplitOptions.TrimEntries).ToList()[0].Split(":", StringSplitOptions.TrimEntries).ToList()[1].Split(" ", StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

    foreach(string number in gameNumbers)
    {
        foreach(string winningNumber in winningNumbers)
        {
            if(number.Equals(winningNumber) && (!number.Equals("  ")))
            {
                matchCount++;
            }
        }
    }
    total = calculateNewTotalPerGame(total, matchCount);

    
}

Console.WriteLine(total);

int calculateNewTotalPerGame(int total, int matchCount) 
{
        if(matchCount == 1)
        {
            total++;
        }
        if(matchCount > 1)
        {
            total = total + Convert.ToInt32(Math.Pow(2, matchCount - 1));
        }
        return total;
}

