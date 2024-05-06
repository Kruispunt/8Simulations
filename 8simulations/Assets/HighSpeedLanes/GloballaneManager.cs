using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class GloballaneManager : MonoBehaviour
{

    public PreBuildCorssPoints BuildCorssPoints;

    public float LaneScalar = 1;
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
    LaneLampSettr LaneLampSettr = new LaneLampSettr();

    public Clientbetter Communicator;

    void Start()
    {
        this.LaneLampSettr.SetupSettr(this);
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
        getdataFromPreBuildB();
        this.SignalGroup = GetSignalGroup();
    }

    IEnumerator UpdatePakket(float ticktime)
    {
        yield return new WaitForSeconds(ticktime);
        string japsie = JsonConvert.SerializeObject(SignalGroup);
        if(Communicator != null)
        {
            Communicator.jsonjapp = japsie;
        }

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
        foreach (GameObject go in WalkLanes)
        {
            int c = UnityEngine.Random.Range(min, max);
            CreateWalkers(go.GetComponentInChildren<WalkLanebehaviour>(), c);
        }
        foreach (GameObject go in WalkLanesB)
        {
            int c = UnityEngine.Random.Range(min, max);
            CreateWalkers (go.GetComponentInChildren<WalkLanebehaviour>(), c);
        }
        foreach (GameObject go in BikeLanes)
        {
            int c = UnityEngine.Random.Range(min, max);
            CreateBikers(go.GetComponentInChildren<FietsLaanBehaviour>(), c);
        }
        foreach (GameObject go in BikeLanesB)
        {
            int c = UnityEngine.Random.Range(min, max);
            CreateBikers(go.GetComponentInChildren<FietsLaanBehaviour>(), c);
        }

    }

    private void getdata()
    {

        //for abc 
        for (int i = 0; i < 4; i++)
        {
            carSensormsgsA.Add(Carlanes[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);

        }

        for (int i = 4; i < 4 + 4; i++)
        {
            carSensormsgsB.Add(Carlanes[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);

        }
        for (int i = 4 + 4; i < 4 + 4 + 4; i++)
        {
            carSensormsgsC.Add(Carlanes[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);

        }
        BuildBetterLanesOnPoint();
    }
    private void getdataFromPreBuildB()
    {

        //for Def
        for (int i = 0; i < 4; i++)
        {
            carSensormsgsD.Add(CarlanesB[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);

        }

        for (int i = 4; i < 4 + 3; i++)
        {
            carSensormsgsE.Add(CarlanesB[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);

        }
        for (int i = 4 + 3; i < 4 + 3 + 4; i++)
        {
            carSensormsgsF.Add(CarlanesB[i].GetComponentInChildren<CarLanebehaviour>().DetectorLus);

        }
        BuildBetterLanesOnPointB();

    }

    public void BuildBetterLanesOnPoint()
    {
        BikeLanes.Add(Instantiate(BikeLanePrefab, BuildCorssPoints.Ain.transform.position, Quaternion.identity));
        BikeLanes.Last().name = "ABike" + BikeLanes.Count;
        BikelaneA.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        WalkLanes.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.Ain.transform.position += (BuildCorssPoints.Ain.transform.right * BuildCorssPoints.WalkLaneOffset), Quaternion.identity));
        WalkLanes.Last().name = "Walk A In";
        WalklaneA.Add(ExtractSingle(WalkLanes.Last()));

        WalkLanes.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.Aisland.transform.position += (BuildCorssPoints.Aisland.transform.right * BuildCorssPoints.WalkLaneOffset), Quaternion.identity));
        WalkLanes.Last().name = "Walk A ISland";
        WalklaneA.Add(ExtractSingle(WalkLanes.Last()));

        WalkLanes.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.Aisland.transform.position -= (BuildCorssPoints.Aisland.transform.right * BuildCorssPoints.WalkLaneOffset), BuildCorssPoints.Aisland.transform.rotation));
        WalkLanes.Last().name = "Walk inverseA ISland";
        WalkLanes.Last().transform.Rotate(Vector3.up * 180);
        WalklaneA.Add(ExtractSingle(WalkLanes.Last()));


        BikeLanes.Add(Instantiate(BikeLanePrefab, (BuildCorssPoints.Aisland.transform.position + (BuildCorssPoints.Aisland.transform.forward * BuildCorssPoints.EndDistance)), Quaternion.identity));
        BikeLanes.Last().name = "ABike" + BikeLanes.Count;
        BikelaneA.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);


        WalkLanes.Add(Instantiate(WalkLanePrefab, (BuildCorssPoints.Aisland.transform.position + (BuildCorssPoints.Aisland.transform.forward * BuildCorssPoints.EndDistance)), Quaternion.identity));
        WalkLanes.Last().name = "Walk A Out";
        WalkLanes.Last().transform.Rotate(Vector3.up * 180);
        WalklaneA.Add(ExtractSingle(WalkLanes.Last()));



        BikeLanes.Add(Instantiate(BikeLanePrefab, BuildCorssPoints.Bin.transform.position, Quaternion.identity));
        BikeLanes.Last().name = "BBike" + BikeLanes.Count;
        BikelaneB.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);


        WalkLanes.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.Bin.transform.position += (BuildCorssPoints.Bin.transform.right * BuildCorssPoints.WalkLaneOffset), Quaternion.identity));
        WalkLanes.Last().name = "Walk B In";
        WalklaneB.Add(ExtractSingle(WalkLanes.Last()));

        WalkLanes.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.Aisland.transform.position += (BuildCorssPoints.Aisland.transform.right * BuildCorssPoints.WalkLaneOffset), Quaternion.identity));
        WalkLanes.Last().name = "Walk B ISland";
        WalklaneB.Add(ExtractSingle(WalkLanes.Last()));

        WalkLanes.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.BIsland.transform.position -= (BuildCorssPoints.BIsland.transform.right * BuildCorssPoints.WalkLaneOffset), BuildCorssPoints.BIsland.transform.rotation));
        WalkLanes.Last().name = "Walk inverseB ISland";
        WalkLanes.Last().transform.Rotate(Vector3.up * 180);
        WalklaneB.Add(ExtractSingle(WalkLanes.Last()));


        BikeLanes.Add(Instantiate(BikeLanePrefab, (BuildCorssPoints.BIsland.transform.position + (BuildCorssPoints.BIsland.transform.forward * BuildCorssPoints.EndDistance)), Quaternion.identity));
        BikeLanes.Last().name = "BBike" + BikeLanes.Count;
        BikelaneB.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);


        WalkLanes.Add(Instantiate(WalkLanePrefab, (BuildCorssPoints.BIsland.transform.position + (BuildCorssPoints.BIsland.transform.forward * BuildCorssPoints.EndDistance)), Quaternion.identity));
        WalkLanes.Last().name = "Walk B Out";
        WalkLanes.Last().transform.Rotate(Vector3.up * 180);
        WalklaneB.Add(ExtractSingle(WalkLanes.Last()));
    }
    public void BuildBetterLanesOnPointB()
    {
        BikeLanesB.Add(Instantiate(BikeLanePrefab, BuildCorssPoints.EIn.transform.position, Quaternion.identity));
        BikeLanesB.Last().name = "EBike" + BikeLanes.Count;
        BikelaneE.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);


        WalkLanesB.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.EIn.transform.position += (BuildCorssPoints.EIn.transform.right * BuildCorssPoints.WalkLaneOffset), Quaternion.identity));
        WalkLanesB.Last().name = "Walk E In";
        WalklaneE.Add(ExtractSingle(WalkLanesB.Last()));


        WalkLanesB.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.EIsland.transform.position += (BuildCorssPoints.EIsland.transform.right * BuildCorssPoints.WalkLaneOffset), Quaternion.identity));
        WalkLanesB.Last().name = "Walk E ISland";
        WalklaneE.Add(ExtractSingle(WalkLanesB.Last()));

        WalkLanesB.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.EIsland.transform.position -= (BuildCorssPoints.EIsland.transform.right * BuildCorssPoints.WalkLaneOffset), BuildCorssPoints.Aisland.transform.rotation));
        WalkLanesB.Last().name = "Walk inverseE ISland";
        WalkLanesB.Last().transform.Rotate(Vector3.up * 180);
        WalklaneE.Add(ExtractSingle(WalkLanesB.Last()));

        WalkLanesB.Add(Instantiate(WalkLanePrefab, (BuildCorssPoints.EIsland.transform.position + (BuildCorssPoints.EIsland.transform.forward * BuildCorssPoints.EndDistance)), Quaternion.identity));
        WalkLanesB.Last().name = "Walk E Out";
        WalkLanesB.Last().transform.Rotate(Vector3.up * 180);
        WalklaneE.Add(ExtractSingle(WalkLanesB.Last()));


        BikeLanesB.Add(Instantiate(BikeLanePrefab, (BuildCorssPoints.EIsland.transform.position + (BuildCorssPoints.EIsland.transform.forward * BuildCorssPoints.EndDistance)), Quaternion.identity));
        BikeLanesB.Last().name = "EBike Mirrored" + BikeLanes.Count;

        BikelaneE.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);
        BikeLanesB.Last().transform.Rotate(Vector3.up * 180);
        WalklaneE.Add(ExtractSingle(WalkLanesB.Last()));

        //seperation


        BikeLanesB.Add(Instantiate(BikeLanePrefab, BuildCorssPoints.FIn.transform.position, Quaternion.identity));
        BikeLanesB.Last().name = "FBike" + BikeLanes.Count;
        BikelaneF.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);


        WalkLanesB.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.FIn.transform.position += (BuildCorssPoints.FIn.transform.right * BuildCorssPoints.WalkLaneOffset), Quaternion.identity));
        WalkLanesB.Last().name = "Walk F In";
        WalklaneF.Add(ExtractSingle(WalkLanesB.Last()));

        WalkLanesB.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.FIsland.transform.position += (BuildCorssPoints.FIsland.transform.right * BuildCorssPoints.WalkLaneOffset), Quaternion.identity));
        WalkLanesB.Last().name = "Walk F ISland";
        WalklaneF.Add(ExtractSingle(WalkLanesB.Last()));

        WalkLanesB.Add(Instantiate(WalkLanePrefab, BuildCorssPoints.FIsland.transform.position -= (BuildCorssPoints.FIsland.transform.right * BuildCorssPoints.WalkLaneOffset), BuildCorssPoints.Aisland.transform.rotation));
        WalkLanesB.Last().name = "Walk inverseF ISland";
        WalkLanesB.Last().transform.Rotate(Vector3.up * 180);
        WalklaneF.Add(ExtractSingle(WalkLanesB.Last()));


        BikeLanes.Add(Instantiate(BikeLanePrefab, (BuildCorssPoints.EIsland.transform.position + (BuildCorssPoints.EIsland.transform.forward * BuildCorssPoints.EndDistance)), Quaternion.identity));
        BikeLanes.Last().name = "FBike Out Mirrored" + BikeLanes.Count;
        BikelaneF.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);
        BikeLanesB.Last().transform.Rotate(Vector3.up * 180);


        WalkLanesB.Add(Instantiate(WalkLanePrefab, (BuildCorssPoints.EIsland.transform.position + (BuildCorssPoints.EIsland.transform.forward * BuildCorssPoints.EndDistance)), Quaternion.identity));
        WalkLanesB.Last().name = "Walk F Out";
        WalkLanesB.Last().transform.Rotate(Vector3.up * 180);
        WalklaneF.Add(ExtractSingle(WalkLanesB.Last()));
    }

    //for bikes a
    public void BuildbikeLanes()
    {
        BikeLanes.Add(Instantiate(BikeLanePrefab, Carlanes[0].transform.position + ((Carlanes[0].transform.right * LaneScalar) + (Carlanes[0].transform.right * (1 * LaneScalar))), Quaternion.identity));
        BikeLanes.Last().name = "ABike" + BikeLanes.Count;
        BikelaneA.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanes.Add(Instantiate(BikeLanePrefab, BikeLanes.Last().transform.position + ((BikeLanes.Last().transform.right * LaneScalar) + (BikeLanes.Last().transform.right * (1 * LaneScalar))), Quaternion.identity));
        BikeLanes.Last().name = "ABike" + BikeLanes.Count;
        BikelaneA.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanes.Add(Instantiate(BikeLanePrefab, BikeLanes.Last().transform.position + ((BikeLanes.Last().transform.right * LaneScalar) + (BikeLanes.Last().transform.right * (1 * LaneScalar))), Quaternion.identity));
        BikeLanes.Last().name = "BBike" + BikeLanes.Count;
        BikelaneB.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanes.Add(Instantiate(BikeLanePrefab, BikeLanes.Last().transform.position + ((BikeLanes.Last().transform.right * LaneScalar) + (BikeLanes.Last().transform.right * (1 * LaneScalar))), Quaternion.identity));
        BikeLanes.Last().name = "BBike" + BikeLanes.Count;
        BikelaneB.Add(BikeLanes.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);


        BuildWalkLanesOnPointA(BikeLanes[0].transform, "voetpad A");
        WalklaneA = ExtractDetectorsWalkLanes(4, 0);
        BuildWalkLanesOnPointA(BikeLanes[2].transform, "voetpad B");
        WalklaneB = ExtractDetectorsWalkLanes(4, 4);

    }
    //4 in totaal

    public void BuildWalkLanesOnPointA(Transform ransform, string nam)
    {
        WalkLanes.Add(Instantiate(WalkLanePrefab, ransform.position + ((ransform.right * LaneScalar)), Quaternion.identity));
        WalkLanes.Last().name = nam + WalkLanes.Count;
        //the second part
        WalkLanes.Add(Instantiate(WalkLanePrefab, WalkLanes.Last().transform.position + ((WalkLanes.Last().transform.forward * WalkLanes.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance)), Quaternion.identity));
        WalkLanes.Last().name = nam + WalkLanes.Count;

        WalkLanes.Add(Instantiate(WalkLanePrefab, WalkLanes.Last().transform.position + ((WalkLanes.Last().transform.forward * WalkLanes.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance) + (WalkLanes.Last().transform.right * LaneScalar)), Quaternion.identity));
        WalkLanes.Last().name = nam + WalkLanes.Count;
        WalkLanes.Last().transform.Rotate(Vector3.up * 180);
        //the second part
        WalkLanes.Add(Instantiate(WalkLanePrefab, WalkLanes.Last().transform.position - ((WalkLanes.Last().transform.forward * WalkLanes.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance) - (WalkLanes.Last().transform.right * LaneScalar)), Quaternion.identity));
        WalkLanes.Last().name = nam + WalkLanes.Count;
        WalkLanes.Last().transform.Rotate(Vector3.up * 180);


    }
    public void BuildWalkLanesOnPointB(Transform ransform, string nam)
    {
        WalkLanesB.Add(Instantiate(WalkLanePrefab, ransform.position + ((ransform.right * LaneScalar)), Quaternion.identity));
        WalkLanesB.Last().name = nam + WalkLanesB.Count;
        //the second part
        WalkLanesB.Add(Instantiate(WalkLanePrefab, WalkLanesB.Last().transform.position + ((WalkLanesB.Last().transform.forward * WalkLanesB.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance)), Quaternion.identity));
        WalkLanesB.Last().name = nam + WalkLanesB.Count;

        WalkLanesB.Add(Instantiate(WalkLanePrefab, WalkLanesB.Last().transform.position + ((WalkLanesB.Last().transform.forward * WalkLanesB.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance) + (WalkLanesB.Last().transform.right * LaneScalar)), Quaternion.identity));
        WalkLanesB.Last().name = nam + WalkLanesB.Count;
        WalkLanesB.Last().transform.Rotate(Vector3.up * 180);
        //the second part
        WalkLanesB.Add(Instantiate(WalkLanePrefab, WalkLanesB.Last().transform.position - ((WalkLanesB.Last().transform.forward * WalkLanesB.Last().GetComponentInChildren<WalkLanebehaviour>().MidPointDistance) - (WalkLanesB.Last().transform.right * LaneScalar)), Quaternion.identity));
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

    private SingleDetector ExtractSingle(GameObject lane)
    {
        return lane.GetComponentInChildren<WalkLanebehaviour>().DetectorLus;
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
        BikeLanesB.Add(Instantiate(BikeLanePrefab, CarlanesB[0].transform.position + ((CarlanesB[0].transform.right * LaneScalar) + (CarlanesB[0].transform.right * (1 * LaneScalar))), Quaternion.identity));
        BikeLanesB.Last().name = "E" + BikeLanesB.Count;
        BikelaneE.Add(BikeLanesB.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanesB.Add(Instantiate(BikeLanePrefab, BikeLanesB.Last().transform.position + ((BikeLanesB.Last().transform.right * LaneScalar) + (BikeLanesB.Last().transform.right * (1 * LaneScalar))), Quaternion.identity));
        BikeLanesB.Last().name = "E" + BikeLanesB.Count;
        BikelaneE.Add(BikeLanesB.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanesB.Add(Instantiate(BikeLanePrefab, BikeLanesB.Last().transform.position + ((BikeLanesB.Last().transform.right * LaneScalar) + (BikeLanesB.Last().transform.right * (1 * LaneScalar))), Quaternion.identity));
        BikeLanesB.Last().name = "F" + BikeLanesB.Count;
        BikelaneF.Add(BikeLanesB.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BikeLanesB.Add(Instantiate(BikeLanePrefab, BikeLanesB.Last().transform.position + ((BikeLanesB.Last().transform.right * LaneScalar) + (BikeLanesB.Last().transform.right * (1 * LaneScalar))), Quaternion.identity));
        BikeLanesB.Last().name = "F" + BikeLanesB.Count;
        BikelaneF.Add(BikeLanesB.Last().GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);

        BuildWalkLanesOnPointB(BikeLanesB[1].transform, "voetpad E");
        WalklaneE = ExtractDetectorsWalkLanesB(4, 0);
        BuildWalkLanesOnPointB(BikeLanesB[2].transform, "voetpad F");
        WalklaneF = ExtractDetectorsWalkLanesB(4, 4);
    }
 


    //create and add cars to the light
    private void CreateCars(CarLanebehaviour go, int count)  
    {
        //Debug.Log(TrafficList.Count);
        for (int i = 0; i < count; i++)
        {
            GameObject kees = Instantiate(Traffic, go.GetLaneStart(), Quaternion.identity);
            kees.GetComponent<ActorPathFinding>().Setroute(go.GetLaneStart(), go.GetLaneStartSignal(), go.GetLaneExit());
            kees.GetComponent<ActorPathFinding>().watch = go.LampostManager.watch;
            kees.GetComponent<Movement>().Setup();
        }

    }
    private void CreateWalkers(WalkLanebehaviour go, int count)
    {
        //Debug.Log(TrafficList.Count);
        for (int i = 0; i < count; i++)
        {
            GameObject kees = Instantiate(Traffic, go.GetLaneStart(), Quaternion.identity);
            kees.GetComponent<ActorPathFinding>().Setroute(go.GetLaneStart(), go.GetLaneStartSignal(), go.GetLaneExit());
            kees.GetComponent<ActorPathFinding>().watch = go.LampostManager.watch;
            kees.GetComponent<Movement>().Setup();
        }

    }
    private void CreateBikers(FietsLaanBehaviour go, int count)
    {
        //Debug.Log(TrafficList.Count);
        for (int i = 0; i < count; i++)
        {
            GameObject kees = Instantiate(Traffic, go.GetLaneStart(), Quaternion.identity);
            kees.GetComponent<ActorPathFinding>().Setroute(go.GetLaneStart(), go.GetLaneStartSignal(), go.GetLaneExit());
            kees.GetComponent<ActorPathFinding>().watch = go.LampostManager.watch;
            kees.GetComponent<Movement>().Setup();
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


   


    public void Update()
    {
        if (Communicator.updatedKees)
        {
            //string path = Application.persistentDataPath + "/ControllerToSim.json";
            //string jsonContent = File.ReadAllText(path);

            LaneLampSettr.DecodeJappie(Communicator.kees);
            Communicator.updatedKees = false;
        }
    }

}
