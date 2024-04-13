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


[Serializable]
public class SignalGroup
{
    [JsonProperty("1")]
    public blocksMsg blocksMsg1 { get; set; }
    [JsonProperty("2")]
    public blocksMsg blocksMsg2 { get; set; }
}


[Serializable]
public class blocksMsg
{
    [JsonProperty("A")] 
    public blockmsg A { get; set; }

    [JsonProperty("B")] 
    public blockmsgBus B { get; set; }

    [JsonProperty("C")] 
    public blockmsgCarOnly C { get; set; }

    [JsonProperty("D")]
    public blockmsgCarOnly D { get; set; }

    [JsonProperty("E")]
    public blockmsgBus E { get; set; }

    [JsonProperty("F")]
    public blockmsg F { get; set; }

}


[Serializable]
public class blockmsg
{
    [JsonProperty("Cars")]
    public List<CarSensormsg> LCarSensormsgs { get; set; }
    [JsonProperty("Cyclists")]
    public List<SingleDetector> Bikers { get; set; }
    [JsonProperty("Pedestrians")]
    public List<SingleDetector> Walkers { get; set; }

}
[Serializable]
public class blockmsgCarOnly
{
    [JsonProperty("Cars")]
    public List<CarSensormsg> LCarSensormsgs { get; set; }

}

[Serializable]
public class blockmsgBus
{
    [JsonProperty("Cars")]
    public List<CarSensormsg> LCarSensormsgs { get; set; }
    [JsonProperty("Cyclists")]
    public List<SingleDetector> Bikers { get; set; }
    [JsonProperty("Pedestrians")]
    public List<SingleDetector> Walkers { get; set; }
    [JsonProperty("Busses")]
    public List<int> LBusses { get; set; }

}


[Serializable]
public class SingleDetector
{
    public bool Detected { get; set; }
}

[Serializable]
public class CarSensormsg
{
    public bool DetectNear { get; set; }
    public bool DetectFar { get; set; }
    public bool PrioCar { get; set; }
}