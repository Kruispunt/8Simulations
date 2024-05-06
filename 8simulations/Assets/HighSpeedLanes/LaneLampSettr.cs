using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LaneLampSettr
{

    private bool SetupDone = false;

    public GloballaneManager worldspwanerManager;


    // Start is called before the first frame update

    public void SetupSettr(GloballaneManager globallaneManager)
    {
        this.worldspwanerManager = globallaneManager;
        SetupDone = true;
    }

    public void DecodeJappie(string jappei)
    {
        recieverpakket.SignalGroup gr = JsonConvert.DeserializeObject<recieverpakket.SignalGroup>(jappei);
        if (SetupDone)
        {
            updateLamps(gr);
        }
    }

    public void updateLamps(recieverpakket.SignalGroup lightCar)
    {
        Debug.Log(lightCar.ToString());
        Debug.Log(lightCar.blocksMsg.ToString());
        SetBlockLampsCarLaneA(lightCar.blocksMsg);
        Debug.Log("block1done");
        SetBlockLampsCarLaneB(lightCar.blocksMsg2);
    }

    public void SetBlockLampsCarLaneA(recieverpakket.blocksMsg msg)
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("setupcar");
            worldspwanerManager.Carlanes[i].GetComponentInChildren<CarLanebehaviour>().SetLampLight(msg.A.Cars[i]);
            worldspwanerManager.WalkLanes[i].GetComponentInChildren<WalkLanebehaviour>().SetLampLight(msg.A.Walkers[i]);
        }

        for (int i = 4; i < 4 + 4; i++)
        {
            worldspwanerManager.Carlanes[i].GetComponentInChildren<CarLanebehaviour>().SetLampLight(msg.B.Cars[i - 4]);
            worldspwanerManager.WalkLanes[i].GetComponentInChildren<WalkLanebehaviour>().SetLampLight(msg.B.Walkers[i - 4]);
        }
        for (int i = 4 + 4; i < 4 + 4 + 4; i++)
        {
            worldspwanerManager.Carlanes[i].GetComponentInChildren<CarLanebehaviour>().SetLampLight(msg.C.Cars[i - (4 + 4)]);
        }



        SetLampsBikelanesA(msg);

    }
    public void SetBlockLampsCarLaneB(recieverpakket.blocksMsg2 msg)
    {
        for (int i = 0; i < 4; i++)
        {
            worldspwanerManager.CarlanesB[i].GetComponentInChildren<CarLanebehaviour>().SetLampLight(msg.D.Cars[i]);
        }

        for (int i = 4; i < 4 + 3; i++)
        {
            worldspwanerManager.CarlanesB[i].GetComponentInChildren<CarLanebehaviour>().SetLampLight(msg.E.Cars[i - 4]);
        }
        for (int i = 4 + 3; i < 4 + 3 + 4; i++)
        {
            worldspwanerManager.CarlanesB[i].GetComponentInChildren<CarLanebehaviour>().SetLampLight(msg.F.Cars[i - (3 + 4)]);
        }


        for (int i = 0; i < 4; i++)
        {
            worldspwanerManager.WalkLanesB[i].GetComponentInChildren<WalkLanebehaviour>().SetLampLight(msg.E.Walkers[i]);

        }
        for (int i = 0; i < 4; i++)
        {
            worldspwanerManager.WalkLanesB[i].GetComponentInChildren<WalkLanebehaviour>().SetLampLight(msg.F.Walkers[i]);

        }
        SetLampsBikelanesB(msg);
    }


    public void SetLampsBikelanesA(recieverpakket.blocksMsg msg)
    {
        for (int i = 0; i < 2; i++)
        {
            worldspwanerManager.BikeLanes[i].GetComponentInChildren<FietsLaanBehaviour>().SetLampLight(msg.A.bikers[i]);
        }
        for (int i = 2; i < 2 + 2; i++)
        {
            worldspwanerManager.BikeLanes[i].GetComponentInChildren<FietsLaanBehaviour>().SetLampLight(msg.B.bikers[i - 2]);
        }


    }


    public void SetLampsBikelanesB(recieverpakket.blocksMsg2 msg)
    {
        for (int i = 0; i < 2; i++)
        {
            worldspwanerManager.BikeLanesB[i].GetComponentInChildren<FietsLaanBehaviour>().SetLampLight(msg.E.bikers[i]);
        }
        for (int i = 2; i < 2 + 2; i++)
        {
            worldspwanerManager.BikeLanesB[i].GetComponentInChildren<FietsLaanBehaviour>().SetLampLight(msg.F.bikers[i - 2]);
        }


    }
}
