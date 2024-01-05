using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardInputsVR : MonoBehaviour
{
    
   void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // 스페이스바가 눌렸을 때 A 키로 간주하여 실행되는 코드
            SimulateKeyPress(KeyCode.A);
        }

        if(Input.GetKeyDown(KeyCode.A)){
            print("a");
        }
    }

    void SimulateKeyPress(KeyCode key)
    {
        // 원하는 키를 누른 것처럼 처리할 코드
        Debug.Log($"{key} 키가 눌렸습니다.");

        // 여기에서 필요한 작업을 수행할 수 있습니다.
    }
}
