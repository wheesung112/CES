using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SufaceSnaptest : MonoBehaviour
{

    public LayerMask snapLayer; // ������ ���̾�
    public Vector3 upVector = Vector3.up; // ������Ʈ�� � �������� ���� ���ϴ���

    private void OnTriggerEnter(Collider other)
    {
        if (((1 << other.gameObject.layer) & snapLayer) != 0)
        {
            SnapObject(other.ClosestPoint(transform.position), other.transform.up, transform);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (((1 << other.gameObject.layer) & snapLayer) != 0)
        {
            SnapObject(other.ClosestPoint(transform.position), other.transform.up, transform);
        }
    }
    private void SnapObject(Vector3 snappedPosition, Vector3 upVector, Transform objTransform)
    {
        Vector3 pivotOffset = objTransform.position - objTransform.GetComponent<Collider>().bounds.center;

        if (objTransform.GetComponent<RectTransform>() != null)
        {
            RectTransform rectTransform = objTransform.GetComponent<RectTransform>();
            rectTransform.position = snappedPosition + pivotOffset;
            rectTransform.rotation = Quaternion.FromToRotation(Vector3.forward, upVector);
        }
        else
        {
            objTransform.position = snappedPosition + pivotOffset;
            objTransform.rotation = Quaternion.FromToRotation(objTransform.up, upVector) * objTransform.rotation;
        }
    }

}
