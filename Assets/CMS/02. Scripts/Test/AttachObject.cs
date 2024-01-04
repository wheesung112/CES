using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachObject : MonoBehaviour
{
    private bool isAttached = false;
    bool isFloored = false;

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

                // 회전 값 가져오기
                //Quaternion targetRotation = Quaternion.LookRotation(hit.normal);

                // 이동 및 회전 적용
                transform.position = targetPosition;
                //transform.rotation = targetRotation;

                isAttached = true;
            }
        }
    }

    public void SelectExited()
    {
        isAttached = false;
    }
}
