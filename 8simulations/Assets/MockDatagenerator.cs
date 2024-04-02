using recieverpakket;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MockDatagenerator
{


    public Index index;
    // Start is called before the first frame update

    public PakketRes generateRecievePakket()
    {
        PakketRes pakket = new PakketRes();


        pakket.blocks = new recieverpakket.Block[4];
        for (int i = 0; i < pakket.blocks.Length; i++)
        {
            pakket.blocks[i] = new recieverpakket.Block();
        }

        foreach (var block in pakket.blocks)
        {
            int[] stats = new int[3];

            for (int i = 0;i < pakket.blocks.Length;i++)
            {
                stats[i] = 2;
            }

            block.Pedestrians = stats;
            block.Cars = stats;
            block.Cyclists = stats;
            block.id = "A";
        }


        return pakket;
    }
    public void CreatLocalRecievePakket()
    {

    }


    public SignalGroup GenerateMockCrossmsg()
    {

        SignalGroup signalGroup = new SignalGroup();

        signalGroup.blocksMsg = new blocksMsg();


        signalGroup.blocksMsg.A = new blockmsg();
        signalGroup.blocksMsg.B = new blockmsg();
        signalGroup.blocksMsg.C = new blockmsg();
        signalGroup.blocksMsg.A.CarSensormsg = new CarSensormsg[2];

        signalGroup.blocksMsg.B.CarSensormsg = new CarSensormsg[2];

        signalGroup.blocksMsg.C.CarSensormsg = new CarSensormsg[2];


        for(int i = 0;  i < signalGroup.blocksMsg.A.CarSensormsg.Length; i++)
        {
            signalGroup.blocksMsg.A.CarSensormsg[i] = new CarSensormsg();
        }


        signalGroup.blocksMsg.A.CarSensormsg[1].DetectNear = true;
        signalGroup.blocksMsg.A.CarSensormsg[1].DetectFar = false;
        signalGroup.blocksMsg.A.CarSensormsg[1].PrioCar = false;

        signalGroup.blocksMsg.A.CarSensormsg[2].DetectNear = true;
        signalGroup.blocksMsg.A.CarSensormsg[2].DetectFar = false;
        signalGroup.blocksMsg.A.CarSensormsg[2].PrioCar = true;

        for (int i = 0; i < signalGroup.blocksMsg.B.CarSensormsg.Length; i++)
        {
            signalGroup.blocksMsg.B.CarSensormsg[i] = new CarSensormsg();
        }

        signalGroup.blocksMsg.B.CarSensormsg[1].DetectNear = true;
        signalGroup.blocksMsg.B.CarSensormsg[1].DetectFar = false;
        signalGroup.blocksMsg.B.CarSensormsg[1].PrioCar = true;

        signalGroup.blocksMsg.B.CarSensormsg[2].DetectNear = true;
        signalGroup.blocksMsg.B.CarSensormsg[2].DetectFar = false;
        signalGroup.blocksMsg.B.CarSensormsg[2].PrioCar = true;

        return signalGroup;

    }

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
