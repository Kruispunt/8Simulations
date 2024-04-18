using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class GloballaneManager : MonoBehaviour
{


    public bool LoopSpawn;
    // Start is called before the first frame update
    public GameObject Traffic;

    public GameObject CarLanePrefab;

    public GameObject BikeLanePrefab;

    public GameObject WalkLanePrefab;

    public int timeInSec;
    public float updateTimer;
    public List<GameObject> Carlanes;
    public List<GameObject> CarlanesB;
    public List<GameObject> BikeLanes;
    public List <GameObject> BikeLanesB;

    public List <GameObject> WalkLanes;
    public List <GameObject> WalkLanesB;

    public int SpawnMin, SpawnMax;

    public List<GameObject> Voetpaden;
    public List<GameObject> TrafficList = new List<GameObject>();





    public List<CarSensormsg> carSensormsgsA = new List<CarSensormsg>();
    public List<SingleDetector> BikelaneA = new List<SingleDetector>();
    public List<SingleDetector> WalklaneA = new List<SingleDetector>();


    public List<CarSensormsg> carSensormsgsB = new List<CarSensormsg>();
    public List<SingleDetector> BikelaneB = new List<SingleDetector>();
    public List<SingleDetector> WalklaneB = new List<SingleDetector>();


    public List<CarSensormsg> carSensormsgsC = new List<CarSensormsg>();

    public List<CarSensormsg> carSensormsgsD = new List<CarSensormsg>();

    public List<CarSensormsg> carSensormsgsE = new List<CarSensormsg>();
    public List<SingleDetector> BikelaneE = new List<SingleDetector>();
    public List<SingleDetector> WalklaneE = new List<SingleDetector>();


    public List<CarSensormsg> carSensormsgsF = new List<CarSensormsg>();
    public List<SingleDetector> BikelaneF = new List<SingleDetector>();
    public List<SingleDetector> WalklaneF = new List<SingleDetector>();


    //called by the client upon the first frame


    public SignalGroup SignalGroup = new SignalGroup();

    void Start()
    {

        StartCoroutine(getLane(timeInSec));
        StartCoroutine(Simutick(timeInSec + 4));
        StartCoroutine(UpdatePakket(updateTimer));
        //StartCoroutine(getLane(timeInSec));


        //c no bikes
        //d no bikes

        //2 bikes per block

        //4
        //4
        //4

        //4
        //3
        //3

    }

    IEnumerator getLane(int timeInSec)
    {
        //refresh simulation state 5 secs
        yield return new WaitForSeconds(timeInSec);
        getdata();
        getDataB();
        this.SignalGroup = GetSignalGroup();


        //StartCoroutine(Simutick(timeInSec));
    }

    IEnumerator UpdatePakket(float ticktime)
    {
        yield return new WaitForSeconds(ticktime);
        string japsie = JsonConvert.SerializeObject(SignalGroup);

        Debug.Log(japsie);
        StartCoroutine(UpdatePakket(ticktime));
    }


    //time based loop for refreshing important things
    IEnumerator Simutick(int timeInSec)
    {
        //refresh simulation state 5 secs
        yield return new WaitForSeconds(timeInSec);
        SpawnRandomCars(SpawnMin, SpawnMax);
        if (LoopSpawn)
        {
            StartCoroutine(Simutick(timeInSec));
        }
        //StartCoroutine(Simutick(timeInSec));
    }

    //use this to assign cars to lights
    private void SpawnRandomCars(int min, int max)
    {
        foreach (GameObject go in Carlanes)
        {
            int c = UnityEngine.Random.Range(min, max);
            CreateCars(go.GetComponentInChildren<CarLanebehaviour>(), c);
        }
        foreach (GameObject go in CarlanesB)
        {
            int c = UnityEngine.Random.Range(min, max);
            CreateCars(go.GetComponentInChildren<CarLanebehaviour>(), c);
        }

    }

    private void getdata()
    {

        //for abc 
        for (int i = 0; i < 4; i++)
        {
            carSensormsgsA.Add(Carlanes[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);
            Debug.Log(carSensormsgsA.Last().DetectFar);
        }

        for (int i = 4; i < 4 + 4; i++)
        {
            carSensormsgsB.Add(Carlanes[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);
            Debug.Log(carSensormsgsB.Last().DetectFar);
        }
        for (int i = 4 + 4; i < 4 + 4 + 4; i++)
        {
            carSensormsgsC.Add(Carlanes[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);
            Debug.Log(carSensormsgsC.Last().DetectFar);
        }
        BuildbikeLanes();
    }

    //for bikes a
    public void BuildbikeLanes()
    {
        BikeLanes.Add(Instantiate(BikeLanePrefab, Carlanes[0].transform.position + ((Vector3.right * 10) + (Vector3.right * (1 * 10))), Quaternion.identity));
        BikeLanes.Last().name = "A" + BikeLanes.Count;
        BikelaneA.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanes.Add(Instantiate(BikeLanePrefab, BikeLanes.Last().transform.position + ((Vector3.right * 10) + (Vector3.right * (1 * 10))), Quaternion.identity));
        BikeLanes.Last().name = "A" + BikeLanes.Count;
        BikelaneA.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanes.Add(Instantiate(BikeLanePrefab, BikeLanes.Last().transform.position + ((Vector3.right * 10) + (Vector3.right * (1 * 10))), Quaternion.identity));
        BikeLanes.Last().name = "B" + BikeLanes.Count;
        BikelaneB.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanes.Add(Instantiate(BikeLanePrefab, BikeLanes.Last().transform.position + ((Vector3.right * 10) + (Vector3.right * (1 * 10))), Quaternion.identity));
        BikeLanes.Last().name = "B" + BikeLanes.Count;
        BikelaneB.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);


        BuildWalkLanesOnPointA(BikeLanes[1].transform, "voetpad A");
        WalklaneA = ExtractDetectorsWalkLanes(4, 0);
        BuildWalkLanesOnPointA(BikeLanes[3].transform, "voetpad B");
        WalklaneB = ExtractDetectorsWalkLanes(4, 4);

    }
    //4 in totaal

    public void BuildWalkLanesOnPointA(Transform ransform, string nam)
    {
        WalkLanes.Add(Instantiate(WalkLanePrefab, ransform.position + ((Vector3.right * 10)), Quaternion.identity));
        WalkLanes.Last().name = nam + WalkLanes.Count;
        //the second part
        WalkLanes.Add(Instantiate(WalkLanePrefab, WalkLanes.Last().transform.position + ((Vector3.forward * WalkLanes.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance)), Quaternion.identity));
        WalkLanes.Last().name = nam + WalkLanes.Count;

        WalkLanes.Add(Instantiate(WalkLanePrefab, WalkLanes.Last().transform.position + ((Vector3.forward * WalkLanes.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance) + (Vector3.right * 10)), Quaternion.identity));
        WalkLanes.Last().name = nam + WalkLanes.Count;
        WalkLanes.Last().transform.Rotate(Vector3.up * 180);
        //the second part
        WalkLanes.Add(Instantiate(WalkLanePrefab, WalkLanes.Last().transform.position - ((Vector3.forward * WalkLanes.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance) - (Vector3.right * 10)), Quaternion.identity));
        WalkLanes.Last().name = nam + WalkLanes.Count;
        WalkLanes.Last().transform.Rotate(Vector3.up * 180);


    }
    public void BuildWalkLanesOnPointB(Transform ransform, string nam)
    {
        WalkLanesB.Add(Instantiate(WalkLanePrefab, ransform.position + ((Vector3.right * 10)), Quaternion.identity));
        WalkLanesB.Last().name = nam + WalkLanesB.Count;
        //the second part
        WalkLanesB.Add(Instantiate(WalkLanePrefab, WalkLanesB.Last().transform.position + ((Vector3.forward * WalkLanesB.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance)), Quaternion.identity));
        WalkLanesB.Last().name = nam + WalkLanesB.Count;

        WalkLanesB.Add(Instantiate(WalkLanePrefab, WalkLanesB.Last().transform.position + ((Vector3.forward * WalkLanesB.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance) + (Vector3.right * 10)), Quaternion.identity));
        WalkLanesB.Last().name = nam + WalkLanesB.Count;
        WalkLanesB.Last().transform.Rotate(Vector3.up * 180);
        //the second part
        WalkLanesB.Add(Instantiate(WalkLanePrefab, WalkLanesB.Last().transform.position - ((Vector3.forward * WalkLanesB.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance) - (Vector3.right * 10)), Quaternion.identity));
        WalkLanesB.Last().name = nam + WalkLanesB.Count;
        WalkLanesB.Last().transform.Rotate(Vector3.up * 180);


    }
    public List<SingleDetector> ExtractDetectorsWalkLanes(int count, int startpos)
    {
        List<SingleDetector> singles = new List<SingleDetector>();
        //singles.Add(WalkLanes.Last().GetComponentInChildren<WalkLanebehaviour>().DetectorLus);

        for (int i = 0; i < count; i++)
        {
            singles.Add(WalkLanes[i + startpos].GetComponentInChildren<WalkLanebehaviour>().DetectorLus);
        }

        return singles;
        

    }
    public List<SingleDetector> ExtractDetectorsWalkLanesB(int count, int startpos)
    {
        List<SingleDetector> singles = new List<SingleDetector>();

        for (int i = 0; i < count; i++)
        {
            singles.Add(WalkLanesB[i + startpos].GetComponentInChildren<WalkLanebehaviour>().DetectorLus);
        }

        return singles;


    }

    public void BuildBikeLanesB()
    {
        BikeLanesB.Add(Instantiate(BikeLanePrefab, CarlanesB[0].transform.position + ((Vector3.right * 10) + (Vector3.right * (1 * 10))), Quaternion.identity));
        BikeLanesB.Last().name = "E" + BikeLanesB.Count;
        BikelaneE.Add(BikeLanesB.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanesB.Add(Instantiate(BikeLanePrefab, BikeLanesB.Last().transform.position + ((Vector3.right * 10) + (Vector3.right * (1 * 10))), Quaternion.identity));
        BikeLanesB.Last().name = "E" + BikeLanesB.Count;
        BikelaneE.Add(BikeLanesB.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanesB.Add(Instantiate(BikeLanePrefab, BikeLanesB.Last().transform.position + ((Vector3.right * 10) + (Vector3.right * (1 * 10))), Quaternion.identity));
        BikeLanesB.Last().name = "F" + BikeLanesB.Count;
        BikelaneF.Add(BikeLanesB.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanesB.Add(Instantiate(BikeLanePrefab, BikeLanesB.Last().transform.position + ((Vector3.right * 10) + (Vector3.right * (1 * 10))), Quaternion.identity));
        BikeLanesB.Last().name = "F" + BikeLanesB.Count;
        BikelaneF.Add(BikeLanesB.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BuildWalkLanesOnPointB(BikeLanesB[1].transform, "voetpad E");
        WalklaneE = ExtractDetectorsWalkLanesB(4, 0);
        BuildWalkLanesOnPointB(BikeLanesB[3].transform, "voetpad F");
        WalklaneF = ExtractDetectorsWalkLanesB(4, 4);
    }
    //use lane B
    void getDataB()
    {
        //for def
        for (int i = 0; i < 4; i++)
        {
            if(i == 0)
            {
                CarlanesB.Add(Instantiate(CarLanePrefab, Carlanes.Last().transform.position + ((Vector3.right * 10) + (Vector3.right * (i * 10))), Quaternion.identity));
                CarlanesB.Last().name = "VerkeerslichtD" + i + 1;
                carSensormsgsD.Add(CarlanesB[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);
                Debug.Log(carSensormsgsD.Last().DetectFar);
            }
            else
            {
                CarlanesB.Add(Instantiate(CarLanePrefab, CarlanesB.Last().transform.position + ((Vector3.right * 10) + (Vector3.right * (i * 10))), Quaternion.identity));
                CarlanesB.Last().name = "VerkeerslichtD" + i + 1;
                carSensormsgsD.Add(CarlanesB[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);
                Debug.Log(carSensormsgsD.Last().DetectFar);
            }
        }

        for (int i = 4; i < 4 + 3; i++)
        {

                CarlanesB.Add(Instantiate(CarLanePrefab, CarlanesB.Last().transform.position + ((Vector3.right * 10)), Quaternion.identity));
                CarlanesB.Last().name = "VerkeerslichtE" + i + 1;
                carSensormsgsE.Add(CarlanesB[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);
                Debug.Log(carSensormsgsE.Last().DetectFar);
           
        }
        for (int i = 4+ 3; i < 4 + 3 + 4; i++)
        {
            CarlanesB.Add(Instantiate(CarLanePrefab, CarlanesB.Last().transform.position + ((Vector3.right * 10)), Quaternion.identity));
            CarlanesB.Last().name = "VerkeerslichtF" + i + 1;
            carSensormsgsF.Add(CarlanesB[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);
            Debug.Log(carSensormsgsE.Last().DetectFar);

        }

        BuildBikeLanesB();
    }



    //create and add cars to the light
    private void CreateCars(CarLanebehaviour go, int count)  
    {
        //Debug.Log(TrafficList.Count);
        for (int i = 0; i < count; i++)
        {
            TrafficList.Add(Instantiate(Traffic, go.GetLaneStart(), Quaternion.identity));
            TrafficList.Last().GetComponent<ActorPathFinding>().Setroute(go.GetLaneStart(), go.GetLaneStartSignal(), go.GetLaneExit());
            TrafficList.Last().GetComponent<ActorPathFinding>().watch = go.LampostManager.watch;
            TrafficList.Last().GetComponent<Movement>().Setup();
        }

    }

    public SignalGroup GetSignalGroup()
    {
        SignalGroup group = new SignalGroup();

        group.blocksMsg1 = AssignMsgData();
        group.blocksMsg2 = AssignMsg2Data();

        string japsie = JsonConvert.SerializeObject(group);

        Debug.Log(japsie);
        return group;
    }

    public blocksMsg AssignMsgData()
    {
        blocksMsg msg = new blocksMsg();

        msg.A = AssignblockmsgData(carSensormsgsA, BikelaneA, WalklaneA);
        msg.B = AssignblockmsgBusData(carSensormsgsB, BikelaneB, WalklaneB);
        msg.C = AssignblocksmsgCarOnlyData(carSensormsgsC);
        return msg;
        
    }
    public blockmsg AssignblockmsgData(List<CarSensormsg> carSensormsgs, List<SingleDetector> bikers, List<SingleDetector> walks)
    {
        blockmsg msg = new blockmsg();
        msg.LCarSensormsgs = carSensormsgs;
        msg.Bikers = bikers;
        msg.Walkers = walks;

        return msg;
    }
    public blockmsgBus AssignblockmsgBusData(List<CarSensormsg> carSensormsgs, List<SingleDetector> bikers, List<SingleDetector> walks)
    {
        blockmsgBus msgBus = new blockmsgBus();

        msgBus.LCarSensormsgs = carSensormsgs;
        msgBus.Walkers = walks;

        msgBus.Bikers = bikers;
        msgBus.LBusses = new List<int> { 1 };
        return msgBus;
    }

    //returns caronly spots
    public blockmsgCarOnly AssignblocksmsgCarOnlyData(List<CarSensormsg> carSensormsgs)
    {
        blockmsgCarOnly msgCarOnly = new blockmsgCarOnly();
        msgCarOnly.LCarSensormsgs = carSensormsgs;
        return msgCarOnly;
    }


    public blocksMsg2 AssignMsg2Data()
    {
        blocksMsg2 msg = new blocksMsg2();

        msg.D = AssignblocksmsgCarOnlyData(carSensormsgsD);
        msg.E = AssignblockmsgBusData(carSensormsgsE, BikelaneE, WalklaneE);
        msg.F = AssignblockmsgData(carSensormsgsF, BikelaneF, WalklaneF);

        return msg;

    }

    public void GetLaneData()
    {

    }

}
