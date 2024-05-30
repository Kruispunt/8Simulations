using UnityEngine;
using UnityEngine.UI;

public class ImageLogicstate : MonoBehaviour
{


    private Image img;
    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    public void BooleanDisplay(bool val)
    {
        if (val)
        {
            img.color = Color.green;
        }
        else
        {
            img.color = Color.red;
        }
    }

    public void SetColour(Color col)
    {
        img.color = col;
    }

    public void SetToRed()
    {
        img.color = Color.red;
    }
    public void SetToGreen()
    {
        img.color = Color.green;
    }
}
