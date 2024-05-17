
using JetBrains.Annotations;
using System;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public int routeindex = 0;
    public bool CanUpdate = false;
    public bool Hasoffsetstart = false;
    bool isWaiting = false;

    bool IsBus = false;
    bool IsGreenLight;

    public event Action FinishedWalk;
    public float speed = 10;
    public float timeSinceStarted;
    public float percentageComplete;
    public float duration = 3.0f; // Duration of the movement in seconds
    public float durationoff = 1.0f; // Duration of the movement in seconds
    private float startTime; // Time when the movement started
    private float lastPercentageComplete;
    public Vector3 LocalGoal;
    public Vector3 startpos;
    //rigidbody pyhcis
    public Rigidbody body;

    public ActorPathFinding pad;
    public void Setup()
    {
        pad.watch.OnCanGoChanged += Watch_OnCanGoChanged;
        this.CanUpdate = false;
        Hasoffsetstart = pad.HasOffsetedPath();
        routeindex = -1;
        SmartUpdate();
    }
    public void SetRandomDuration(float duration)
    {

    }


    public void SetObjective(Vector3 goal)
    {
        this.LocalGoal = goal;
    }

    public Vector3 GetNewLocalGoal()
    {
        return pad.GetNextPos(routeindex);
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
        RestTimer();
        routeindex++;
        //check if this is the end of the path
        //if not finished get next point
        if (pad.IsFinished(routeindex))
        {
            Debug.Log("not the end");
            this.LocalGoal = GetNewLocalGoal();

            this.CanUpdate = true;
        }
        else
        {

            //done
            //stop now
            this.CanUpdate = false;
            Debug.Log("done");
            FinishedWalk.Invoke();
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
        if (hasBus)
        {
            if (IsBus)
            {
                this.IsGreenLight = cango;
            }

            this.IsGreenLight = false;
        }
        else
        {
            this.IsGreenLight = cango;
        }

    }

    private void OnDisable()
    {
        // Unsubscribe from the event
        pad.watch.OnCanGoChanged -= Watch_OnCanGoChanged;
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
