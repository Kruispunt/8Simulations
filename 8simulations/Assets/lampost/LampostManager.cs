using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LampostManager : MonoBehaviour
{
    //the internal behaviour for logic related stuff
    public ColourLogic ColourLogic;


    public List<Lighting> lightings = new List<Lighting>();

    public void SetUpLights()
    {
        lightings.AddRange(this.GetComponentsInChildren<Lighting>());

        foreach (var lighting in lightings)
        {
            lighting.setup();
        }
        ConfigureLogic();

        AddLightsToLogic(lightings);
        ColourLogic.StartLamp();

    }
    //called on setup
    public void ConfigureLogic()
    {
        ColourLogic = this.AddComponent<ColourLogic>();
        ColourLogic.setup(lightings.Count - 1);
    }

    public void AddLightsToLogic(List<Lighting> lightings)
    {
        foreach (var lighting in lightings)
        {
            ColourLogic.AddItemToLogicM(lighting);
        }
        
    }

    public void SetLight(int index)
    {
        ColourLogic.UpdateState(index);
    }
    public int GetLightState()
    {
        return ColourLogic.CurrentState;
    }
    public bool IsGreenLight()
    {
        if(ColourLogic.CurrentState == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
