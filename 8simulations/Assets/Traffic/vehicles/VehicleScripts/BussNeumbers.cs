using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BussNeumbers : MonoBehaviour
{
    busRoute busRoute = new busRoute();

    public bool Has2Froutes = false;

    int stopsAt = 3;


    public List<Transform> MyRoute;

    public bool isAtFirst = true;

    private void Start()
    {
        List<Vector3> v3list = new List<Vector3>();
        foreach (Transform t in MyRoute)
        {
            v3list.Add(t.position);
        }

        busRoute.block1path.SetLongRoute(v3list);
        if (Has2Froutes)
        {
            isAtFirst = true;


        }
    }





}


public class busRoute
{

    public int tag = 22;
    public bool GoestoNextBlock;
    private bool IsAtFirstBlock = true;

    public ActorPathFinding block1path;
    public Movement block1Movement;
    public ActorPathFinding block2path;
    public Movement block2Movement;


    public void OnCreation()
    {
        IsAtFirstBlock=true;
        block1Movement.FinishedWalk += Block1Movement_FinishedWalk;


    }

    private void Block1Movement_FinishedWalk()
    {
        if (IsAtFirstBlock)
        {
            IsAtFirstBlock=false;
            block1Movement.FinishedWalk -= Block1Movement_FinishedWalk;
            block2Movement.FinishedWalk += Block2Movement_FinishedWalk;
        }
    }

    private void Block2Movement_FinishedWalk()
    {
        block2Movement.FinishedWalk -= Block2Movement_FinishedWalk;

        
    }

    private void OnDisable()
    {

        block1Movement.FinishedWalk -= Block1Movement_FinishedWalk;
        block2Movement.FinishedWalk -= Block2Movement_FinishedWalk;
    }
}
