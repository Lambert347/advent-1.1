var inputList = readFileAndReturnList();

long closestLocation = 0;

List<string> seedInfo = inputList[0].Split(":", StringSplitOptions.RemoveEmptyEntries).ToList()[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

List<Dictionary<long, string>> mapList = createMapList(trimList(inputList));

foreach(string seed in seedInfo)
{
    long runningLocator = 0;
    
    foreach (var dict in mapList)
    {
        if(mapList.IndexOf(dict) == 0)
        {
            runningLocator = findKeyInDict(dict, Convert.ToInt64(seed));
        }
        else
        {
            runningLocator = findKeyInDict(dict, runningLocator);
        }
    }
    if(seedInfo.IndexOf(seed) == 0)
    {
        closestLocation = runningLocator;
    }
    else
    {
        if(runningLocator < closestLocation)
        {
            closestLocation = runningLocator;
        }
    }
}

Console.WriteLine(closestLocation);

static List<string> readFileAndReturnList()
{
    var inputFile = File.ReadAllLines("input.txt");
    var inputList = new List<string>(inputFile);
    var returnList = new List<string>();

    foreach(string line in inputList)
    {
        returnList.Add(line);
    }
    return returnList;
}

static List<Dictionary<long, string>> createMapList(List<string> inList)
{
    bool append = false;
    List<string> newList = new List<string>();
    List<Dictionary<long, string>> mapList = new List<Dictionary<long, string>>();

    for(int i = 0; i < inList.Count; i++)
    {
        if(string.IsNullOrEmpty(inList[i]) || i == inList.Count - 1)
        {
            append = false;
            var createdDict = createValueMap(newList);

            mapList.Add(createdDict);
            newList.Clear();
        }
        if(append == true)
        {
            newList.Add(inList[i]);
        }
        if(inList[i].Contains("map"))
        {
            append = true;
        }
    }

    return mapList;
}

static Dictionary<long, string> createValueMap(List<string> initialList)
{
    Dictionary<long, string> mapDict = new Dictionary<long, string>();

    foreach(string line in initialList)
    {
        List<string> lineAsList = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

        long sourceNumber = Convert.ToInt64(lineAsList[1]);

        mapDict.Add(sourceNumber, lineAsList[0] + "," + lineAsList[2]);

    }

    return mapDict;
}

static long findKeyInDict(Dictionary<long, string> input, long number)
{
    foreach(KeyValuePair<long, string> kvp in input)
    {
        long range = Convert.ToInt64(kvp.Value.Split(",").ToList()[1]) - 1;

        if(number >= kvp.Key && number <= kvp.Key + range)
        {
            long difference = number - kvp.Key;
            return Convert.ToInt64(kvp.Value.Split(",").ToList()[0]) + difference;
        }
    }

    return number;
}

static List<string> trimList(List<string> input)
{
    List<string> newList = new List<string>();
    for(int i = 0; i < input.Count; i++)
    {
        if(i > 1)
        {
            newList.Add(input[i]);
        }
    }

    return newList;
}



