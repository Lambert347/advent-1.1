using System.Diagnostics;

var inputFile = File.ReadAllLines("input.txt");
var inputList = new List<string>(inputFile);
var handsWithRank = new List<string>();

long total = 0;

var handTypes = new Dictionary<string, int>()
{
    {"Five of a kind" , 7},
    {"Four of a kind" , 6},
    {"Full house" , 5},
    {"Three of a kind" , 4},
    {"Two pair" , 3},
    {"One pair" , 2},
    {"High card" , 1},
};

var cardTypes = new Dictionary<string, int>()
{
    {"A", 13},
    {"K", 12},
    {"Q", 11},
    {"T", 10},
    {"9", 9},
    {"8", 8},
    {"7", 7},
    {"6", 6},
    {"5", 5},
    {"4", 4},
    {"3", 3},
    {"2", 2},
    {"J", 1},
};

for(int i = 0; i < inputList.Count; i++)
{
    string currentCard = inputList[i].Split(" ", StringSplitOptions.TrimEntries).ToList()[0];
    string convertedHandCurrent = convertJ(currentCard);

    int maxRank = inputList.Count;

    List<string> duplicatesList = findDuplicatesInHand(convertedHandCurrent);
    string handTypeForCurrent = determineHandType(duplicatesList);
    
    int type = convertHandTypeToInt(handTypeForCurrent);


    for(int k = 0; k < inputList.Count(); k++)
    {
       
        string cardToCompare = inputList[k].Split(" ", StringSplitOptions.TrimEntries).ToList()[0];
        string convertedHandCompare = convertJ(cardToCompare);
        List<string> duplicatesInCompareCard = findDuplicatesInHand(convertedHandCompare);
        string handTypeForCompare = determineHandType(duplicatesInCompareCard);
        int compareType = convertHandTypeToInt(handTypeForCompare);
        
        if(!currentCard.Equals(cardToCompare))
        {
            if(type < compareType)
            {
                maxRank--;
            }
            if(type == compareType)
            {
                if(determineTheStrongerHand(currentCard, cardToCompare) == false)
                {
                    maxRank--;
                }
            }
        }
    }

    if(currentCard.Contains("J"))
    {
        Console.WriteLine(currentCard + "     " + maxRank + "    " + handTypeForCurrent);
    }
    
    string handWithRank = inputList[i] + "," + maxRank.ToString();

    handsWithRank.Add(handWithRank);
}


foreach(var item in handsWithRank)
{
    total = total + Convert.ToInt64(item.Split(",").ToList()[0].Split(" ").ToList()[1]) * Convert.ToInt64(item.Split(",").ToList()[1]);
}

Console.WriteLine(total);

List<string> findDuplicatesInHand(string hand)
{
    var handAsList = hand.Select(c => c.ToString()).ToList().OrderByDescending(i => i).ToList();;
    var convertedHand = new List<int>();
    var highestKind = new List<int>();

    List<string> duplicatesList = new List<string>();

    for(int i = 0; i < handAsList.Count(); i++)
    {
        int numberOfDuplicates = handAsList.Count(s => s == handAsList[i]);
        if(numberOfDuplicates > 1)
        {
            string cardPlusNumber = handAsList[i] + "," + numberOfDuplicates.ToString();
            if(!duplicatesList.Contains(cardPlusNumber))
            {
                duplicatesList.Add(cardPlusNumber);
            }
        }
    }

    return duplicatesList;
}

string determineHandType(List<string> duplicatesList)
{
        if(duplicatesList.Count == 0)
        {
            return "High card";
        }
        if(duplicatesList.Count == 1 && duplicatesList[0].Split(",").ToList()[1].Equals("2"))
        {
            return "One pair";
        }
        if(duplicatesList.Count == 2 && duplicatesList[0].Split(",").ToList()[1].Equals("2") && duplicatesList[1].Split(",").ToList()[1].Equals("2"))
        {
            return "Two pair";
        }
        if(duplicatesList.Count == 1 && duplicatesList[0].Split(",").ToList()[1].Equals("3"))
        {
            return "Three of a kind";
        }
        if(duplicatesList.Count == 2 )
        {
            return "Full house";
        }
        if(duplicatesList.Count == 1 && duplicatesList[0].Split(",").ToList()[1].Equals("4"))
        {
            return "Four of a kind";
        }
        if(duplicatesList.Count == 1 && duplicatesList[0].Split(",").ToList()[1].Equals("5"))
        {
            return "Five of a kind";
        }
        return "";
}

int convertHandTypeToInt(string handType)
{
    return handTypes[handType];
}

bool determineTheStrongerHand(string currentCard, string comparisonCard)
    {
        var currentCardAsList = currentCard.Select(c => c.ToString()).ToList();
        var comparisonCardAsList = comparisonCard.Select(c => c.ToString()).ToList();

        for(int i = 0; i < currentCardAsList.Count; i++)
        {
            if(cardTypes[currentCardAsList[i]] == cardTypes[comparisonCardAsList[i]])
            {
                continue;
            }
            if(cardTypes[currentCardAsList[i]] > cardTypes[comparisonCardAsList[i]])
            {
                return true;
            }
            if(cardTypes[currentCardAsList[i]] < cardTypes[comparisonCardAsList[i]])
            {
                return false;
            }
        }
        return false;
    }

string convertJ(string hand)
{
    List<string> duplicatesList = findDuplicatesInHand(hand).ToList();

    List<string> convertHandAsList = new List<string>();

    var handAsList = hand.Select(c => c.ToString()).ToList();

    string conversionTarget = "";

    if(duplicatesList.Count == 1)
    {
        conversionTarget = duplicatesList[0].Split(",").ToList()[0];
        
    }
    if(duplicatesList.Count == 1 && duplicatesList[0].Split(",").ToList()[0].Equals("J"))
    {
        foreach(string card in handAsList)
        {
            if(!card.Equals("J"))
            {
                conversionTarget = card;
                break;
            }
        }
    }
    if(duplicatesList.Count == 0)
    {
        foreach(string card in handAsList)
        {
            if(!card.Equals("J"))
            {
                conversionTarget = card;
                break;
            }
        }
    }
    if(duplicatesList.Count > 1)
    {
        foreach(string item in duplicatesList)
        {
            if(!item.Contains("J"))
            {
                conversionTarget = item.Split(",").ToList()[0];
            }
        }
    }

    for(int i = 0; i < handAsList.Count; i++)
    {
        if(!handAsList[i].Equals("J"))
        {
            convertHandAsList.Add(handAsList[i]);
        }
        if(handAsList[i].Equals("J"))
        {
            convertHandAsList.Add(conversionTarget);
        }
    }

    return string.Join("", convertHandAsList);
}