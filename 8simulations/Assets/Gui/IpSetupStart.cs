using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IpSetupStart : MonoBehaviour
{

    public bool ServerStarted = false;

    public bool IpChanged = false;
    public GameObject GuiBoxes;
    // Start is called before the first frame update


    public void CloseMenuAndConnect()
    {
        if (IpChanged)
        {
            ServerStarted = true;
            GuiBoxes.SetActive(false);
        }
    }

    public void EnteredIp(string ip)
    {
        IpChanged = true;
    }
}
