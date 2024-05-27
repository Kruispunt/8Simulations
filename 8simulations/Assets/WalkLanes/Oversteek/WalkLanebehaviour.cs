
using UnityEngine;

public class WalkLanebehaviour : MonoBehaviour
{
    public SingleDetector detectorLus;
    public float laneStartDistance;
    public float midPointDistance;

    public GameObject DetectionNear;
    public SingleDetector DetectorLus = new SingleDetector();

    public LampostManager lampostManager;
    public bool IsMiddlePoint = false;
    private Road laneRoad;
    private ButtonTrigger buttonTrigger;
    public LaneTriggerActor LaneTrigger;


    // Start is called before the first frame update
    void Start()
    {
        laneRoad = GetComponentInChildren<Road>();
        LaneTrigger.setup(this, laneRoad.startPosition.position);

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
        return laneRoad.GetStartPosition().position;
    }

    public Vector3 GetLaneExit()
    {
        return laneRoad.GetEndPosition().position;
    }

    public Vector3 GetLaneStart()
    {
        return laneRoad.GetStartPosition().position - laneRoad.transform.forward * 50;
    }

    public void SetLampLight(int state)
    {

        if (lampostManager == null)
        {
            Debug.Log("lampostManager is null");
            this.lampostManager = GetComponentInChildren<LampostManager>();
        }
        else
        {
            Debug.Log("lamplight" + lampostManager.name);
            lampostManager.SetLight(state);
            if (state == 2 && buttonTrigger != null)
            {
                buttonTrigger.ResetButton();
            }
        }

    }



}
