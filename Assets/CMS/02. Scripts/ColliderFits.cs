using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderFits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // RawImage의 RectTransform을 가져와서 크기를 가져옴
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector3 spriteSize = rectTransform.rect.size;

        // BoxCollider2D를 가져와서 크기를 조절
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            boxCollider.size = spriteSize;
        }
    }


}
