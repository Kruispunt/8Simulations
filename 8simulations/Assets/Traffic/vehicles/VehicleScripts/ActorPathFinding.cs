using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorPathFinding : MonoBehaviour
{

    private int actornr;
    public LampWatch watch;

    public bool DoubleRoute = false;

    public Vector3 LinePosition;
    public bool IsWaitingInLine = false;





    public List<Vector3> routelist = new List<Vector3>();


    public void Setroute(Vector3 b, Vector3 m, Vector3 e)
    {

        routelist = new List<Vector3> { b, m, e };
        
    }
    public void Setroute(Vector3 b, Vector3 m, Vector3 offsettedm, Vector3 e)
    {

        routelist = new List<Vector3> { b, m, offsettedm, e };

    }
    public void SetLongRoute(List<Vector3> route)
    {
        routelist = route;
    }
    public void SetLongRoute(List<Vector3> route, bool isDoubleroute)
    {
        routelist = route;
        DoubleRoute = isDoubleroute;
    }

    public bool HasOffsetedPath()
    {
        if (routelist.Count == 4)
        {
            return true;
        }
        return false;
    }

    public Vector3 GetNextPos(int index)
    {
        
        return this.routelist[index];
    }

    public bool IsFinished(int index)
    {
        Debug.Log(index);
        Debug.Log(routelist.Count);
        Debug.Log((routelist.Count <= index));
        if(routelist.Count  <= index)
        {
            Debug.Log("not finished");
           
            return false;
        }
        else
        {
            return true;
        }
    }


}
