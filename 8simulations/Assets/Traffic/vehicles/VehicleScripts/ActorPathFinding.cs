using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPathFinding : MonoBehaviour
{
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


}
