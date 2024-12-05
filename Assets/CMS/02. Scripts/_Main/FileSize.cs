using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileSize : MonoBehaviour
{
     public Slider sizeSlider; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Slider 값에 따라 오브젝트의 크기를 조절
        float scaleFactor = sizeSlider.value; // Slider의 현재 값 가져오기
        Vector3 newScale = Vector3.one * scaleFactor; // 크기 벡터 생성

        // 오브젝트의 크기 조절
        transform.parent.localScale = newScale;
    }
}
