using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OffsetAndLane
{
    //de nodige positie om in een rij te kunnen staan
    public Vector3 StartposVoorRij;

    //hoeveel wijkt de start post af van de positite van het stoplicht
    public Vector3 StartPosOffset;

    //de lijst van een rij van wachtende voertuigen
    public List<SimuAuto> Wachtendeautos = new List<SimuAuto>();

    public GameObject parkPosLocationobj;


    public void setup(Transform pos)
    {
        //zet het startpunt
        StartposVoorRij = StartPosOffset + pos.transform.localPosition;
        //parkPosLocationobj.transform.position = StartposVoorRij;
    }

    public void AddCarToQue(SimuAuto car)
    {
        Wachtendeautos.Add(car);
    }



    //check how long the queue is 
    public float LineOffset()
    {
        //pak eerst gewwon het aantal en wacht dan
        float offset = Wachtendeautos.Count * Wachtendeautos.First().length;

        return offset;
    }
    public Vector3 ParkInLine(SimuAuto car)
    {
        //zet een nieuw coordinaat
        Vector3 pos = new Vector3(0, 0, 0);

        if (Wachtendeautos.Count > 0)
        {
            //parkeer achter de laatste auto
            pos = Wachtendeautos.Last().transform.position - (Wachtendeautos.Last().transform.forward * Wachtendeautos.Last().length);
        }
        else
        {
            pos = StartposVoorRij;
        }

        //voeg de auto aan de lijst toe
        AddCarToQue(car);

        return pos;

    }

    //haalt de voertuig uit de lijst
    //en de bij behorende waarde
    public void RemoveVehicleFromList(SimuAuto car)
    {
        Wachtendeautos.Remove(car);
    }

    //licht gaat op groen
    public void Releasevehicles()
    {
        //WachtScore = 0;
        foreach (SimuAuto car in Wachtendeautos)
        {
            car.state = VehicleState.Driving;
        }
    }

}
