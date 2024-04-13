using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{



    public Vector3 DirectionData;


    public Transform startPosition;

    public Transform endPosition;


    public Transform GetStartPosition()
    {
        return startPosition;
    }
    public Transform GetEndPosition()
    {
        return endPosition;
    }

   
    // Update is called once per frame
    void Update()
    {


        Debug.DrawLine(startPosition.position, endPosition.position);
        
    }
}
