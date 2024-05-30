using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using UnityEngine;

public class FromControllerPakket : MonoBehaviour
{

    public blocksMsgFromControl blockgen()
    {
        blocksMsgFromControl blocksMsgFromControl = new blocksMsgFromControl();

        return new blocksMsgFromControl();
    }
    //this is what the simulator recieves

    [Serializable]
    public class blocksMsgFromControl
    {
        [JsonProperty("A")]
        public blockStateFromControl A { get; set; }

        [JsonProperty("B")]
        public blockStateBusFromControl B { get; set; }

        [JsonProperty("C")]
        public blockStateCarOnlyFromControl C { get; set; }

        [JsonProperty("D")]
        public blockStateCarOnlyFromControl D { get; set; }

        [JsonProperty("E")]
        public blockStateBusFromControl E { get; set; }

        [JsonProperty("F")]
        public blockStateFromControl F { get; set; }

    }

    [Serializable]
    public class blockStateFromControl
    {

        [JsonProperty("Cars")]
        public List<int> CarLampState { get; set; }

        [JsonProperty("Cyclists")]
        public List<int> BikeLampState { get; set; }
        [JsonProperty("Pedestrians")]
        public List<int> PedestrianLampState { get; set; }

    }
    [Serializable]
    public class blockStateCarOnlyFromControl
    {
        [JsonProperty("Cars")]
        public List<int> CarLampState { get; set; }
    }

    [Serializable]
    public class blockStateBusFromControl
    {
        [JsonProperty("Cars")]
        public List<int> CarLampState { get; set; }

        [JsonProperty("Cyclists")]
        public List<int> BikeLampState { get; set; }
        [JsonProperty("Pedestrians")]
        public List<int> PedestrianLampState { get; set; }
        [JsonProperty("Busses")]
        public List<int> BusLampState { get; set; }

    }

}
