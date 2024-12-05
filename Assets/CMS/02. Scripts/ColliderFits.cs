using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Transformers;
public class ColliderFits : MonoBehaviour
{
    public bool isfloor = false;
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision occurred with a specific tag or layer if needed
        // For example, you can check: if (collision.gameObject.CompareTag("YourTag"))
        bool objectStatus = collision.transform.GetComponent<AttachObject>().getFloored();
        collision.transform.GetComponent<AttachObject>().setAttached(false);
        if (isfloor && !objectStatus)
        {
            collision.transform.rotation = Quaternion.Euler(0, 0, 0);
            collision.transform.GetComponent<AttachObject>().setFloored(true);
            //if (collision.transform.GetComponent<XRGeneralGrabTransformer>() == null) return;
            //collision.transform.GetComponent<XRGeneralGrabTransformer>().permittedDisplacementAxes = XRGeneralGrabTransformer.ManipulationAxes.X | XRGeneralGrabTransformer.ManipulationAxes.Z;
            //print("floor Coll");
            
        }
        else
        {
            collision.transform.rotation = Quaternion.Euler(90, 0, 0);
            collision.transform.GetComponent<AttachObject>().setFloored(false);
            //if (collision.transform.GetComponent<XRGeneralGrabTransformer>() == null) return;
            //collision.transform.GetComponent<XRGeneralGrabTransformer>().permittedDisplacementAxes = XRGeneralGrabTransformer.ManipulationAxes.X | XRGeneralGrabTransformer.ManipulationAxes.Y;
            //print("wall Coll");
            
        }
    }


}
