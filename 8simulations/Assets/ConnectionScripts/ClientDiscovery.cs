using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.Networking;

public class ClientDiscovery : MonoBehaviour
{

    NetworkStream NetworkStream;

    // Start is called before the first frame update
    void Start()
    {

        LogLocalIPAddress();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LogLocalIPAddress()
    {
        IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                Debug.Log("Local IP Address: " + ip);
            }
            Debug.Log("Local IP Address: " + ip);
        }
    }
}