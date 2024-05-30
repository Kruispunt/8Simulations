using UnityEngine;
using UnityEngine.Events;

public class BlockViewer : MonoBehaviour
{
    private Vector3 OriginalCamOffset;
    public float rotationSpeed;
    public float maxThresl;
    public GameObject Target;

    public bool ToggledInput = false;

    int currentfocus = 1;

    public GameObject BlockA;
    public GameObject BlockB;
    public GameObject BlockC;
    public GameObject BlockD;
    public GameObject BlockE;
    public GameObject BlockF;
    //5

    public Vector3 Camoffset;

    public Camera Cam;

    public UnityEvent<string> OnBlockSwitch;

    private void Start()
    {
        OriginalCamOffset = Camoffset;
        Cam = Camera.main;
        Cam.transform.position = BlockA.transform.position;
        currentfocus = 1;
        Target = getCurrentFocus();
    }

    private GameObject getCurrentFocus()
    {
        switch (currentfocus)
        {
            case 1:
                OnBlockSwitch.Invoke("A");
                return BlockA;
            case 2:
                OnBlockSwitch.Invoke("B");
                return BlockB;
            case 3:
                OnBlockSwitch.Invoke("C");
                return BlockC;
            case 4:
                OnBlockSwitch.Invoke("D");
                return BlockD;
            case 5:
                OnBlockSwitch.Invoke("E");
                return BlockE;
            case 6:
                OnBlockSwitch.Invoke("F");
                return BlockF;
            default:
                currentfocus = 1;
                OnBlockSwitch.Invoke("A");
                return BlockA;
        }

    }



    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentfocus++;
            Target = getCurrentFocus();
        }
        Transform target = Target.transform;

        this.transform.position = target.position - target.forward * Camoffset.z + target.up * Camoffset.y;
        transform.LookAt(target);



    }





}
