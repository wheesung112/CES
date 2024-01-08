using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomInCanvas : MonoBehaviour
{
    public int maxSize = 4;
    public float steps = 0.001f;
    Vector3 defaultSize;
    Vector3 currentSize;
    Vector3 vmaxSize;
    Vector3 vminSize;
    // Start is called before the first frame update
    void Start()
    {
        defaultSize = transform.parent.localScale;
        vminSize = defaultSize / 2;
        vmaxSize = defaultSize * 2;
        currentSize = transform.parent.localScale;
        
    }

    public void ZoomIN()
    {
        if (currentSize.x < vmaxSize.x && currentSize.y < vmaxSize.y && currentSize.z < vmaxSize.z)
        {
            currentSize += new Vector3(steps, steps, steps);
            transform.parent.localScale = currentSize;
        }
    }
    public void ZoomOUT()
    {
        if (currentSize.x > vminSize.x && currentSize.y > vminSize.y && currentSize.z > vminSize.z)
        {
            currentSize -= new Vector3(steps, steps, steps);
            transform.parent.localScale = currentSize;
        }
    }
}
