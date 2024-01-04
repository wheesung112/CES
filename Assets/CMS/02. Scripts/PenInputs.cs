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

        //푸시
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            Debug.Log("Ctrl 키가 눌린 상태입니다.");
           
        }
        else  if (Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt))
        {
            Debug.Log("Ctrl 키가 눌린 상태에서 Alt 키가 떼어진 상태입니다.");
           
        }

        //센서 1
        if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("P 키가 눌린 상태입니다.");
            isGrabed1 = true;
        }
        else if (Input.GetKey(KeyCode.L))
        {
            Debug.Log("P 키가 눌린 상태에서 L 키가 떼어진 상태입니다.");
            isGrabed1 = false;
        }
        //센서 2
        if (Input.GetKey(KeyCode.O))
        {
            Debug.Log("O 키가 눌린 상태입니다.");
            isGrabed2 = true;
        }
        else  if (Input.GetKey(KeyCode.K))
        {
            Debug.Log("O 키가 눌린 상태에서 K 키가 떼어진 상태입니다.");
            isGrabed2 = false;
        }
        //센서 3
        if (Input.GetKey(KeyCode.I))
        {
            Debug.Log("I 키가 눌린 상태입니다.");
            isGrabed3 = true;
        }
        else if (Input.GetKey(KeyCode.J))
        {
            Debug.Log("L 키가 눌린 상태에서 J 키가 떼어진 상태입니다.");
            isGrabed3 = false;
        }

        if(isGrabed1 || isGrabed2 || isGrabed3)
        {
            transform.GetComponent<MeshRenderer>().enabled = true;
            transform.position = SnapTransform.position + new Vector3(0,0,0);
            
        }
        else
        {
            transform.GetComponent<MeshRenderer>().enabled = false;
        }

        transform.rotation = Quaternion.LookRotation(-SnapTransform.forward, SnapTransform.up);
        transform.rotation *= Quaternion.Euler(0, 100, 180);

    }
}
