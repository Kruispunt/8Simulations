
using UnityEngine;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using UnityEngine.Rendering;
using System.IO;
using System.Collections;
using UnityEngine.Events;


public class Clientbetter : MonoBehaviour
{
    public string serverIP = "169.254.116.160"; // Set this to your server's IP address.
    public int serverPort = 80;             // Set this to your server's port.
    private string messageToSend = "Victory For Vegeta!"; // The message to send.
    public string jsonjapp;
    public string kees;

    public float MessagePostTime = 5;

    public bool updatedKees = false;
    public bool ClientActive = false;
    public bool ConnectonOnline = false;
    public bool PostOnKey = false;

    public GloballaneManager manager;
    public SimulatorManager simulatorManager;

    public MessageDecoder decoder;
    private TcpClient client;
    private NetworkStream stream;
    private Thread clientReceiveThread;


    public SignalGroup SignalGroup = new SignalGroup();

    public UnityEvent<bool> onServerStart;

    public UnityEvent<bool> SenderThreadState;
    public UnityEvent<bool> ReceiverThreadState;


    void Start()
    {
        //string filePath = Path.Combine(Application.persistentDataPath, "ControllerToSim.json");
        //string path = Application.persistentDataPath + "/ControllerToSim.json";
        //StreamReader reader = new StreamReader(path);
        //Debug.Log(reader.ReadToEnd());
        //reader.Close();

        //Debug.Log(filePath);
        //kees = File.ReadAllText(filePath);
        Debug.Log(kees + "derpderpderp");
        decoder = new MessageDecoder();
        decoder.PrintPakket();
        ConnectToServer();
    }

    void Update()
    {
        //disable this if you are sending from another script or a button
        if (Input.GetKeyDown(KeyCode.Space) && this.PostOnKey)
        {
            SendMessageToServer(messageToSend);
            SendMessageToServer(jsonjapp);
        }
    }


    public void PostIp(string ip)
    {
        this.serverIP = ip;
    }

    public void StartClient()
    {
        ConnectToServer();
    }

    public void SetPostRate(float time)
    {
        this.MessagePostTime = time;
    }
    //true is post on key
    public void SetPostMode(bool mode)
    {
        this.PostOnKey = mode;
        if (!this.PostOnKey)
        {
            StartCoroutine(TimedPoster(this.MessagePostTime));
        }
    }

    public float GetPostRate()
    {
        return this.MessagePostTime;
    }
    void ConnectToServer()
    {
        onServerStart.Invoke(true);
        StartCoroutine(TimedPoster(5));
        ReceiverThreadState.Invoke(true);
        try
        {
            client = new TcpClient(serverIP, serverPort);
            stream = client.GetStream();
            //Debug.Log("Connected to server.");

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
            byte[] bytes = new byte[5000];
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
                        kees = serverMessage;
                        this.updatedKees = true;
                        Debug.Log("Server message received: " + serverMessage);
                       
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
        SenderThreadState.Invoke(true);
        //Debug.Log("Sent message to server: " + message);
        if (client == null || !client.Connected)
        {
            Debug.LogError("Client not connected to server.");
            return;
        }

        byte[] data = Encoding.UTF8.GetBytes(message);
        //byte[] data = Encoding.UTF8.GetBytes(pakketmsg);

        //byte[] data = Encoding.UTF8.GetBytes(jopson);

        //byte[] data = Encoding.UTF8.GetBytes(message);
        stream.Write(data, 0, data.Length);
        //Debug.Log("Sent message to server: " + message);
        SenderThreadState.Invoke(false);
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

    IEnumerator TimedPoster(float time)
    {
        //refresh simulation state 5 secs
        yield return new WaitForSeconds(time);
        SendMessageToServer(jsonjapp);

        StartCoroutine(TimedPoster(time));
    }


}
