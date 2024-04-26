using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarLanebehaviour : MonoBehaviour
{

    public GameObject Parent;

    public GameObject triggerNear;
    public GameObject triggerFar;

    //signal detector at the signal
    public LTrigger NearLus;
    //signal detector far from signal
    public LTrigger FarLus;

    public CarSensormsg DetectorLus = new CarSensormsg();

    public BMENodes nodes;

    //offset farlust from the signal light
    public float FarLaneDistance;
    //this is an extra offset added ontop of the farlane and is the true beginning of the road
    public float LaneStartdistance;
    //the local road defenition
    private Road LaneRoad;

    public LampostManager LampostManager;


    private void Start()
    {
        LaneRoad = GetComponentInChildren<Road>();
        Debug.Log("road");
        nodes.Setup();
        triggerFar.transform.position = nodes.EndPos;
        NearLus.transform.position = this.transform.position + nodes.GetMidPosoffset();
        NearLus.gameObject.transform.position = nodes.MidPos;
        FarLus.gameObject.transform.position = nodes.StartPos;
        NearLus.setup(this, true);
        FarLus.setup(this, false);
        LaneRoad.startPosition = FarLus.transform;
        RealPos();
        //LaneRoad.endPosition = FarLus.transform;
        //StartCoroutine(randomstate(5));
    }

    private void RealPos()
    {
        Parent.transform.position = nodes.StartPos;
    }

    public Vector3 GetDutchBeginPos()
    {
        return nodes.StartPos;
    }

    public Vector3 GetDutchEndPost()
    {
        return nodes.EndPos;
    }
    public void OnDetect(bool isnear)
    {
        if (isnear)
        {
            DetectorLus.DetectNear = true;
        }
        else
        {
            DetectorLus.DetectFar = true;
        }
    }
    public void OnDetect(bool isnear, bool IsprioVehicle)
    {
        if (isnear)
        {
            DetectorLus.DetectNear = true;
            DetectorLus.PrioCar = true;
            Debug.Log("detected priocar on enter");
        }
        else
        {
            DetectorLus.DetectFar = true;
            DetectorLus.PrioCar = true;
            Debug.Log("detected priocar on enter");
        }
    }
    public void ExitDetected(bool isnear)
    {
        if (isnear)
        {
            DetectorLus.DetectNear = false;
        }
        else
        {
            DetectorLus.DetectFar = false;
        }
    }
    public void ExitDetected(bool isnear, bool IsprioVehicle)
    {
        if (isnear)
        {
            DetectorLus.DetectNear = false;
            DetectorLus.PrioCar = false;
            Debug.Log("detected priocar leaving signalgroup");
            //Debug.Log(LampostManager.GetLightState());
            //LampostManager.SetLight(Random.Range(0,2));
        }
        else
        {
            DetectorLus.DetectFar = false;
        }
    }
    public void SetLampLight(int state)
    {
        LampostManager.SetLight(state);
    }


    //position of traffic light entrance and the near loop
    //here you will have to wait if there is a traffic light
    public Vector3 GetLaneStartSignal()
    {
        return nodes.MidPos;
        return LaneRoad.GetStartPosition().position;
    }

    //the last position of the lane and thus the exit
    public Vector3 GetLaneExit()
    {
        return nodes.EndPos;
        return LaneRoad.GetEndPosition().position;
    }

    //enter the lane at the start position
    public Vector3 GetLaneStart()
    {
        return nodes.StartPos;
        return FarLus.transform.position + (Vector3.forward * LaneStartdistance);
    }

    public CarSensormsg getTriggerInfo()
    {
        return this.DetectorLus;
    }

    public void Update()
    {
        //Debug.Log(DetectorLus.Detected.ToString());
    }

    IEnumerator randomstate(int timeInSec)
    {
        //refresh simulation state 5 secs
        yield return new WaitForSeconds(timeInSec);
        LampostManager.SetLight(Random.Range(0, 2));
        StartCoroutine( randomstate(timeInSec));
    }
}