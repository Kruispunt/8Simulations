using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimuAuto : MonoBehaviour
{


    //alleen nog een waarde nodig
    public int waarde;


    public Vector3 PlaceToPark;

    public float speed;

    //lengte van het voertuig
    public float length;

    //huidige plek waar hij staat
    public VerkeersLight stopllicht;

    public Movement Movement;

    public VehicleState state;

    private void Start()
    {
        state = VehicleState.Driving;

        Movement = this.gameObject.GetComponent<Movement>();

        Movement.Setup(this.GetComponent<Rigidbody>());
        SetPlaceToPark(stopllicht);
        Movement.SetObjective(stopllicht.lane.ParkInLine(this));
        //Movement.SetObjective(PlaceToPark);
    }

    //set a place to park 
    //use the assigned stoplicht to do this
    public void SetPlaceToPark(VerkeersLight stopllicht)
    {
        this.stopllicht = stopllicht;
        PlaceToPark = stopllicht.GetLanePoint(this);
        Movement.SetObjective(PlaceToPark);
    }

    public void MoveAndPark(float threshold)
    {
        float afstand = Vector3.Distance(this.transform.position, stopllicht.getlastPosInRow(this));

        if (afstand < threshold)
        {
            this.state = VehicleState.Waiting;

        }
        else
        {
            this.state = VehicleState.Driving;

        }

    }

    public void Update()
    {
        StateUpdate();
    }
    //call this to update the object state
    //test for now
    public void StateUpdate()
    {
        if (this.state == VehicleState.Driving)
        {

            Movement.MoveObject();

            if (Movement.ReachedGoal)
            {
                this.state = VehicleState.Stopping;
            }
        }
        if(this.state == VehicleState.Stopping)
        {
            this.state = VehicleState.Waiting;
        }
        if(this.state == VehicleState.Waiting)
        {
            //Debug.Log("waiting voor groen");
            Movement.WaitForGreen();
            if (stopllicht.manager.IsGreenLight())
            {
                this.Movement.SetObjective(Vector3.zero);
                this.state = VehicleState.Driving;
            }
            
        }

    }

    public void ProcessMovement(float threshold)
    {

        //bereken de afstand
        float afstand = Vector3.Distance(this.transform.position, stopllicht.getStartposRij());

        if (afstand < threshold)
        {
            //haal zelf uit lijst
            stopllicht.removeFromQueueueueu(this);
        }


    }







}