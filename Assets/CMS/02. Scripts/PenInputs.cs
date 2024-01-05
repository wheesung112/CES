using System.Collections;
using System.Collections.Generic;
using PaintIn3D;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class PenInputs : MonoBehaviour
{
   
    public CwPaintSphere pen;
    public Transform SnapTransform;
    public Transform RightHand;
    public Transform penPoint;
    public Transform rayPoint;
    bool isGrabed1 = false;
    bool isGrabed2 = false;
    bool isGrabed3 = false;

    //RayAndLineRenderer ral;

    private void Start()
    {
        //ral = GetComponent<RayAndLineRenderer>();
        transform.GetComponent<MeshRenderer>().enabled = false;
        pen.Radius = 0;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha0))
        {
            pen.Radius = 0f;
        }
        else if (Input.GetKey(KeyCode.Alpha1))
        {
            pen.Radius = 0.003f;
            
        }
        else if (Input.GetKey(KeyCode.Alpha2))
        {
            pen.Radius = 0.005f;
            
        }
        else if (Input.GetKey(KeyCode.Alpha3))
        {
            pen.Radius = 0.008f;
            
        }
        else if (Input.GetKey(KeyCode.Alpha4))
        {
            pen.Radius = 0.010f;
            
        }
        else if (Input.GetKey(KeyCode.Alpha5))
        {
            pen.Radius = 0.013f;
            
        }
        else if (Input.GetKey(KeyCode.Alpha6))
        {
            pen.Radius = 0.016f;
            
        }
        else if (Input.GetKey(KeyCode.Alpha7))
        {
            pen.Radius = 0.019f;
            
        }
        else if (Input.GetKey(KeyCode.Alpha8))
        {
            pen.Radius = 0.02f;
            
        }
        else if (Input.GetKey(KeyCode.Alpha9))
        {
            pen.Radius = 0.025f;
            
        }

        //if (ral.isRayed)
        {
         
            // if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
            // {
            //     Debug.Log("Ctrl 키가 눌러져 있습니다. 상호 작용을 종료합니다.");
                

            // }
            // else if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
            // {
            //     Debug.Log("Alt 키가 눌러져 있습니다. 상호 작용을 시작합니다.");
                

            // }
        }

        //���� 1
        if (Input.GetKey(KeyCode.J))
        {
            Debug.Log("P Ű�� ���� �����Դϴ�.");
            isGrabed1 = true;
        }
        else if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("P Ű�� ���� ���¿��� L Ű�� ������ �����Դϴ�.");
            isGrabed1 = false;
        }
        //���� 2
        if (Input.GetKey(KeyCode.K))
        {
            Debug.Log("O Ű�� ���� �����Դϴ�.");
            isGrabed2 = true;
        }
        else  if (Input.GetKey(KeyCode.O))
        {
            Debug.Log("O Ű�� ���� ���¿��� K Ű�� ������ �����Դϴ�.");
            isGrabed2 = false;
        }
        //���� 3
        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("I Ű�� ���� �����Դϴ�.");
            isGrabed3 = true;
        }
        else if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("L Ű�� ���� ���¿��� J Ű�� ������ �����Դϴ�.");
            isGrabed3 = false;
        }

        if(isGrabed1 || isGrabed2 || isGrabed3)
        {
            transform.GetComponent<MeshRenderer>().enabled = true;
            //transform.position = SnapTransform.position + new Vector3(0,0,0);
            //transform.position = SnapTransform.position + -transform.up * 0.02f;
            penPoint.position = SnapTransform.position;
        }
        else
        {
            transform.GetComponent<MeshRenderer>().enabled = false;
        }

        transform.rotation = Quaternion.LookRotation(-SnapTransform.forward, SnapTransform.up);
        transform.rotation *= Quaternion.Euler(0, 100, 30);
        
    }
}
