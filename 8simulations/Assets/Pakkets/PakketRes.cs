using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace recieverpakket
{


    public class SignalGroup
    {
        [JsonProperty("1")]
        public blocksMsg blocksMsg { get; set; }
        [JsonProperty("2")]
        public blocksMsg2 blocksMsg2 { get; set; }
    }

    [Serializable]
    public class blocksMsg
    {
        [JsonProperty("A")]
        public LightNormalLanemsg A { get; set; }

        [JsonProperty("B")]
        public LightFullLanemsg B { get; set; }

        [JsonProperty("C")]
        public LightCarLanemsg C { get; set; }


    }
    [Serializable]
    public class blocksMsg2
    {
        [JsonProperty("D")]
        public LightCarLanemsg D { get; set; }

        [JsonProperty("E")]
        public LightFullLanemsg E { get; set; }

        [JsonProperty("F")]
        public LightNormalLanemsg F { get; set; }


    }

    [Serializable]
    public class LightCarLanemsg
    {
        [JsonProperty("Cars")]
        public List<int> Cars;

    }

    [Serializable]
    public class LightNormalLanemsg
    {
        [JsonProperty("Cars")]
        public List<int> Cars;
        [JsonProperty("Cyclists")]
        public List<int> bikers;
        [JsonProperty("Pedestrians")]
        public List<int> Walkers;

    }

    [Serializable]
    public class LightFullLanemsg
    {
        [JsonProperty("Cars")]
        public List<int> Cars;
        [JsonProperty("Cyclists")]
        public List<int> bikers;
        [JsonProperty("Pedestrians")]
        public List<int> Walkers;

        [JsonProperty("Busses")]
        public List<int> busje { get; set; }

    }



}