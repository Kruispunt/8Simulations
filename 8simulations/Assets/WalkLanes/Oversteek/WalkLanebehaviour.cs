
using UnityEngine;

public class WalkLanebehaviour : MonoBehaviour
{
    public SingleDetector detectorLus;
    public float laneStartDistance;
    public float midPointDistance;
    public LampostManager lampostManager;

    private Road laneRoad;
    private ButtonTrigger buttonTrigger;

    // Start is called before the first frame update
    void Start()
    {
        laneRoad = GetComponentInChildren<Road>();
        InitializeButtonTrigger();
    }

    private void InitializeButtonTrigger()
    {
        GameObject triggerObject = Instantiate(new GameObject("ButtonTrigger"), laneRoad.startPosition);


        BoxCollider collider = triggerObject.AddComponent<BoxCollider>();
        collider.isTrigger = true;
        buttonTrigger = triggerObject.AddComponent<ButtonTrigger>();
        buttonTrigger.Setup(this);
        buttonTrigger.OnButtonPressed += Button_OnButtonPressed;
    }

    private void Button_OnButtonPressed(bool pressed)
    {
        detectorLus.Detected = pressed;
    }

    private void OnDisable()
    {
        if (buttonTrigger != null)
        {
            buttonTrigger.OnButtonPressed -= Button_OnButtonPressed;
        }
    }

    public Vector3 GetLaneStartSignal()
    {
        return laneRoad.GetStartPosition().position;
    }

    public Vector3 GetLaneExit()
    {
        return laneRoad.GetEndPosition().position;
    }

    public Vector3 GetLaneStart()
    {
        return laneRoad.GetStartPosition().position;
    }

    public void SetLampLight(int state)
    {
        lampostManager.SetLight(state);
        if (state == 2 && buttonTrigger != null)
        {
            buttonTrigger.ResetButton();
        }
    }

    //public SingleDetector DetectorLus = new SingleDetector();


    ////the local road defenition
    //private Road LaneRoad;

    ////offset to aproach form
    //public float LaneStartdistance;

    //public float MidPointDistance;

    //public LampostManager LampostManager;

    //private ButtonTrigger button;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    LaneRoad = GetComponentInChildren<Road>();

    //    GameObject Trigger = Instantiate(new GameObject(), LaneRoad.startPosition);
    //    BoxCollider collie = Trigger.AddComponent<BoxCollider>();
    //    collie.isTrigger = true;
    //    button = collie.AddComponent<ButtonTrigger>();
    //    button.Setup(this);
    //    button.OnButtonPressed += Button_OnButtonPressed;
    //}

    //private void Button_OnButtonPressed(bool presed)
    //{
    //    if (presed)
    //    {
    //        // Logic for when CanGo is true
    //        DetectorLus.Detected = true;
    //    }

    //}

    //private void OnDisable()
    //{
    //    // Unsubscribe from the event
    //    button.OnButtonPressed -= Button_OnButtonPressed;
    //}



    ////position of traffic light entrance and the near loop
    ////here you will have to wait if there is a traffic light
    //public Vector3 GetLaneStartSignal()
    //{
    //    return LaneRoad.GetStartPosition().position;
    //}

    ////the last position of the lane and thus the exit
    //public Vector3 GetLaneExit()
    //{
    //    return LaneRoad.GetEndPosition().position;
    //}

    ////enter the lane at the start position
    //public Vector3 GetLaneStart()
    //{
    //    return LaneRoad.GetStartPosition().position;
    //}
    ////starts once buttom is pressed

    //public void SetLampLight(int state)
    //{
    //    LampostManager.SetLight(state);
    //    if (state == 2)
    //    {
    //        button.ResetButton();
    //    }
    //}


}
