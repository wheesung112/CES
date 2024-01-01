using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachObject : MonoBehaviour
{
    private bool isAttached = false;
    bool isfloored = false;
    public void setFloored(bool floor)
    {
        isfloored = floor;
    }
    public bool getFloored()
    {
        return isfloored;
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
                if (isfloored)
                    targetPosition.y += 0.001f;
                else
                    targetPosition.z += 0.001f;

                transform.position = targetPosition;
                //transform.rotation = Quaternion.LookRotation(hit.normal);
                
                isAttached = true;
            }
        }
    }

    public void SelectExited()
    {
        isAttached = false;
        //RaycastHit hit;
        //Ray ray = new Ray(transform.position, -transform.up);

        //if (Physics.Raycast(ray, out hit))
        //{
        //    Vector3 targetPosition = hit.point;
        //    if (isfloored)
        //        targetPosition.y += 0.001f;
        //    else
        //        targetPosition.z += 0.001f;

        //    transform.position = targetPosition;
        //}
    }
}
