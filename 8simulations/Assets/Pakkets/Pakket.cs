using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    public blocksMsg2 blocksMsg2 { get; set; }
}


public class blocksMsg2
{
    [JsonProperty("D")]
    public blockmsgCarOnly D { get; set; } = new blockmsgCarOnly();

    [JsonProperty("E")]
    public blockmsgBus E { get; set; } = new blockmsgBus();

    [JsonProperty("F")]
    public blockmsg F { get; set; } = new blockmsg();

}

[Serializable]
public class blocksMsg
{
    [JsonProperty("A")]
    public blockmsg A { get; set; } = new blockmsg();

    [JsonProperty("B")]
    public blockmsgBus B { get; set; } = new blockmsgBus();

    [JsonProperty("C")]
    public blockmsgCarOnly C { get; set; } = new blockmsgCarOnly();


}

[Serializable]
public class blockmsg
{
    [JsonProperty("Cars")]
    public List<CarSensormsg> LCarSensormsgs { get; set; } = new List<CarSensormsg>();
    [JsonProperty("Cyclists")]
    public List<SingleDetector> Bikers { get; set; } = new List<SingleDetector>();
    [JsonProperty("Pedestrians")]
    public List<SingleDetector> Walkers { get; set; } = new List<SingleDetector>();

}
[Serializable]
public class blockmsgCarOnly
{
    [JsonProperty("Cars")]
    public List<CarSensormsg> LCarSensormsgs { get; set; } = new List<CarSensormsg>();

}

[Serializable]
public class blockmsgBus
{
    [JsonProperty("Cars")]
    public List<CarSensormsg> LCarSensormsgs { get; set; } = new List<CarSensormsg>();
    [JsonProperty("Cyclists")]
    public List<SingleDetector> Bikers { get; set; } = new List<SingleDetector>();
    [JsonProperty("Pedestrians")]
    public List<SingleDetector> Walkers { get; set; } = new List<SingleDetector> { };
    [JsonProperty("Busses")]
    public List<int> LBusses { get; set; } = new List<int>();

}


[Serializable]
public class SingleDetector
{
    public SingleDetector() { }
    public SingleDetector(bool _detected)
    {
        this.Detected = _detected;
    }

    public bool Detected { get; set; } = new bool();
}

[Serializable]
public class CarSensormsg
{
    public CarSensormsg() { }
    public CarSensormsg(bool detectNear, bool detectFar, bool prioCar)
    {
        DetectNear = detectNear;
        DetectFar = detectFar;
        PrioCar = prioCar;
    }

    public bool DetectNear { get; set; } = new bool();
    public bool DetectFar { get; set; } = new bool();
    public bool PrioCar { get; set; } = new bool();
}