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
        transform.position = StartPos * length;
        transform.position += transform.right * (subNum * 10);
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
        Debug.Log(dutchDirection.start + "starts");
        Debug.Log(dutchDirection.end + "end stats");
        EndPos = dutchDirection.end * length;
    }

    void Applyoffsets()
    {
        this.StartPos += dutchOffsets.StartOffset;
        this.MidPos += dutchOffsets.MidPointOffset;
        this.EndPos += dutchOffsets.EndOffset;

    }

    private void Update()
    {
        Debug.DrawLine(transform.right * (subNum * 10), EndPos, Color.cyan);
    }

    public Vector3 GetMidPosoffset()
    {
        return dutchOffsets.MidPointOffset;
    }
    public Vector3 GetStartPosOffst()
    {
        return dutchOffsets.StartOffset - (transform.forward * 10);
    }
    public Vector3 GetEndPosOffst()
    {
        return dutchOffsets.EndOffset;
    }
}
