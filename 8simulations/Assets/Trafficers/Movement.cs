
using JetBrains.Annotations;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public int routeindex = 0;
    public bool CanUpdate = false;
    public bool Hasoffsetstart = false;
    bool isWaiting = false;
    public bool IsBus = false;
    bool IsGreenLight;

    public event Action FinishedWalk;
    public float Maxspeed = 10;
    public float timeSinceStarted;
    public float percentageComplete;
    public float ScanPosition = 5;
    public float duration = 3.0f; // Duration of the movement in seconds
    public float durationoff = 1.0f; // Duration of the movement in seconds
    private float startTime; // Time when the movement started
    private float lastPercentageComplete;
    public Vector3 LocalGoal;
    public Vector3 startpos;
    private Vector3 TrueGoal;
    //rigidbody pyhcis
    public Rigidbody body;

    public ActorPathFinding pad;

    public vehicleDetector vehicleDetector;

    private void Start()
    {
        if (IsBus)
        {
            this.GetComponentInParent<Transform>().transform.position += this.GetComponentInParent<Transform>().transform.up * 5;

            vehicleDetector = this.AddComponent<vehicleDetector>();
            this.vehicleDetector.OnVehcleDetected += VehicleDetector_OnVehcleDetected;
            this.CanUpdate = false;;
            routeindex = -1;
            SmartUpdate();
        }
    }

    public void Setup()
    {
        this.GetComponentInParent<Transform>().transform.position += this.GetComponentInParent<Transform>().transform.up * 5;
        //LayerMask myNewLayerMask = 1 << LayerMask.NameToLayer("Actor");
        //this.gameObject.layer = LayerMask.NameToLayer("Actor");
        vehicleDetector =  this.AddComponent<vehicleDetector>();
        //this.vehicleDetector = Instantiate(vehicleDetector, this.transform.position + this.transform.forward * ScanPosition, this.transform.rotation);
        pad.watch.OnCanGoChanged += Watch_OnCanGoChanged;
        //this.vehicleDetector.OnVehcleDetected += VehicleDetector_OnVehcleDetected;
        this.CanUpdate = false;
        Hasoffsetstart = pad.HasOffsetedPath();
        routeindex = -1;
        SmartUpdate();
    }

    private void VehicleDetector_OnVehcleDetected(bool detected)
    {
        if(detected)
        {

            this.CanUpdate = true;
            this.LocalGoal = this.transform.position;
            startpos = this.transform.position;
            duration = duration + 5;
            //RestTimer();

        }
        else
        {
            //RestTimer();
            this.CanUpdate = true;
            this.LocalGoal = TrueGoal;
        }
    }

    public void SetNewPadLink(LampWatch watch)
    {
        if(pad.watch != null)
        {
            pad.watch.OnCanGoChanged -= Watch_OnCanGoChanged;
        }
        //pad.watch.OnCanGoChanged -= Watch_OnCanGoChanged;
        pad.watch = watch;
        //pad.watch.BusEnteredlane();
        pad.watch.OnCanGoChanged += Watch_OnCanGoChanged;
        pad.watch.BusEnteredlane();
    }
    public void SetNewDuration(float duration)
    {
        this.duration = duration;
    }


    public void SetObjective(Vector3 goal)
    {
        this.LocalGoal = goal;
    }

    public Vector3 GetNewLocalGoal()
    {
        return pad.GetNextPos(routeindex);
    }

    private void BusLeftLane()
    {
        pad.watch.BussPassedLane();
    }


    private void SmartUpdate()
    {
        //CanUpdate = false;
        if(routeindex + 1 == 2)
        {
            if (!IsGreenLight)
            {
                this.isWaiting = true;
                return;
            }
            else
            {
                this.isWaiting = false;
            }
        }
        if (pad.DoubleRoute)
        {
            if (routeindex + 1 == 5)
            {
                if (!IsGreenLight)
                {
                    this.isWaiting = true;
                    return;
                }
                else
                {
                    this.isWaiting = false;
                }
            }
        }
        RestTimer();
        routeindex++;
        //check if this is the end of the path
        //if not finished get next point
        if (pad.IsFinished(routeindex))
        {
            Debug.Log("not the end");
            this.LocalGoal = GetNewLocalGoal();
            this.TrueGoal = GetNewLocalGoal();

            this.CanUpdate = true;
        }
        else
        {

            //done
            //stop now
            this.CanUpdate = false;
            Debug.Log("done");
            //FinishedWalk.Invoke();
            this.gameObject.SetActive(false);

        }
    }

    private void FixedUpdate()
    {
        if (CanUpdate)
        {
            timebasedmovementX();
        }

    }

    private void Watch_OnCanGoChanged(bool cango, bool hasBus)
    {
        if (isWaiting)
        {
            if (hasBus)
            {
                if (IsBus)
                {
                    this.IsGreenLight = cango;
                    if (cango == true)
                    {
                        //Invoke("BusLeftLane", 4);
                        BusLeftLane();
                        //SmartUpdate();
                        this.isWaiting = false;
                        this.CanUpdate = cango;
                    }
                    return;
                }


                this.IsGreenLight = false;
            }
            else
            {
                this.IsGreenLight = cango;
                this.isWaiting = false;
                this.CanUpdate = cango;
            }
        }


    }

    private void OnDisable()
    {
        // Unsubscribe from the event
        //this.vehicleDetector.OnVehcleDetected -= VehicleDetector_OnVehcleDetected;
        if (pad.watch != null)
        {
            pad.watch.OnCanGoChanged -= Watch_OnCanGoChanged;
        }
        //pad.watch.OnCanGoChanged -= Watch_OnCanGoChanged;
    }



    public void RestTimer()
    {
        startTime = Time.time;
        startpos = transform.position;
        
    }

    public void timebasedmovementX()
    {
        if (isWaiting)
        {
            return;
        }
        float timeDifference = Time.time - startTime;
        percentageComplete = timeDifference / duration;
        if (Hasoffsetstart && routeindex == 3)
        {
            percentageComplete = timeDifference / durationoff;
        }

        // Only call Lerp if there's a need to update the position
        if (percentageComplete != lastPercentageComplete)
        {
            transform.LookAt(LocalGoal);
            
            transform.position = Vector3.Lerp(startpos, LocalGoal, percentageComplete);
            lastPercentageComplete = percentageComplete;
        }



        if (percentageComplete >= 1.0f)
        {
            SmartUpdate();
        }
    }


}
