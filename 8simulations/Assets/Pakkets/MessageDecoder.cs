
using Newtonsoft.Json;
using System.IO;
using UnityEngine;

public class MessageDecoder
{

    public MockDatagenerator mockDatagenerator;

    
    public Pakket DecodeMessageToJson(string msg)
    {
        return JsonUtility.FromJson<Pakket>(msg);
    }
    public void PrintPakket()
    {
        mockDatagenerator = new MockDatagenerator();
        string jsons = JsonConvert.SerializeObject(mockDatagenerator.generateIndex());
        string filePath = Path.Combine(Application.persistentDataPath, "playerData.json");

        File.WriteAllText(filePath, jsons);
        Debug.Log(filePath);
        Debug.Log("donelogging");


        //System.pr
    }
    public void PrintPakket(Index index)
    {
        string jsons = JsonConvert.SerializeObject(index);
        string filePath = Path.Combine(Application.persistentDataPath, "playerData.json");

        File.WriteAllText(filePath, jsons);


        //System.pr
    }


}
