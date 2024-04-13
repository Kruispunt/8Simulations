using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FietsLaanBehaviour : MonoBehaviour
{


    public SingleDetector DetectorLus = new SingleDetector();

    public Transform Triggerpos;
    public LaneTriggerBike LaneTriggerBike;


    private void Start()
    {
        LaneTriggerBike.setup(this, Triggerpos.position);
    }

    public void OnDetect()
    {
        DetectorLus.Detected = true;
    }
    public void ExitDetected()
    {
        DetectorLus.Detected = false;
    }

    public SingleDetector GetDetector()
    {
        return this.DetectorLus;
    }

    public void Update()
    {
        Debug.Log(DetectorLus.Detected.ToString());
    }

}
