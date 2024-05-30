using System;
using System.Collections;
using UnityEngine;

public class LampWatch : MonoBehaviour
{




    private bool canGo = true;
    private bool SharesBus = false;

    private void Start()
    {
        StartCoroutine(PublishLoop());
    }


    // Define an event with a boolean parameter to notify subscribers
    public event Action<bool, bool> OnCanGoChanged;

    IEnumerator PublishLoop()
    {
        while (true) // Loop indefinitely
        {
            //DetectVehiclesInFront();
            OnCanGoChanged?.Invoke(canGo, SharesBus);
            yield return new WaitForSeconds(2); // Wait for 2 seconds before the next scan
        }
    }


    public void BussPassedLane()
    {
        SharesBus = false;
        OnCanGoChanged?.Invoke(canGo, SharesBus);
    }

    public void BusEnteredlane()
    {
        SharesBus = true;
        OnCanGoChanged?.Invoke(canGo, SharesBus);
    }


    // Property to encapsulate canGo with the event trigger
    public bool CanGo
    {
        get { return canGo; }
        set
        {
            if (canGo != value)
            {
                canGo = value;
                // Raise the event to notify subscribers with the new value
                OnCanGoChanged?.Invoke(canGo, SharesBus);
            }
        }
    }


}



