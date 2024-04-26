using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkLanebehaviour : MonoBehaviour
{


    public SingleDetector DetectorLus = new SingleDetector();


    //the local road defenition
    private Road LaneRoad;

    //offset to aproach form
    public float LaneStartdistance;

    public float MidPointDistance;

    public LampostManager LampostManager;

    // Start is called before the first frame update
    void Start()
    {
        LaneRoad = GetComponentInChildren<Road>();
        StartCoroutine(randomstate(5));

    }

    //position of traffic light entrance and the near loop
    //here you will have to wait if there is a traffic light
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
        return LaneRoad.GetStartPosition().position + (Vector3.forward * LaneStartdistance);
    }

    public SingleDetector GetDetector()
    {
        return DetectorLus;
    }
    //starts once buttom is pressed
    public void ButtonPressed()
    {
        DetectorLus.Detected = true;
    }

    //only call this when the light is on green
    public void ResetPress()
    {
        DetectorLus.Detected = false;
    }

    public void SetLampLight(int state)
    {
        LampostManager.SetLight(state);
    }
    IEnumerator randomstate(int timeInSec)
    {
        //refresh simulation state 5 secs
        yield return new WaitForSeconds(timeInSec);
        LampostManager.SetLight(Random.Range(0, 2));
        StartCoroutine(randomstate(timeInSec));
    }

}