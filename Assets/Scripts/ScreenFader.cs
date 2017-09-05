using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour {

    Animator anim;
    public bool isFading = false;

	void Start () {
        anim = GetComponent<Animator> ();

    }

    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeIn");

        while (isFading)
        {
            yield return null;
        }
        Debug.Log("CLEAR");
        
    }

    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("FadeOut");

        while (isFading)
        {
            yield return null;
        }
        Debug.Log("BLACK");
    }

    void AnimationComplete() //This function is called at the end of the animation
    {
        isFading = false;

    }

}
