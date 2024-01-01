using System.Collections;
using System.Collections.Generic;
using PaintIn3D;
using UnityEngine;


public class PenInputs : MonoBehaviour
{
    
    public CwPaintSphere pen;
    public Transform SnapTransform;
    public Transform RightHand;
    bool isGrabed1 = false;
    bool isGrabed2 = false;
    bool isGrabed3 = false;

   
    private void Start()
    {
        transform.GetComponent<MeshRenderer>().enabled = false;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            pen.Radius = 0.003f;
            Debug.Log("A Ű�� �������ϴ�.");
        }
        else if (Input.GetKey(KeyCode.B))
        {
            pen.Radius = 0.01f;
            Debug.Log("B Ű�� �������ϴ�.");
        }
        else if (Input.GetKey(KeyCode.C))
        {
            pen.Radius = 0.1f;
            Debug.Log("C Ű�� �������ϴ�.");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            pen.Radius = 0.3f;
            Debug.Log("D Ű�� �������ϴ�.");
        }
        else if (Input.GetKey(KeyCode.E))
        {
            pen.Radius = 1f;
            Debug.Log("E Ű�� �������ϴ�.");
        }

        //Ǫ��
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            Debug.Log("Ctrl Ű�� ���� �����Դϴ�.");
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt))
        {
            Debug.Log("Ctrl Ű�� ���� ���¿��� Alt Ű�� ������ �����Դϴ�.");
        }

        //���� 1
        if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("P Ű�� ���� �����Դϴ�.");
            isGrabed1 = true;
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("P Ű�� ���� ���¿��� L Ű�� ������ �����Դϴ�.");
            isGrabed1 = false;
        }
        //���� 2
        if (Input.GetKey(KeyCode.O))
        {
            Debug.Log("O Ű�� ���� �����Դϴ�.");
            isGrabed2 = true;
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("O Ű�� ���� ���¿��� K Ű�� ������ �����Դϴ�.");
            isGrabed2 = false;
        }
        //���� 3
        if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("I Ű�� ���� �����Դϴ�.");
            isGrabed3 = true;
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            Debug.Log("L Ű�� ���� ���¿��� J Ű�� ������ �����Դϴ�.");
            isGrabed3 = false;
        }

        if(isGrabed1 || isGrabed2 || isGrabed3)
        {
            transform.GetComponent<MeshRenderer>().enabled = true;
            transform.position = SnapTransform.position + new Vector3(-0.02f,0,0);
            
        }
        else
        {
            transform.GetComponent<MeshRenderer>().enabled = false;
        }

        transform.rotation = Quaternion.LookRotation(-SnapTransform.forward, SnapTransform.up);
        transform.rotation *= Quaternion.Euler(0, 100, 180);

    }
}
