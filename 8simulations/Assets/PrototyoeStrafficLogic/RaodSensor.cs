using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaodSensor : MonoBehaviour
{

    public InductionGroup LocalController;

    //nothing detected
    public bool CurentState = false;

    //scale
    public Vector3 LoopSize;
    /// <summary>
    //where is the loop
    /// </summary>
    public Vector3 Location;


    //vehicle enters detection zone
   public void ToggleTrue()
    {
        this.CurentState = true;
    }

}
