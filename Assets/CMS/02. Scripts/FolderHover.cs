using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderHover : MonoBehaviour
{
    bool canDrag = false;
    bool isDragging = false;
    Vector3 offset;
    Vector3 startPosition;
    private float lastClickTime = 0;
    private float doubleClickTimeThreshold = 0.2f;

    bool isPassibleOpen = false;
   
    private void Start()
    {
        startPosition = transform.position;
        //print(startPosition);
    }
    void OnMouseDown()
    {
        
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            float currentTime = Time.time;
            if (currentTime - lastClickTime < doubleClickTimeThreshold)
            {
                OnDoubleClick();
            }

            // 마지막 클릭 시간 갱신
            lastClickTime = currentTime;
        }
    }
    
    private void OnMouseUp()
    {
        transform.position = startPosition;
        transform.rotation = new Quaternion(0,0,0,0);
        if (isPassibleOpen) OpenFolderData();
    }
    void OnMouseEnter()
    {
        canDrag = true;
        //Debug.Log("들어감");
        transform.localScale = new Vector3(1.5f, 1.5f, 1f);
    }

    void OnMouseExit()
    {
        //Debug.Log("나감");
        canDrag = false;
        transform.localScale = new Vector3(1, 1, 1f);
        
    }
    private void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        print(distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

        //objPos.z = 0;
        //objPos.x = 0;

        // 첫 번째 대상에 회전값 적용

        transform.LookAt(Camera.main.transform);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y - 90f, 0);
        transform.position = objPos;
        //transform.localPosition = objPos;
    }
    void Update()
    {
        
    }
    void OnDoubleClick()
    {
        Debug.Log( transform.name + "더블 클릭");
    }

    public void isPassibleOpenFolder(bool isopened)
    {
        isPassibleOpen = isopened;
    }
    public void OpenFolderData()
    {
        Debug.Log($"{transform.name} 폴더 열기");
    }
    public void CloseFolderData()
    {
        Debug.Log($"{transform.name} 폴더 닫기");
    }
}
