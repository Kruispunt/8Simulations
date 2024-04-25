using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pyramaze : MonoBehaviour
{

    public int NodesPerDir = 8;

    public float longitude = 50;

    // block a out == (0,0,1)

    //4 =
    //4-


    public Vector3 E = new Vector3(-1, 0, 1);

    public Vector3 EE = new Vector3(2, 0, 400);

    public Vector3 EEE = new Vector3(0, 0, 3);


  

    public Vector3 East = Vector3.back;


    public Vector3[] easters = new Vector3[8];


    // Start is called before the first frame update
    void Start()
    {



        for (int i = 1; i  < 4; i++)
        {
            easters[i] = new Vector3(0, 0, i);
        }
        for (int i = 1; i < 4; i++)
        {
            easters[i + 4] = new Vector3(0, 0, -i);
        }



    }

    // Update is called once per frame
    void Update()
    {
        

        for ( int i = 0;i < 4; i++)
        {
            Debug.DrawLine(E + (E * longitude), EE * longitude, Color.yellow);
        }
    }
}
