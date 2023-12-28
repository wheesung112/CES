using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class OpenFolder : XRSocketInteractor
{
    public List<GameObject> Hierarchy;
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {

        // snap된 오브젝트의 이름 가져오기
        string snappedObjectName = args.interactable.name;
        args.interactable.GetComponent<AnimController>().StartAnim();
        // Attach Transform 가져오기
        for (int i = 0; i < Hierarchy.Count; i++)
        {
            string conts = Hierarchy[i].name.Split("_")[0];
            Hierarchy[i].SetActive(snappedObjectName.Contains(conts));
        }
        Debug.Log("Snapped Object Name: " + snappedObjectName);
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        args.interactable.GetComponent<AnimController>().CloseAnim();
        for (int i = 0; i < Hierarchy.Count; i++)
        {
            Hierarchy[i].SetActive(false);
        }
        
    }
}
