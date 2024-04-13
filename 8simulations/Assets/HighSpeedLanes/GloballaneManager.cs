using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

public class GloballaneManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Traffic;
    public int timeInSec;
    public List<GameObject> Carlanes;
    public int SpawnMin, SpawnMax;

    public List<GameObject> Bikelanes;
    public List<GameObject> Voetpaden;
    public List<GameObject> TrafficList = new List<GameObject>();
    //called by the client upon the first frame

    void Start()
    {
        StartCoroutine(Simutick(timeInSec));

    }


    //time based loop for refreshing important things
    IEnumerator Simutick(int timeInSec)
    {
        //refresh simulation state 5 secs
        yield return new WaitForSeconds(timeInSec);
        SpawnRandomCars(1, 10);
        StartCoroutine(Simutick(timeInSec));
    }

    //use this to assign cars to lights
    private void SpawnRandomCars(int min, int max)
    {
        foreach (GameObject go in Carlanes)
        {
            int c = UnityEngine.Random.Range(min, max);
            CreateCars(go.GetComponentInChildren<CarLanebehaviour>(), c);
        }

    }


    //create and add cars to the light
    private void CreateCars(CarLanebehaviour go, int count)  
    {
        Debug.Log(TrafficList.Count);
        for (int i = 0; i < count; i++)
        {
            TrafficList.Add(Instantiate(Traffic, go.GetLaneStart(), Quaternion.identity));
            TrafficList.Last().GetComponent<ActorPathFinding>().Setroute(go.GetLaneStart(), go.GetLaneStartSignal(), go.GetLaneExit());
            TrafficList.Last().GetComponent<ActorPathFinding>().watch = go.LampostManager.watch;
            TrafficList.Last().GetComponent<Movement>().Setup();
        }

    }

}
