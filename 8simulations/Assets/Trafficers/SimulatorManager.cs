using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimulatorManager : MonoBehaviour
{

    [SerializeField]
    public static string ServerCommands;

    public int timeInSec;
    public int SpawnMin,SpawnMax;

    public string msg;

    public bool setupDone = false;

    public GameObject Traffic;
    public List<GameObject> TrafficList;
    public VerkeerslichtBoulder StopLichtManager;


    //called by the client upon the first frame
    void setup(string msg)
    {
        SetString(msg);
        TrafficList = new List<GameObject>();
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(Simutick(timeInSec));
        setupDone = true;
    }
    void Start()
    {
        TrafficList = new List<GameObject>();
        //Start the coroutine we define below named ExampleCoroutine.
        StartCoroutine(Simutick(timeInSec));
    }

    //time based loop for refreshing important things
    IEnumerator Simutick(int timeInSec)
    {
        //refresh simulation state 5 secs
        yield return new WaitForSeconds(timeInSec);
        SpawnRandomCars(1, 5);
    }

    //use this to assign cars to lights
    private void SpawnRandomCars(int min, int max)
    {
        foreach (var item in StopLichtManager.verkeersLightsscrips)
        {
            int c = UnityEngine.Random.Range(min, max);
            CreateCars(item, c);
        }
    }


    //create and add cars to the light
    private void CreateCars(VerkeersLight stop, int count)
    {
        for (int i = 0; i < count; i++)
        {
            TrafficList.Add(Instantiate(Traffic, stop.transform.position, Quaternion.identity));
            stop.lane.AddCarToQue(TrafficList.Last().GetComponent<SimuAuto>());
            TrafficList.Last().GetComponent<SimuAuto>().stopllicht = stop;
            TrafficList.Last().GetComponent<SimuAuto>().PlaceToPark = this.transform.position;
        }

    }

    //old logic for reading controller pakkets
    public void SetString(string msg)
    {
        this.msg = msg;
        Debug.Log(msg + "victory");
        //string("1,1,2,3,3,2")
        char[] chars = msg.ToCharArray();
        Debug.Log(chars);
        Debug.Log(chars[0]);
        Debug.Log(chars[2]);
        Debug.Log(chars[4]);
        Debug.Log(chars[6]);
        Debug.Log(chars[8]);
        Debug.Log(chars[10]);
        int pops = chars[0];
        int statestop = chars[1];


        if (!StopLichtManager.SetupDone)
        {
            //StopLichtManager.Setup(pops, statestop);
        }
        else
        {
            StopLichtManager.UpdateFromControl(pops, statestop);
        }
        if(!setupDone)
        {

            setup(msg);
        }

    }


}
