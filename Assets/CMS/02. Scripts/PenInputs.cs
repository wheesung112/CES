using System.Collections;
using System.Collections.Generic;
using PaintIn3D;
using UnityEngine;

public class PenInputs : MonoBehaviour
{
    public CwPaintSphere pen;
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
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("P Ű�� ���� ���¿��� L Ű�� ������ �����Դϴ�.");
        }
        //���� 2
        if (Input.GetKey(KeyCode.O))
        {
            Debug.Log("O Ű�� ���� �����Դϴ�.");
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("O Ű�� ���� ���¿��� K Ű�� ������ �����Դϴ�.");
        }
        //���� 3
        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("L Ű�� ���� �����Դϴ�.");
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            Debug.Log("L Ű�� ���� ���¿��� J Ű�� ������ �����Դϴ�.");
        }
    }
}
