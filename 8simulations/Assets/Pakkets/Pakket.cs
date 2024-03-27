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

