using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VerkeerslichtBoulder : MonoBehaviour
{
    public GameObject Verkeerslamp;
    public bool SetupDone = false;

    public float distance = 50;
    List<GameObject> verkeersLights = new List<GameObject>();
    public List<VerkeersLight> verkeersLightsscrips = new List<VerkeersLight>();
    // Start is called before the first frame update

    //public void Setup(int id, int state)
    //{
    //    //verkeersLights.Add(Instantiate(Verkeerslamp, this.transform.position, Quaternion.identity));
    //    //verkeersLightsscrips.Add(verkeersLights[id - 1].AddComponent<VerkeersLight>());
    //    //verkeersLightsscrips[id - 1].setNumber(id);
    //    //Debug.Log(id - 1);
    //    for (int i = 0; i < 13; i++)
    //    {
    //        verkeersLights.Add(Instantiate(Verkeerslamp, transform.position, Quaternion.identity));
    //        verkeersLightsscrips.Add(verkeersLights[i].AddComponent<VerkeersLight>());
    //        verkeersLightsscrips[i].setNumber(i);
    //    }
    //    foreach (VerkeersLight verkeers in verkeersLightsscrips)
    //    {
    //        setPosition(verkeers);
    //    }
    //    SetupDone = true;

    //}

    public void UpdateFromControl(int id, int state)
    {

        setCommunicatedState(id, state);
    }

    public void setCommunicatedState(int id, int state)
    {
        verkeersLightsscrips[id - 1].manager.SetLight(state);
    }
    void Start()
    {

        for (int i = 0; i < 13; i++)
        {
            verkeersLights.Add(Instantiate(Verkeerslamp, transform.position, Quaternion.identity));
            verkeersLightsscrips.Add(verkeersLights[i].AddComponent<VerkeersLight>());
            verkeersLightsscrips[i].setNumber(i);
        }
        foreach (VerkeersLight verkeers in verkeersLightsscrips)
        {
            setPosition(verkeers);
        }

    }


    public void setPosition(VerkeersLight light)
    {
        light.transform.position = light.Directie.start * distance;

        light.transform.position += (light.Directie.end * 5);
        light.transform.LookAt(light.Directie.end);
        light.ActivatelamPostManager();
    }
}
