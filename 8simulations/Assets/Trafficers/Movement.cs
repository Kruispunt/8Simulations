using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int routeindex = 0;

    public bool CanUpdate = false;
    public bool ReachedGoal;

    public float distanceThreshold = 5;
    public Vector3 heading;
    //defaultspeed
    public float speed = 10;

    public Vector3 LocalGoal;
    //rigidbody pyhcis
    public Rigidbody body;

    public ActorPathFinding pad;
    public void Setup()
    {
        SmartUpdate();
        this.CanUpdate = true;
    }
    public void Setup(Rigidbody rigidbody)
    {
        this.body = rigidbody;
        SmartUpdate();
        this.CanUpdate = true;
    }

    public void SetObjective(Vector3 goal)
    {
        this.LocalGoal = goal;
    }

    private void SmartUpdate()
    {
        switch (routeindex)
        {
            case 0:
                this.LocalGoal = pad.begin;
                routeindex++;
                break;
            case 1:
                this.LocalGoal = pad.mid;
                if (pad.watch.CanGo)
                {
                    routeindex++;
                }
                break;
            case 2:
                this.LocalGoal = pad.end;
                break;
            default:
                this.LocalGoal = pad.end;
                break;

        }
    }

    public void FixedUpdate()
    {
        if (this.CanUpdate)
        {
            this.MoveObject();
        }
    }


    //move on forward axis
    public void MoveObject()
    {
        //heading = transform.position - LocalGoal;
        float afstand = Vector3.Distance(this.transform.position, LocalGoal);

        if (afstand < distanceThreshold)
        {
            //routeindex++;
            SmartUpdate();
            body.velocity = Vector3.zero;
        }
        else
        {

            heading = transform.position - LocalGoal;
           
            Vector3 direction = Vector3.Normalize(heading);
            body.AddForce(-(direction * speed * Time.deltaTime), ForceMode.Impulse);
            
        }
        Debug.DrawLine(transform.position, LocalGoal, Color.red);

    }


}
