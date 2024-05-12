using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrebuildBlockInfo : MonoBehaviour
{


    public string BlockCode = "empty";

    //bike lanes 
    public GameObject BikeLaneIn;
    public GameObject BikeLaneOut;

    //in block 
    public GameObject PedestrianLampIn;
    public GameObject PedestriianLampMid;

    //revers block
    public GameObject PedestrianLampInR;
    public GameObject PedestriianLampMidR;

    public List<GameObject> BikeLanes = new List<GameObject>();
    public List<GameObject> PedestrianLanes = new List<GameObject>();

    public List<WalkLanebehaviour> walkLanebehaviours = new List<WalkLanebehaviour>();
    public List<FietsLaanBehaviour> fietsLaanBehaviours = new List<FietsLaanBehaviour>();

    public List<SingleDetector> BikelaneScripts = new List<SingleDetector>();
    public List<SingleDetector> WalklaneScripts = new List<SingleDetector>();

    private void Start()
    {
        buildLaneList();
        buildPedestrianLaneList();

        BikelaneScripts = getLaneScripts(BikeLanes, true);
        WalklaneScripts = getLaneScripts(PedestrianLanes, false);
    }

    private void buildLaneList()
    {
        BikeLanes.Add(BikeLaneIn);
        fietsLaanBehaviours.Add(BikeLaneIn.GetComponentInChildren<FietsLaanBehaviour>());
        BikeLanes.Add(BikeLaneOut);
        fietsLaanBehaviours.Add(BikeLaneOut.GetComponentInChildren<FietsLaanBehaviour>());
    }

    private void buildPedestrianLaneList()
    {
        PedestrianLanes.Add (PedestrianLampIn);
        PedestrianLanes.Add(PedestriianLampMid);
        PedestrianLanes.Add(PedestriianLampMidR);
        PedestrianLanes.Add(PedestrianLampInR);
    }

    private List<SingleDetector> getLaneScripts(List<GameObject> objects, bool isBikeLane)
    {
        List<SingleDetector> singleDetectors = new List<SingleDetector>();


        foreach (GameObject obj in objects)
        {
            if (isBikeLane)
            {
                singleDetectors.Add(obj.GetComponentInChildren<FietsLaanBehaviour>().DetectorLus);
            }
            else
            {
                singleDetectors.Add(obj.GetComponentInChildren<WalkLanebehaviour>().DetectorLus);
            }
        }

        return singleDetectors;
    }


    public void Setlamps(List<int> BikeLampsStates, List<int> PedestrianlampsStates)
    {
        for (int i = 0; i < BikeLampsStates.Count; i++)
        {
            BikeLanes[i].GetComponentInChildren<FietsLaanBehaviour>().SetLampLight(BikeLampsStates[i]);
        }
        for (int i = 0; i < PedestrianlampsStates.Count; i++)
        {
            PedestrianLanes[i].GetComponentInChildren<WalkLanebehaviour>().SetLampLight(PedestrianlampsStates[i]);
        }
    }


}
