using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FietsLaanBehaviour : MonoBehaviour
{


    public SingleDetector DetectorLus = new SingleDetector();

    public Transform Triggerpos;
    public LaneTriggerBike LaneTriggerBike;

    public LampostManager LampostManager;

    //this is an extra offset added ontop of the farlane and is the true beginning of the road
    public float LaneStartdistance;

    //the local road defenition
    private Road LaneRoad;


    private void Start()
    {
        LaneRoad = GetComponentInChildren<Road>();
        Debug.Log("road");
        LaneTriggerBike.setup(this, Triggerpos.position);
    }

    public void OnDetect()
    {
        DetectorLus.Detected = true;
        Debug.Log("detected bike on enter");
    }
    public void ExitDetected()
    {
        DetectorLus.Detected = false;
        Debug.Log("detected bike on exit");
    }

    public SingleDetector GetDetector()
    {
        return this.DetectorLus;
    }

    public Vector3 GetLaneStartSignal()
    {
        return LaneRoad.GetStartPosition().position;
    }

    //the last position of the lane and thus the exit
    public Vector3 GetLaneExit()
    {
        return LaneRoad.GetEndPosition().position;
    }
    //enter the lane at the start position
    public Vector3 GetLaneStart()
    {
        return GetLaneStartSignal() + (Vector3.forward * LaneStartdistance);
    }


}
