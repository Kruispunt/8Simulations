using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.Events;



[System.Serializable]
public class CustomEventSys : UnityEvent<bool>
{

    public CustomEventSys onCustomEvent;
}
