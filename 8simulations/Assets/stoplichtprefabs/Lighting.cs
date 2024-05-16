
using UnityEngine;

public class Lighting : MonoBehaviour
{
    public Color Color;
    public float distance;
    public float lightIntensity;
    public float LightRange;

    private bool status;

    //huidige staat
    public bool Status
    {
        get { return status; }
        set
        {
            status = value;
            //update the model
            SetState(value);
        }
    }

    public int idx;

    public GameObject spotPrefab; // Reference to your spotlight prefab

    private GameObject createdLight;

    private Light spotLightLink;

    public void setup()
    {
        Vector3 spawnPos = Vector3.up * 20;

        // Instantiate the spotlight prefab
        createdLight = Instantiate(spotPrefab, transform.position, transform.rotation, this.transform);
        createdLight.transform.localPosition = spawnPos;

        createdLight.transform.Rotate(new Vector3(90, 0, 0));
        // Set the spotlight properties
        spotLightLink = createdLight.GetComponent<Light>();
        spotLightLink.type = UnityEngine.LightType.Spot;
        spotLightLink.intensity = lightIntensity;
        spotLightLink.range = LightRange;
        spotLightLink.color = Color;
    }

    public void TurnOffLamp()
    {
        spotLightLink.intensity = 0;

    }
    //this is an toggle 
    public void ToggleLight(bool State)
    {

        status = State;

    }

    private void SetState(bool val)
    {
        //Debug.Log(val);
        if (val )
        {

            spotLightLink.intensity = lightIntensity;
        }
        else
        {
            spotLightLink.intensity = 0;
        }

    }
}
