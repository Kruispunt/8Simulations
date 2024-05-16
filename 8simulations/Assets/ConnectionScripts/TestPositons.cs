using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPositons : MonoBehaviour
{

    public Turn turn = Turn.forward;



    public int directionToMove = 0;
    public Vector3 dir;
    public Vector3 right;
    public Vector3 left;

    public Vector3 back;

    public Vector3 endposright;
    public Vector3 endposleft;


    public GameObject objectToMove;
    public GameObject directionPoint;


    // Start is called before the first frame update
    void Start()
    {
        dir =     directionPoint.transform.forward * 500;
        right = directionPoint.transform.right * 500;
        left = -directionPoint.transform.right * 500;
        back = -directionPoint.transform.forward * 500;
        endposright = right + -directionPoint.transform.forward * 500;
        endposleft = left + directionPoint.transform.forward * 500;
}

    // Update is called once per frame
    void Update()
    {

        dir = directionPoint.transform.forward * 500;
        right = directionPoint.transform.right * 500;
        left = -directionPoint.transform.right * 500;
        back = -transform.forward * 500;
        endposright = -right + -directionPoint.transform.forward * 500;
        endposleft = left + directionPoint.transform.forward * 500;
        //objectToMove.transform.position += objectToMove.transform.forward * Time.deltaTime;
        //objectToMove.transform.position = objectToMove.transform.position += directionPoint.transform.forward * Time.deltaTime;

        Debug.DrawLine(directionPoint.transform.position, dir);
        Debug.DrawLine(directionPoint.transform.position, right, Color.red);
        Debug.DrawLine(directionPoint.transform.position, left, Color.blue);
        Debug.DrawLine(directionPoint.transform.position, endposright, Color.white);
        Debug.DrawLine(directionPoint.transform.position, endposleft, Color.black);
        Debug.DrawLine(directionPoint.transform.position, back, Color.yellow);

        Vector3 newPosition = Vector3.MoveTowards(objectToMove.transform.position, endposright, 5 * Time.deltaTime);
        objectToMove.transform.position = newPosition;

        TrueDirectionCalculator.GenTurnData(this.transform, this.turn);
    }


    //public Vector3 GenTurnData(Transform Owntr, Turn turn)
    //{
    //    Vector3 DirectionalVectorReal;


    //    switch (turn)
    //    {
    //        case Turn.right:
                
    //            DirectionalVectorReal = (-transform.right * 500) + -transform.forward * 500;

    //            break;
    //        case Turn.left:
    //            DirectionalVectorReal = (transform.right * 500) + -transform.forward * 500;

    //            break;
    //        case Turn.forward:
    //            DirectionalVectorReal = -transform.forward * 500;

    //            break;
    //        default:
    //            DirectionalVectorReal = -transform.forward * 500;
    //            break;
    //    }

    //    return DirectionalVectorReal;

    //}
    
}
