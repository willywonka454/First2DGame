using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    public Animator wolfAnim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pounce()
    {
        StartCoroutine("pounce_once");
    }

    public void bite()
    {
        StartCoroutine("bite_once");
    }

    IEnumerator pounce_once()
    {
        wolfAnim.SetBool("Pouncing", true);

        yield return new WaitForSeconds(wolfAnim.GetCurrentAnimatorStateInfo(0).length);

        wolfAnim.SetBool("Pouncing", false);
    }

    IEnumerator bite_once()
    {
        wolfAnim.SetBool("Attacking", true);

        yield return new WaitForSeconds(wolfAnim.GetCurrentAnimatorStateInfo(0).length);

        wolfAnim.SetBool("Attacking", false);
    }
}
