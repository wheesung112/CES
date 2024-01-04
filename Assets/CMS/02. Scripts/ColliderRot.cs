using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderRot : MonoBehaviour
{
    public Transform StageStatus;
    public bool isfloor = false;
    private void OnCollisionEnter(Collision collision)
    {
        AttachObject attachedObject = collision.transform.GetComponent<AttachObject>();
        if (attachedObject == null) return;

        bool objectStatus = attachedObject.getFloored();
        attachedObject.setAttached(false);

        if (isfloor && !objectStatus)
        {
            collision.transform.rotation = Quaternion.Euler(0, 180, 0)* StageStatus.rotation;
            attachedObject.setFloored(true);
            print("floor Coll");
        }
        else if(isfloor && objectStatus) { return; }
        else 
        {
            collision.transform.rotation = Quaternion.Euler(90, StageStatus.rotation.eulerAngles.y, 180);
            attachedObject.setFloored(false);
            print("wall Coll");
        }
    }
}
