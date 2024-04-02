using JetBrains.Annotations;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Pakket
{
    public string id;
    public List<int> lights;
}

[System.Serializable]
public class Sendpakket
{
    public string id;
    [SerializeField]
    public List<Tuple<bool, bool>> lights;
}

[Serializable]
public class Index
{
    public Block[] blocks;
}


//char and don't go well String works a bit better in json formats
[Serializable]
public class Block
{
    public string id;
    public Sensors[] Cars;
    public Sensors[] Cyclists;
    public Sensors[] Pedestrians;
    public Busses[] Busses;
}

[Serializable]
public class Sensors
{
    public string Name = "harry";
    public bool State = false;
}
[Serializable]
public class Busses
{
    int id = 10;
}



public partial class CrossingMessage
{
    //needed define
    [JsonProperty("1")] // I don't like this but it's needed for the current json structure
    public RoadsMessage RoadsMessage { get; set; }

    public int CrossingId = 1; // I don't like this but it's needed for the current json structure
}

public partial class RoadsMessage
{
    [JsonProperty("A")] // I don't like this but it's needed for the current json structure
    public RoadMessage A { get; set; }

    [JsonProperty("B")] // I don't like this but it's needed for the current json structure
    public RoadMessage B { get; set; }

    [JsonProperty("C")] // I don't like this but it's needed for the current json structure
    public RoadMessage C { get; set; }
}

public partial class RoadMessage
{
    //redifine name of the class
    [JsonProperty("cars")]
    public CarLaneMessage[] Lanes { get; set; }
}

[JsonObject]
public partial class CarLaneMessage
{
    public bool DetectNear { get; set; }
    public bool DetectFar { get; set; }
    public bool PrioCar { get; set; }
}

[Serializable]
public class SignalGroup
{
    [JsonProperty("1")]
    public blocksMsg blocksMsg { get; set; }
    public int id = 1;
}


[Serializable]
public class blocksMsg
{
    [JsonProperty("A")] // I don't like this but it's needed for the current json structure
    public blockmsg A { get; set; }

    [JsonProperty("B")] // I don't like this but it's needed for the current json structure
    public blockmsg B { get; set; }

    [JsonProperty("C")] // I don't like this but it's needed for the current json structure
    public blockmsg C { get; set; }

}


[Serializable]
public class blockmsg
{
    [JsonProperty("Cars")]
    public CarSensormsg[] CarSensormsg { get; set; }

}

[Serializable]
public class CarSensormsg
{
    public bool DetectNear { get; set; }
    public bool DetectFar { get; set; }
    public bool PrioCar { get; set; }
}