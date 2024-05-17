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

    public GameObject PrebuiltLaneA;
    public GameObject PrebuiltLaneB;
    public GameObject PrebuiltLaneE;
    public GameObject PrebuiltLaneF;

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
    }


   
    IEnumerator getLane(int timeInSec)
    {
        //refresh simulation state 5 secs
        yield return new WaitForSeconds(timeInSec);
        getdata();
        getdataFromPreBuildB();
        getBikeLaneInfo();

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

        //Debug.Log(japsie);
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


    public void getBikeLaneInfo()
    {
        //PrebuiltLaneA.GetComponent<PrebuildBlockInfo>().fietsLaanBehaviours
        WalklaneA = PrebuiltLaneA.GetComponent<PrebuildBlockInfo>().WalklaneScripts;
        WalklaneB = PrebuiltLaneB.GetComponent<PrebuildBlockInfo>().WalklaneScripts;
        WalklaneE = PrebuiltLaneE.GetComponent<PrebuildBlockInfo>().WalklaneScripts;
        WalklaneF = PrebuiltLaneF.GetComponent<PrebuildBlockInfo>().WalklaneScripts;

        BikelaneA = PrebuiltLaneA.GetComponent<PrebuildBlockInfo>().BikelaneScripts;
        BikelaneB = PrebuiltLaneB.GetComponent<PrebuildBlockInfo>().BikelaneScripts;
        BikelaneE = PrebuiltLaneE.GetComponent<PrebuildBlockInfo>().BikelaneScripts;
        BikelaneF = PrebuiltLaneF.GetComponent<PrebuildBlockInfo>().BikelaneScripts;

        extractObjects();
    }

    private void extractObjects()
    {
        BikeLanes.AddRange(PrebuiltLaneA.GetComponent<PrebuildBlockInfo>().BikeLanes);
        BikeLanes.AddRange(PrebuiltLaneB.GetComponent<PrebuildBlockInfo>().BikeLanes);

        BikeLanesB.AddRange(PrebuiltLaneE.GetComponent<PrebuildBlockInfo>().BikeLanes);
        BikeLanesB.AddRange(PrebuiltLaneF.GetComponent<PrebuildBlockInfo>().BikeLanes);

        WalkLanes.AddRange(PrebuiltLaneA.GetComponent<PrebuildBlockInfo>().PedestrianLanes);
        WalkLanes.AddRange(PrebuiltLaneB.GetComponent<PrebuildBlockInfo>().PedestrianLanes);

        WalkLanesB.AddRange(PrebuiltLaneE.GetComponent<PrebuildBlockInfo>().PedestrianLanes);
        WalkLanesB.AddRange(PrebuiltLaneF.GetComponent<PrebuildBlockInfo>().PedestrianLanes);
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

    }



    //create and add cars to the light
    private void CreateCars(CarLanebehaviour go, int count)  
    {
        //Debug.Log(TrafficList.Count);
        for (int i = 0; i < count; i++)
        {
            //GameObject kees = Instantiate(Traffic, go.GetSpwanPos(), Quaternion.identity);
            GameObject kees = Instantiate(CarActorCollection.GetRandomCarPrefab(), go.GetSpwanPos(), Quaternion.identity);
            kees.GetComponentInChildren<ActorPathFinding>().Setroute(go.GetLaneStart(), go.GetLaneStartSignal(), go.GetLaneExit());
            kees.GetComponentInChildren<ActorPathFinding>().watch = go.LampostManager.watch;
            kees.GetComponentInChildren<Movement>().Setup();
        }

    }
    private void CreateBus(CarLanebehaviour go)
    {
        //Debug.Log(TrafficList.Count);

            //GameObject kees = Instantiate(Traffic, go.GetSpwanPos(), Quaternion.identity);
            GameObject kees = Instantiate(CarActorCollection.GetRandomCarPrefab(), go.GetSpwanPos(), Quaternion.identity);
            kees.GetComponentInChildren<ActorPathFinding>().Setroute(go.GetLaneStart(), go.GetLaneStartSignal(), go.GetLaneExit());
            kees.GetComponentInChildren<ActorPathFinding>().watch = go.LampostManager.watch;
            kees.GetComponentInChildren<Movement>().Setup();
        

    }
    private void CreateWalkers(WalkLanebehaviour go, int count)
    {
        //Debug.Log(TrafficList.Count);
        //for (int i = 0; i < count; i++)
        //{
        //    GameObject kees = Instantiate(Traffic, go.GetLaneStart(), Quaternion.identity);
        //    kees.GetComponent<ActorPathFinding>().Setroute(go.GetLaneStart(), go.GetLaneStartSignal(), go.GetLaneExit());
        //    kees.GetComponent<ActorPathFinding>().watch = go.lampostManager.watch;

        //    kees.GetComponent<Movement>().Setup();
        //}

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
        msg.A = AssignblockmsgData(carSensormsgsA, PrebuiltLaneA.GetComponent<PrebuildBlockInfo>().BikelaneScripts, PrebuiltLaneA.GetComponent<PrebuildBlockInfo>().WalklaneScripts);
        msg.B = AssignblockmsgBusData(carSensormsgsB, PrebuiltLaneB.GetComponent<PrebuildBlockInfo>().BikelaneScripts, PrebuiltLaneB.GetComponent<PrebuildBlockInfo>().WalklaneScripts);
        msg.C = AssignblocksmsgCarOnlyData(carSensormsgsC);

        //msg.A = AssignblockmsgData(carSensormsgsA, BikelaneA, WalklaneA);
        //msg.B = AssignblockmsgBusData(carSensormsgsB, BikelaneB, WalklaneB);
        //msg.C = AssignblocksmsgCarOnlyData(carSensormsgsC);
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
        msg.E = AssignblockmsgBusData(carSensormsgsE, PrebuiltLaneE.GetComponent<PrebuildBlockInfo>().BikelaneScripts, PrebuiltLaneE.GetComponent<PrebuildBlockInfo>().WalklaneScripts);
        msg.F = AssignblockmsgData(carSensormsgsF, PrebuiltLaneF.GetComponent<PrebuildBlockInfo>().BikelaneScripts, PrebuiltLaneF.GetComponent<PrebuildBlockInfo>().WalklaneScripts);

        //msg.D = AssignblocksmsgCarOnlyData(carSensormsgsD);
        //msg.E = AssignblockmsgBusData(carSensormsgsE, BikelaneE, WalklaneE);
        //msg.F = AssignblockmsgData(carSensormsgsF, BikelaneF, WalklaneF);

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
