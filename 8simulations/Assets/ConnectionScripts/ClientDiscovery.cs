using System.Net;
using System.Net.Sockets;
using UnityEngine;

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