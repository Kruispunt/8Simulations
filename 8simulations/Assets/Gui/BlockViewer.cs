using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockViewer : MonoBehaviour
{
    private Vector3 OriginalCamOffset;
    public float rotationSpeed;
    public float maxThresl;
    public GameObject CurrentFocus;

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

    private void Start()
    {
        OriginalCamOffset = Camoffset;
        Cam = Camera.main;
        Cam.transform.position = BlockA.transform.position;
        currentfocus = 1;
    }

    private GameObject getCurrentFocus()
    {
        switch (currentfocus)
        {
                case 1:return BlockA;
                case 2: return BlockB;
                case 3: return BlockC;
                case 4: return BlockD;
                case 5: return BlockE;
                default:
                currentfocus = 1;
                return BlockA;
        }

    }



    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentfocus++;
            Camoffset = OriginalCamOffset;
        }
        transform.position = getCurrentFocus().transform.position + Camoffset;
        transform.LookAt(getCurrentFocus().transform.forward + Camoffset);
        Camoffset += transform.right * rotationSpeed * Time.deltaTime;


    }





}
