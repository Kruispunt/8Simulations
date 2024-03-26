using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public bool ReachedGoal;

    public float distanceThreshold = 5;
    public Vector3 heading;
    //defaultspeed
    public float speed = 10;

    public Vector3 LocalGoal;
    //rigidbody pyhcis
    public Rigidbody body;

    


    public void Setup(Rigidbody rigidbody)
    {
        this.body = rigidbody;
        distanceThreshold = 1.5f;
    }

    public void SetObjective(Vector3 goal)
    {
        this.LocalGoal = goal;
    }

    //move on forward axis
    public void MoveObject()
    {
        //heading = transform.position - LocalGoal;
        float afstand = Vector3.Distance(this.transform.position, LocalGoal);

        if (afstand < distanceThreshold)
        {

            ReachedGoal = true;
            LocalGoal = this.transform.position;
        }
        else
        {
            //float distance = heading.magnitude;
            //heading = transform.position - LocalGoal;
            //Vector3 direction = heading / distance; // This is now the normalized direction.
            float distance = Vector3.Distance(this.transform.position, LocalGoal);
            heading = transform.position - LocalGoal;
            Vector3 direction = Vector3.Normalize(heading);
            //heading = transform.position - LocalGoal;
            body.AddForce(-direction);
            Debug.DrawLine(transform.position, LocalGoal, Color.red);
        }
        //float distance = heading.magnitude;
        //Vector3 direction = heading / distance; // This is now the normalized direction.

        //body.velocity = transform.forward * speed;
        //body.AddForce(-direction);
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
