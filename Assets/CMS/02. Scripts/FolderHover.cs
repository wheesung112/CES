using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderHover : MonoBehaviour
{
    bool canDrag = false;
    bool isDragging = false;
    Vector3 offset;
    Vector3 startPosition;
    private void Start()
    {
        startPosition = transform.position;
        print(startPosition);
    }
    void OnMouseDown()
    {
        
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    
    private void OnMouseUp()
    {
        transform.position = startPosition;
    }
    void OnMouseEnter()
    {
        canDrag = true;
        //Debug.Log("들어감");
        transform.localScale = new Vector3(1.5f, 1.5f, 0.2f);
    }

    void OnMouseExit()
    {
        //Debug.Log("나감");
        canDrag = false;
        transform.localScale = new Vector3(1, 1, 0.2f);
        
    }
    private void OnMouseDrag()
    {
        float distance = Camera.main.WorldToScreenPoint(transform.position).z;

        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPos = Camera.main.ScreenToWorldPoint(mousePos);

        objPos.z = 0;
        //objPos.x = 0;
        transform.position = objPos;
    }
    void Update()
    {
      
    }
}
