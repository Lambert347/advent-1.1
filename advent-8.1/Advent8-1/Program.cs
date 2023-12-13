var inputFile = File.ReadAllLines("input.txt");
var inputList = new List<string>(inputFile);

var rlPattern = inputList[0].Select(c => c.ToString()).ToList();

var coordinateList = new List<string>();

int numberOfSteps = 0;

string currentPlace = "AAA";

for(int i = 0; i < inputList.Count; i++)
{
    if(i != 0 && !string.IsNullOrEmpty(inputList[i]))
    {
        coordinateList.Add(inputList[i]);
    }
}

Dictionary<string, string> coordDict = convertToDictionary(coordinateList);

for(int i = 0; i < rlPattern.Count; i++)
{
    currentPlace = returnNextPlace(coordDict[currentPlace], returnIndexNumber(rlPattern[i]));
    numberOfSteps++;

    if(currentPlace.Equals("ZZZ"))
    {
        break;
    }

    if(i == rlPattern.Count - 1)
    {
        i = -1;
    }
}

Console.WriteLine(numberOfSteps);

string returnNextPlace(string options, int indexNumber)
{
    var optionsAsList = options.Split(",", StringSplitOptions.TrimEntries).ToList();

    return optionsAsList[indexNumber];
}


int returnIndexNumber(string letter)
{
    if(letter.Equals("R"))
    {
        return 1;
    }
    else if(letter.Equals("L"))
    {
        return 0;
    }

    return 0;
}

Dictionary<string, string> convertToDictionary(List<string> coordinateList)
{
    Dictionary<string, string> coordDict = new Dictionary<string, string>();

    foreach(string item in coordinateList)
    {
        string key = item.Split("=", StringSplitOptions.TrimEntries).ToList()[0];

        string value = item.Split("=", StringSplitOptions.TrimEntries).ToList()[1].Replace("(", "").Replace(")", "");

        coordDict.Add(key, value);
    }


    return coordDict;
}