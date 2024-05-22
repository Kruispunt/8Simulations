
using UnityEngine;

public class LTrigger : MonoBehaviour
{


    public Vector3 DetectorSize;

    public bool IsNear;

    private CarLanebehaviour laanBehaviour;

    public void setup(CarLanebehaviour Laan, bool isnear)
    {
        this.laanBehaviour = Laan;
        this.IsNear = isnear;
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<ActorInfo>().Isprio())
        {
            laanBehaviour.OnDetect(IsNear, true);
            //Debug.Log(this.IsNear + "triggerexit");
        }
        else
        {
            laanBehaviour.OnDetect(IsNear);
        }
        if (other.gameObject.GetComponent<ActorInfo>().IsBus())
        {
            other.gameObject.GetComponent<BussNeumbers>().SetLaneLamp(laanBehaviour.LampostManager.watch);

        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<ActorInfo>().Isprio())
        {
            laanBehaviour.ExitDetected(IsNear, true);
            //Debug.Log(this.IsNear + "triggerexit");
        }
        else
        {
            laanBehaviour.ExitDetected(IsNear);
        }
    }
}
