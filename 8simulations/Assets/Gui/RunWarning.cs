using UnityEngine;

public class RunWarning : MonoBehaviour
{


    public string Popup;

    [SerializeField]
    private GameObject ClientManager;

    private bool startClient = false;

    public bool StartClient
    {
        get
        {
            return startClient;
        }
        set
        {
            startClient = value;
            if (value == true)
            {
                ClientManager.SetActive(true);
                this.gameObject.SetActive(false);
            }
        }
    }
    //awake runs before start
    private void Awake()
    {
        //deactivate client to prevent errors
        //only activate when there is a server
        ClientManager.SetActive(false);

        Debug.Log(Popup);
    }




    // Update is called once per frame
    void Update()
    {
        if (!StartClient)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                this.StartClient = true;
            }
        }
    }
}
