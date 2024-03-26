using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourLogic : MonoBehaviour
{
    public int CurrentState;

    //this is a bit of the max
    public int Options;
    //list of lamos
    public List<Lighting> LampLights;
    //index starts at zero 
    public void setup(int options)
    {
        Options = options;
        LampLights = new List<Lighting>();
        //default
        CurrentState = 0;
        //StartLamp();

    }
    //insert in order of priority 
    //green yellow orange purple red
    public void AddItemToLogicM(Lighting lighting)
    {
        LampLights.Add(lighting);
    }

    public void UpdateState(int Statenum)
    {
        StatusUpdate(Statenum);

    }
    //tpggle it over
    private void StatusUpdate(int Status)
    {
        LampLights[CurrentState].Status = !LampLights[CurrentState].Status;
        CurrentState = Status;
        LampLights[CurrentState].Status = !LampLights[CurrentState].Status;
    }

    public void ToggleNewStatus()
    {
        if(CurrentState == Options && CurrentState > 0) 
        {
            CurrentState--;
        }
        else
        {
            CurrentState++;
        }

    }

    public void StartLamp()
    {

        foreach(var light in LampLights)
        {
            if (light.idx == CurrentState)
            {
                

            }
            else
            {
                light.TurnOffLamp();
                
            }


        }
        for (int i = 0; i < Options; i++)
        {
            if (LampLights[i].idx == CurrentState)
            {
                LampLights[i].ToggleLight(true);
            }
            else
            {
                LampLights[i].ToggleLight(false);
            }

        }
    }







}
