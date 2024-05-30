using System;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{

    private bool buttonPressed = false;


    private bool emptyAfterpress;
    // Define an event with a boolean parameter to notify subscribers
    public event Action<bool> OnButtonPressed;

    // Property to encapsulate buttonPressed with the event trigger
    public bool ButtonPressed
    {
        get => buttonPressed;
        private set // Make the setter private if it should only be called within this class
        {
            if (buttonPressed != value)
            {
                buttonPressed = value;
                // Raise the event to notify subscribers with the new value
                OnButtonPressed?.Invoke(buttonPressed);
            }
        }
    }

    private WalkLanebehaviour walkLaneBehaviour;

    public void Setup(WalkLanebehaviour laneBehaviour)
    {
        walkLaneBehaviour = laneBehaviour;
    }

    public void ResetButton()
    {
        buttonPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Use TryGetComponent for better performance and to avoid null reference if the component is not found
        if (other.TryGetComponent(out ActorInfo actorInfo) && actorInfo.IsWalker())
        {
            // Assuming you want to set buttonPressed to true when a walker enters the trigger
            ButtonPressed = true;
            emptyAfterpress = false;
            walkLaneBehaviour.OnDetect();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Optionally, reset buttonPressed when the walker exits the trigger
        if (other.TryGetComponent(out ActorInfo actorInfo) && actorInfo.IsWalker())
        {
            emptyAfterpress = true;
        }
    }


}
