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
            Debug.Log("A 키를 눌렀습니다.");
        }
        else if (Input.GetKey(KeyCode.B))
        {
            pen.Radius = 0.01f;
            Debug.Log("B 키를 눌렀습니다.");
        }
        else if (Input.GetKey(KeyCode.C))
        {
            pen.Radius = 0.1f;
            Debug.Log("C 키를 눌렀습니다.");
        }
        else if (Input.GetKey(KeyCode.D))
        {
            pen.Radius = 0.3f;
            Debug.Log("D 키를 눌렀습니다.");
        }
        else if (Input.GetKey(KeyCode.E))
        {
            pen.Radius = 1f;
            Debug.Log("E 키를 눌렀습니다.");
        }

        //푸시
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            Debug.Log("Ctrl 키가 눌린 상태입니다.");
        }
        else if (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt))
        {
            Debug.Log("Ctrl 키가 눌린 상태에서 Alt 키가 떼어진 상태입니다.");
        }

        //센서 1
        if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("P 키가 눌린 상태입니다.");
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            Debug.Log("P 키가 눌린 상태에서 L 키가 떼어진 상태입니다.");
        }
        //센서 2
        if (Input.GetKey(KeyCode.O))
        {
            Debug.Log("O 키가 눌린 상태입니다.");
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.Log("O 키가 눌린 상태에서 K 키가 떼어진 상태입니다.");
        }
        //센서 3
        if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("L 키가 눌린 상태입니다.");
        }
        else if (Input.GetKeyUp(KeyCode.J))
        {
            Debug.Log("L 키가 눌린 상태에서 J 키가 떼어진 상태입니다.");
        }
    }
}
