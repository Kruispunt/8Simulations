using UnityEngine;

public class LaneStateLocal : MonoBehaviour
{

    public LampostManager manager;

    public LampWatch watch;

    private void Start()
    {
        manager = GetComponentInChildren<LampostManager>();
    }


    public bool IsGreen()
    {
        return watch.CanGo;
    }
}
