using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class AnimController : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = transform.GetComponent<Animator>();
    }

    public void StartAnim()
    {
        anim.SetTrigger("Open");
    }
    public void CloseAnim()
    {
        anim.SetTrigger("Close");
    }
    
}
