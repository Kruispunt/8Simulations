using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StateDisplay : MonoBehaviour
{
    private bool truelink;
    public bool Sink
    {
        get
        {
            return truelink;
        }
        set
        {
            truelink = value;
            UpdateListner();

        }
    }



    public UnityEvent<bool> onBoolUpdated;

    private void Start()
    {
        //StartCoroutine(toggleauto());
    }

    IEnumerator toggleauto()
    {
        yield return new WaitForSeconds(1);
        Sink = !Sink;
        StartCoroutine(toggleauto());
    }

    public void UpdateListner()
    {
        onBoolUpdated.Invoke(Sink);

    }


}
