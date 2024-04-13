using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int routeindex = 1;

    public bool ReachedGoal;

    public float distanceThreshold = 5;
    public Vector3 heading;
    //defaultspeed
    public float speed = 10;

    public Vector3 LocalGoal;
    //rigidbody pyhcis
    public Rigidbody body;

    public ActorPathFinding pad;
    //three points
    public List<ActorPathFinding> Routes;


    public void Setup(Rigidbody rigidbody)
    {
        this.body = rigidbody;
        distanceThreshold = 1.5f;
        getnewGoal();
    }

    public void SetObjective(Vector3 goal)
    {
        this.LocalGoal = goal;
    }


    public void updateID()
    {
        routeindex++;
        getnewGoal();
    }
    public void getnewGoal()
    {
        this.LocalGoal = pad.Getroute(routeindex);
    }



    //move on forward axis
    public void MoveObject()
    {
        //heading = transform.position - LocalGoal;
        float afstand = Vector3.Distance(this.transform.position, LocalGoal);

        if (afstand < distanceThreshold)
        {
            if(routeindex == 1 && pad.watch.CanGo)
            {
                updateID();

            }
            if(routeindex == 2)
            {
                this.gameObject.SetActive(false);
            }

        }
        else
        {

            heading = transform.position - LocalGoal;
            Vector3 direction = Vector3.Normalize(heading);
            body.AddForce(-direction);
            Debug.DrawLine(transform.position, LocalGoal, Color.red);
        }
        Debug.DrawLine(transform.position, LocalGoal, Color.red);

    }

    public void WaitForGreen()
    {
        float distance = Vector3.Distance(this.transform.position, LocalGoal);
        heading = transform.position - LocalGoal;
        Vector3 direction = Vector3.Normalize(heading);

        //Vector3 direction = heading / distance; // This is now the normalized direction.
        //heading = transform.position - LocalGoal;
        body.AddForce(-direction);
        Debug.DrawLine(transform.position, LocalGoal, Color.red);
    }


}
