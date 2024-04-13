using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPathFinding : MonoBehaviour
{
    public int index = 0;


    public Vector3 begin;
    //mid is the point where the traffic light stands
    public Vector3 mid;

    public Vector3 end;

    public LampWatch watch;

    public void Setroute(Vector3 b, Vector3 m, Vector3 e)
    {
        this.begin = b; 
        this.mid = m; 
        this.end = e;
    }

    public Vector3 Getroute(int id)
    {
        switch (id)
        {
            case 1: 
                return this.mid;
            case 2: 
                return this.end;

        }

        return this.begin;
    }


}
