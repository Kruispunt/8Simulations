using UnityEngine;

public class Ordenogan : MonoBehaviour
{



    Vector3 zero = Vector3.zero;
    public int lengthoffRoad;
    //to and where
    //(00,1)
    //(00,-1)

    //3 dir

    //left 


    //right 


    //forward


    // Start is called before the first frame update
    void Start()
    {

    }

    public void truePos(Transform transform)
    {
        transform.position = zero;

    }

    public Vector3 GoRight()
    {
        return transform.right;
    }

    public Vector3 GoForward()
    {
        return transform.forward;
    }
    public Vector3 GoLeft()
    {
        return -transform.right;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
