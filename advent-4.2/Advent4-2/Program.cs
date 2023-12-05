var inputFile = File.ReadAllLines("input.txt");
var inputList = new List<string>(inputFile);

int total = 0;
int[] cardCount = new int[inputList.Count];
for(int i = 0; i < cardCount.Length; i++)
{
    cardCount[i] = 1;
}

for(int cardId = 0; cardId < inputList.Count; cardId++)
{
    int matchCount = 0;
    List<string> gameNumbers = inputList[cardId].Split("|", StringSplitOptions.TrimEntries).ToList()[1].Split(" ", StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
    List<string> winningNumbers = inputList[cardId].Split("|", StringSplitOptions.TrimEntries).ToList()[0].Split(":", StringSplitOptions.TrimEntries).ToList()[1].Split(" ", StringSplitOptions.TrimEntries).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();  
    
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

    if(matchCount > 0)
    {
        for(int i = 0; i < matchCount; i++)
        {
            cardCount[cardId + 1 + i] += cardCount[cardId];
        }
    }
}

Console.WriteLine(cardCount.Sum());

