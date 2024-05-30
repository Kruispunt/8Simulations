using UnityEngine;

public class DutchOffsets : MonoBehaviour
{


    public Vector3 StartOffset;
    public Vector3 MidPointOffset;
    public Vector3 EndOffset;

    public DutchOffsets(Vector3 startOffset, Vector3 midPointOffset, Vector3 endOffset)
    {
        StartOffset = startOffset;
        MidPointOffset = midPointOffset;
        EndOffset = endOffset;
    }


    public Vector3 GetMidPosoffset()
    {
        return MidPointOffset;
    }
    public Vector3 GetStartPosOffst()
    {
        return StartOffset;
    }
    public Vector3 GetEndPosOffst()
    {
        return EndOffset;
    }


}
