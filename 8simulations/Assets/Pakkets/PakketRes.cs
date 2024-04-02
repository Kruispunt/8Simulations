using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace recieverpakket
{


    [Serializable]
public class PakketRes
{
        public Block[] blocks;
      
}
    [Serializable]
    public class Block
    {
        public string id;
        public int[] Cars;
        public int[] Cyclists;
        public int[] Pedestrians;
    }

    public class SignalGroup
    {
        [JsonProperty("1")]
        public blocksMsg blocksMsg { get; set; }
        //public int id = 1;
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
        public int[] cari;
        [JsonProperty("Cyclists")]
        public int[] cycl;
        [JsonProperty("Pedestrians")]
        public int[] ped;
        [JsonProperty("Busses")]
        public int[] busje { get; set; }

    }



}