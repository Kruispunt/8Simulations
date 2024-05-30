using UnityEngine;

public class FietsLaanBehaviour : MonoBehaviour
{


    public GameObject NearLusF;
    public GameObject FarLusF;

    public SingleDetector DetectorLus = new SingleDetector();
    public float FarLaneDistance = 50.0f;
    public float XOffset = 10;
    public Transform Triggerpos;
    public LaneTriggerBike LaneTriggerBike;

    public LampostManager LampostManager;

    //this is an extra offset added ontop of the farlane and is the true beginning of the road
    public float LaneStartdistance;

    //the local road defenition
    private Road LaneRoad;


    private void Start()
    {
        CreateRequiruiments();
        LaneRoad = GetComponentInChildren<Road>();
        LaneTriggerBike.setup(this, Triggerpos.position);
        //NearLusF.gameObject.transform.position += (NearLusF.transform.forward * LaneStartdistance) + (NearLusF.transform.right * XOffset);
        //LaneTriggerBike.transform.position = NearLusF.transform.position;
        //FarLusF.gameObject.transform.position = NearLusF.transform.position;
        //FarLusF.gameObject.transform.position += FarLusF.transform.forward * FarLaneDistance;

        //NearLusF.transform.position = LaneRoad.startPosition.position;
        //FarLusF.transform.position = LaneRoad.endPosition.position;

    }

    private void CreateRequiruiments()
    {
        //NearLusF = Instantiate(new GameObject());
        //FarLusF = Instantiate(new GameObject());
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
    public Vector3 GetLaneStartSignal()
    {
        return this.NearLusF.transform.position;
    }

    //the last position of the lane and thus the exit
    public Vector3 GetLaneExit()
    {
        return this.NearLusF.transform.position;
    }
    //enter the lane at the start position
    public Vector3 GetLaneStart()
    {
        return FarLusF.transform.position + transform.forward * 30;
    }

    public void SetLampLight(int state)
    {
        LampostManager.SetLight(state);
    }

}
