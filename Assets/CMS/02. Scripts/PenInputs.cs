using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenInputs : MonoBehaviour
{
    public DrawingMarker everPen;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            everPen.SetPenSize(5);
            Debug.Log("A Ű�� �������ϴ�.");
        }
        else if (Input.GetKey(KeyCode.B))
        {
            everPen.SetPenSize(7);
            Debug.Log("B Ű�� �������ϴ�.");
        }
        else if (Input.GetKey(KeyCode.C))
        {
            everPen.SetPenSize(9);
            Debug.Log("C Ű�� �������ϴ�.");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            everPen.SetPenSize(11);
            Debug.Log("D Ű�� �������ϴ�.");
        }
        else if (Input.GetKey(KeyCode.E))
        {
            everPen.SetPenSize(13);
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
