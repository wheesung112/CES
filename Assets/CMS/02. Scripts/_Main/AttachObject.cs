using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttachObject : MonoBehaviour
{
    public GameObject SizeCanvas;
    public GameObject hand;
    bool checkSelect = false;
    private bool isAttached = false;
    bool isFloored = false;
    bool isHovered = false;

    bool isScaled = false;
    Vector3 initialScale;


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
        SizeCanvas.SetActive(false);
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
    bool isinput = false;
    bool isLinput = false;
    void Update(){ 
        // if(isScaled){
        //     if (Input.GetKey(KeyCode.LeftControl))
        //     {
        //         initialScale = transform.localScale;
        //         isinput = true;
        //     }
        //     if(isinput)
        //     {
        //         float distance = Vector3.Distance(transform.position, hand.transform.position);
        //         // 여기에서 거리를 이용하여 transform의 크기를 조절합니다.
            
        //         float scaleFactor = distance / initialScale.magnitude; // 원래 크기 대비 거리 비율 계산
        //         Vector3 newScale = initialScale * scaleFactor * 100;

        //         // 최소 크기 제한을 설정할 수 있습니다.
                
        //         //newScale = Vector3.Max(newScale, Vector3.one * minScale);
                
        //         transform.localScale =initialScale + newScale;
        //         text.text = transform.localScale.ToString();
        //         if (Input.GetKey(KeyCode.LeftAlt))
        //         {
        //             //isScaled = false;
        //             isinput = false;
        //         }
        //     }   
        // }
        //else
        {
        if(isHovered){
            if (Input.GetKey(KeyCode.LeftControl))
            {
                checkSelect = true;
                // Code to execute when Left Control key is held down
            }
        }
        if(checkSelect){
            transform.position = hand.transform.position;
            SizeCanvas.SetActive(true);
            if (Input.GetKey(KeyCode.LeftAlt))
            {
                SizeCanvas.SetActive(false);
                isAttached = false;
                checkSelect = false;
            }
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
         isinput = false;
         isScaled = false;
        isAttached = false;
    }
    public void setSelected(){
        
        isScaled = true;
       
       
    }
}
