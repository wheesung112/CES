using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachObject : MonoBehaviour
{
    public GameObject hand;
    bool checkSelect = false;
    private bool isAttached = false;
    bool isFloored = false;
    bool isHovered = false;
    public void setFloored(bool floor)
    {
        isFloored = floor;
    }

    public bool getFloored()
    {
        return isFloored;
    }

    public void setAttached(bool floor)
    {
        isAttached = floor;
    }

    public bool getAttached()
    {
        return isAttached;
    }
    private void Awake()
    {
        if (!isAttached)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, -transform.up);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = hit.point;
                if (isFloored)
                    targetPosition.y += 0.001f;
                else
                    targetPosition.z += 0.001f;

                // ȸ�� �� ��������
                //Quaternion targetRotation = Quaternion.LookRotation(hit.normal);

                // �̵� �� ȸ�� ����
                transform.position = targetPosition;
                //transform.rotation = targetRotation;

                isAttached = true;
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, -transform.up * 10f, Color.green);

        if (!isAttached)
        {
            RaycastHit hit;
            Ray ray = new Ray(transform.position, -transform.up);

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 targetPosition = hit.point;
                if (isFloored)
                    targetPosition.y += 0.001f;
                else
                    targetPosition.z += 0.001f;

                // ȸ�� �� ��������
                //Quaternion targetRotation = Quaternion.LookRotation(hit.normal);

                // �̵� �� ȸ�� ����
                transform.position = targetPosition;
                //transform.rotation = targetRotation;

                isAttached = true;
            }
        }
    }
    
    void Update(){
        if(isHovered){
            if (Input.GetKey(KeyCode.LeftControl))
            {
                checkSelect = true;
                // Code to execute when Left Control key is held down
            }
        }
        if(checkSelect){
            transform.position = hand.transform.position;
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                isAttached = false;
                checkSelect = false;
            }
        }
    
    }

    public void Hovered(){
        isHovered = true;
    }
    public void HoverCancle(){
        isHovered = false;
    }
    public void SelectExited()
    {
        isAttached = false;
    }
}
