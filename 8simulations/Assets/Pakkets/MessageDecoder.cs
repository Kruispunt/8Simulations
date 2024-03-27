
using UnityEngine;

public class MessageDecoder
{

    
    public Pakket DecodeMessageToJson(string msg)
    {
        return JsonUtility.FromJson<Pakket>(msg);
    }


}
