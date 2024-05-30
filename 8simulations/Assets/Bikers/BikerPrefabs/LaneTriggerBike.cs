
using UnityEngine;

public class LaneTriggerBike : MonoBehaviour
{

    private FietsLaanBehaviour laanBehaviour;

    public void setup(FietsLaanBehaviour fietsLaan, Vector3 triggerPos)
    {
        this.laanBehaviour = fietsLaan;
        //this.transform.position = triggerPos;
    }

    public void OnTriggerEnter(Collider other)
    {
        laanBehaviour.OnDetect();
        Debug.Log(other.gameObject.name);
        Debug.Log("trigger entered");
    }

    public void OnTriggerExit(Collider other)
    {
        laanBehaviour.ExitDetected();
    }

}

