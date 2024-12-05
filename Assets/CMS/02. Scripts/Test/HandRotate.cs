using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandRotate : MonoBehaviour
{
    public MeshRenderer pen;
    public GameObject pleteCanvas;
    // Start is called before the first frame update
    void Start()
    {
        pleteCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (pen.enabled)
        {
            if (155 < transform.rotation.eulerAngles.z && transform.rotation.eulerAngles.z < 200)
            {
                pleteCanvas.SetActive(true);
            }
            else
            {
                pleteCanvas.SetActive(false);
            }
            //data.text = transform.rotation.eulerAngles.ToString();
        }
    }
}
