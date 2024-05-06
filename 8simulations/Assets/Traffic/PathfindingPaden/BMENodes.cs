using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//begin middle end
public class BMENodes : MonoBehaviour
{

    public float length = 500;
    public int directionNum;
    public int type;
    public int subNum;

    public DutchOffsets dutchOffsets;

    public Vector3 StartPos;
    public Vector3 MidPos;
    public Vector3 EndPos;


    public void Setup()
    {
        modPosses(DirectionMaker.GetDutchDirection(directionNum, type));

        Debug.Log("Node Used");
    }

    // Start is called before the first frame update
    void Start()
    {
        modPosses(DirectionMaker.GetDutchDirection(directionNum, type));
        //transform.position = StartPos;
        
    }

    void modPosses(DutchDirection dutchDirection)
    {
        StartPos = dutchDirection.start * length;
        EndPos = dutchDirection.end * length;
    }



}
