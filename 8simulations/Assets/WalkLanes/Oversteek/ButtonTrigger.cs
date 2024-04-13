using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{


    private WalkLanebehaviour walkLaneBehaviour;

    //when to press the button
    public float PressRadius;


    public void Setup(WalkLanebehaviour lanebehaviour)
    {
        this.walkLaneBehaviour = lanebehaviour;
    }


    public void PressButton()
    {
        walkLaneBehaviour.ButtonPressed();
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<ActorInfo>().IsWalker())
        {
            this.PressButton();
        }
    }
}
