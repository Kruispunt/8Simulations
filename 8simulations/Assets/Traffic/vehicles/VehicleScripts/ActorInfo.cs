using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorInfo : MonoBehaviour
{
    //if 1 dan prio
    public int Type = 1;


    //is this a prio vehicle
    public bool Isprio()
    {
        if (Type == 1)
        {
            return true;
        }
        return false;
    }
    public bool IsWalker()
    {
        if (Type == 3)
        {
            return true;
        }
        return false;
    }


}
