using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;

public class RotateWithControllerDirection : XRGrabInteractable
{
    public GameObject controller;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        transform.rotation = Quaternion.Euler(90,0,0);
        
    }
}
