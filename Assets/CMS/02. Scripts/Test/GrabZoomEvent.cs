using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabZoomEvent : MonoBehaviour
{
    public void ShowZoom()
    {
        transform.GetChild(0).gameObject.SetActive(true);
    }
    public void EndZoom()
    {
        transform.GetChild(0).gameObject.SetActive(false);
    }
}
