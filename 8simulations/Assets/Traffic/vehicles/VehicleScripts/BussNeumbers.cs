using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class BussNeumbers : MonoBehaviour
{

    public List<int> placesToWaitForLight;

    public Movement movement;

    public bool Has2Froutes = false;

    public int LijnNum = 0;



    //public List<Vector3> MyRoute = new List<Vector3>();
    public List<Transform> MyRoute = new List<Transform>();

    public bool isAtFirst = false;


    private void Start()
    {
        Setup(new List<Vector3>(), false);
    }

    public void Setup(List<Vector3> route, bool hasTwoRoutes)
    {

        List<Vector3> routes = new List<Vector3>();

        //route.AddRange(MyRoute.Select(n => n.transform.position));
        routes.AddRange(MyRoute.Select(n => n.transform.position));
        movement.pad.SetLongRoute(routes);
        this.Has2Froutes = hasTwoRoutes;
        if (hasTwoRoutes)
        {

            placesToWaitForLight.Add(3);
            placesToWaitForLight.Add(5);
            isAtFirst = true;


        }
    }
    //private void Start()
    //{

    //    movement.pad.SetLongRoute(MyRoute);
    //    if (Has2Froutes)
    //    {

    //        placesToWaitForLight.Add(3);
    //        placesToWaitForLight.Add(5);
    //        isAtFirst = true;


    //    }
    //}

    public void SetLaneLamp(LampWatch watch)
    {
        movement.SetNewPadLink(watch);
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
