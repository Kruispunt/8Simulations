
using UnityEngine;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

public class Clientbetter : MonoBehaviour
{
    public string serverIP = "169.254.116.160"; // Set this to your server's IP address.
    public int serverPort = 80;             // Set this to your server's port.
    private string messageToSend = "Victory For Vegeta!"; // The message to send.
    public string jsonjapp;

    public SimulatorManager simulatorManager;

   
    private TcpClient client;
    private NetworkStream stream;
    private Thread clientReceiveThread;

    void Start()
    {
        ConnectToServer();
    }

    void Update()
    {
        //disable this if you are sending from another script or a button
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //SendMessageToServer(messageToSend);
            SendMessageToServer(jsonjapp);
        }
    }

    void ConnectToServer()
    {
        try
        {
            client = new TcpClient(serverIP, serverPort);
            stream = client.GetStream();
            Debug.Log("Connected to server.");

            clientReceiveThread = new Thread(new ThreadStart(ListenForData));
            clientReceiveThread.IsBackground = true;
            clientReceiveThread.Start();
        }
        catch (SocketException e)
        {
            Debug.LogError("SocketException: " + e.ToString());
        }
    }

    private void ListenForData()
    {
        try
        {
            byte[] bytes = new byte[1024];
            while (true)
            {
                Debug.Log(stream.DataAvailable);
                // Check if there's any data available on the network stream
                if (stream.DataAvailable)
                {
                    int length;
                    // Read incoming stream into byte array.
                    while ((length = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        var incomingData = new byte[length];
                        Array.Copy(bytes, 0, incomingData, 0, length);
                        // Convert byte array to string message.
                        string serverMessage = Encoding.UTF8.GetString(incomingData);
                        Debug.Log("Server message received: " + serverMessage);
                        //simulatorManager.msg = serverMessage;
                        simulatorManager.SetString(serverMessage);
                       
                    }
                }
            }
        }
        catch (SocketException socketException)
        {
            Debug.Log("Socket exception: " + socketException);
        }
    }

    public void SendMessageToServer(string message)
    {
        //Debug.Log("Sent message to server: " + message);
        if (client == null || !client.Connected)
        {
            Debug.LogError("Client not connected to server.");
            return;
        }

        byte[] data = Encoding.UTF8.GetBytes(message);
        stream.Write(data, 0, data.Length);
        Debug.Log("Sent message to server: " + message);
    }

    void OnApplicationQuit()
    {
        if (stream != null)
            stream.Close();
        if (client != null)
            client.Close();
        if (clientReceiveThread != null)
            clientReceiveThread.Abort();
    }
}