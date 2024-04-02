using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MockDatagenerator
{


    public Index index;
    // Start is called before the first frame update

    public Index generateIndex()
    {
        index = new Index();

        Index num = new Index();
        num.blocks = new Block[2];

        for (int i = 0; i < num.blocks.Length; i++)
        {
            num.blocks[i] = new Block();
        }
        //index.blocks = new Block[2];

        foreach (var block in num.blocks)
        {
            Sensors[] sensorsmock = new Sensors[2];
            for (int i = 0; i < sensorsmock.Length; i++)
            {
                sensorsmock[i] = new Sensors();
                sensorsmock[i].State = true;
                sensorsmock[i].Name = i.ToString();

            }
            block.Cars = sensorsmock;
            //sensorsmock = new Sensors[2];
            for (int i = 0; i < sensorsmock.Length; i++)
            {
                sensorsmock[i] = new Sensors();
                sensorsmock[i].State = false;
                sensorsmock[i].Name = i.ToString();

            }
            block.Cyclists = sensorsmock;

            //block.Cyclists = new Sensors[2];
            //block.Pedestrians = new Sensors[2];
            for (int i = 0; i < sensorsmock.Length; i++)
            {
                sensorsmock[i] = new Sensors();
                sensorsmock[i].State = true;
                sensorsmock[i].Name = i.ToString();

            }
            block.Pedestrians = sensorsmock;

            block.Busses = new Busses[2];


            block.id = "hagrid";

        }



        return num;
    }
}
