using UnityEngine;

public class BsuBeaviour : MonoBehaviour
{

    // Line number for the bus route
    [SerializeField]
    private string lineNr;

    // Properties to access private fields if necessary
    public string LineNr
    {
        get { return lineNr; }
        set { lineNr = value; }
    }

    // Private fields for components, following naming conventions
    private Movement movement;
    private ActorInfo actorInfo;
    private ActorPathFinding actorPathFinding;

    // Awake is called when the script instance is being loaded
    private void Awake()
    {
        // Initialize components
        movement = GetComponent<Movement>();
        actorInfo = GetComponent<ActorInfo>();
        actorPathFinding = GetComponent<ActorPathFinding>();

        // Optionally, handle null components
        if (movement == null || actorInfo == null || actorPathFinding == null)
        {
            Debug.LogError("One or more required components are missing from the bus.");
        }
    }

    // SetRoutePoints should define the points for the bus route
    public void SetRoutePoints()
    {
        // Implementation depends on how you want to set the route points
    }

}
