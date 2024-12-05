using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FileManager : MonoBehaviour
{
    //파일 리스트 내용
    //지금은 Resources에 넣어서 할 예정 -> 추후엔 파일 시스템 구축 필요
    public List<string> filePath;
    //public Transform rightController;
    //public Transform leftController;
    public float smoothSpeed = 2.0f;

    bool canDrag = false;
    bool isDragging = false;
    bool isGrab = false;
    Transform startTransform;
    public void FolderHovered()
    {
        //transform.GetComponent<XRGrabInteractable>().trackPosition = true;
        transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
    }
    public void FolderOut()
    {
        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;
        transform.localScale = new Vector3(1, 1, 1);

    }
    public void FolderSelected()
    {
        isGrab = true;
        transform.rotation = new Quaternion(0, 0, 0, 0);
        //transform.LookAt(rightController);
        //transform.rotation *= Quaternion.Euler(0,180,0);
        print("Selected" + transform.name);
    }

    public void FolderDisSelected()
    {
        isGrab = false;
        //transform.GetComponent<XRGrabInteractable>().trackPosition = false;
        transform.position = startTransform.position;
        transform.rotation = startTransform.rotation;
        print("Dis Selected");
    }
    public void RotSelect()
    {
        transform.localRotation = Quaternion.Euler(0,180,0);
        print("Set Rot select : " + transform.localRotation.eulerAngles);
    }
    public void RotDisSelect()
    {
        //transform.localRotation = Quaternion.Euler(0,0,0);
        //print("Set Rot diselect : " + transform.localRotation.eulerAngles);
    }
    void Start()
    {
        startTransform = transform;
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

 

}
