using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VerkeersLight : MonoBehaviour
{

    public int number;
    public int subnumber;

    public LampostManager manager;

    public DirectieReal Directie = new DirectieReal();

    public OffsetAndLane lane = new OffsetAndLane();

    public Vector3 positionLane;

    public GameObject LanelocationHolder;



    public void setNumber(int number)
    {
        this.number = number;
        Directie.setDirectionReal(number);
        lane.setup(this.transform);
        positionLane = lane.StartposVoorRij;

    }
    public void ActivatelamPostManager()
    {
        manager = this.GetComponent<LampostManager>();
        manager.SetUpLights();
    }

    public Vector3 GetLanePoint(SimuAuto car)
    {

        return lane.ParkInLine(car);

    }

    public Vector3 getStartposRij()
    {
        return lane.StartposVoorRij;
    }


    public Vector3 getlastPosInRow(SimuAuto car)
    {
        return lane.ParkInLine(car);
    }

    public void removeFromQueueueueu(SimuAuto car)
    {
        lane.RemoveVehicleFromList(car);
    }

    public void Update()
    {
        Debug.DrawLine(transform.position, lane.StartposVoorRij);
    }

}
