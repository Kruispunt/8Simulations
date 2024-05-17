using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampWatch : MonoBehaviour
{




    private bool canGo = false;
    private bool SharesBus = false;

    // Define an event with a boolean parameter to notify subscribers
    public event Action<bool, bool> OnCanGoChanged;

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
