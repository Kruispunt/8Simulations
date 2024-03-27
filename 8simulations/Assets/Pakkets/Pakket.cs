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
    public string Name;
    public bool State;
}
[Serializable]
public class Busses
{
    int id;
}