using UnityEngine;

public class CarLanebehaviour : MonoBehaviour
{

    //public GameObject Parent;
    public bool HasOffsetNearlusFromStart = false;
    public float EntranceOffset = 0;
    public Vector3 OffsettedStartPos;


    public bool IsMiddlePoint = false;
    //public GameObject triggerNear;
    //public GameObject triggerFar;

    public GameObject ExitNode;
    //signal detector at the signal
    public LTrigger NearLus;
    //signal detector far from signal
    public LTrigger FarLus;

    public CarSensormsg DetectorLus = new CarSensormsg();

    //public BMENodes nodes;

    //offset farlust from the signal light
    public float FarLaneDistance;
    //this is an extra offset added ontop of the farlane and is the true beginning of the road
    public float LaneStartdistance;

    //public float XOffset = 5;
    //the local road defenition
    private Road LaneRoad;

    public LampostManager LampostManager;


    private void Start()
    {
        LaneRoad = GetComponentInChildren<Road>();
        Debug.Log("road");

        FarLus.gameObject.transform.position += FarLus.transform.forward * FarLaneDistance;
        NearLus.setup(this, true);
        FarLus.setup(this, false);
        LaneRoad.startPosition = FarLus.transform;

        if (ExitNode != null)
        {
            LaneRoad.endPosition = ExitNode.transform;
        }

        if (HasOffsetNearlusFromStart)
        {
            OffsettedStartPos = NearLus.transform.position + NearLus.transform.forward * EntranceOffset;
        }

    }

    public void SetAsmiddlePoint()
    {
        this.IsMiddlePoint = true;
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

        return this.NearLus.transform.position;

    }


    //call this before turning
    public Vector3 GeLaneExit()
    {
        return this.OffsettedStartPos;
    }

    //the last position of the lane and thus the exit
    public Vector3 GetLaneExit()
    {
        //return nodes.EndPos;
        return LaneRoad.GetEndPosition().position;
    }

    //enter the lane at the start position
    public Vector3 GetLaneStart()
    {
        return FarLus.transform.position;
    }

    public CarSensormsg getTriggerInfo()
    {
        return this.DetectorLus;
    }
    public Vector3 GetSpwanPos()
    {
        return FarLus.transform.position + FarLus.transform.forward * FarLaneDistance + transform.forward * 3000 + transform.up * 1000;
    }
}
