using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColliderFits : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // RawImage�� RectTransform�� �����ͼ� ũ�⸦ ������
        RectTransform rectTransform = GetComponent<RectTransform>();
        Vector3 spriteSize = rectTransform.rect.size;

        // BoxCollider2D�� �����ͼ� ũ�⸦ ����
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            boxCollider.size = spriteSize;
        }
    }


}
