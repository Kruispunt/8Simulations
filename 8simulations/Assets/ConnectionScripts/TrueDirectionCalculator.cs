using UnityEngine;

public class TrueDirectionCalculator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static Vector3 GenTurnData(Transform Owntr, Turn turn)
    {
        Vector3 DirectionalVectorReal;


        switch (turn)
        {
            case Turn.right:

                DirectionalVectorReal = (-Owntr.transform.right * 500) + -Owntr.transform.forward * 500;

                break;
            case Turn.left:
                DirectionalVectorReal = (Owntr.transform.right * 500) + -Owntr.transform.forward * 500;

                break;
            case Turn.forward:
                DirectionalVectorReal = -Owntr.transform.forward * 500;

                break;
            default:
                DirectionalVectorReal = -Owntr.transform.forward * 500;
                break;
        }

        return DirectionalVectorReal;

    }
}
