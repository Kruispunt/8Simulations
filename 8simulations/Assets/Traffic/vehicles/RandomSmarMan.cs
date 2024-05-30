using System.Collections;
using UnityEngine;

public class RandomSmarMan : MonoBehaviour
{

    public int timeInSec;
    public GloballaneManager manie;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Simutick(timeInSec));
    }

    IEnumerator Simutick(int timeInSec)
    {
        //refresh simulation state 5 secs
        yield return new WaitForSeconds(timeInSec);
        StartCoroutine(Simutick(timeInSec));
    }


    void randomizeposses()
    {

    }
}
