using UnityEngine;

public class Road : MonoBehaviour
{

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


}
