using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class KeyboardInputsVR : MonoBehaviour
{
    private InputAction aKeyAction;
    private InputAction bKeyAction;

    private bool isActionActive = false;

    private void OnEnable()
    {
        // A 키 입력을 처리할 액션 생성
        aKeyAction = new InputAction(binding: "<Keyboard>/a");
        aKeyAction.performed += AKeyPerformed;
        aKeyAction.Enable();

        // B 키 입력을 A 키로 리매핑한 액션 생성
        bKeyAction = new InputAction(binding: "<Keyboard>/b");
        bKeyAction.AddBinding("<Keyboard>/a"); // B 키를 A 키로 리매핑
        bKeyAction.started += ActionStarted; // 액션이 시작되면 호출
        bKeyAction.canceled += ActionCanceled; // 액션이 취소되면 호출
        bKeyAction.Enable();
    }

    private void OnDisable()
    {
        // 액션 비활성화
        aKeyAction.Disable();
        bKeyAction.Disable();
    }

    private void AKeyPerformed(InputAction.CallbackContext context)
    {
        // A 키 또는 B 키가 눌렸을 때 호출되는 이벤트 처리
        Debug.Log("A 키 또는 B 키가 눌렸습니다.");

        // 여기에서 필요한 작업을 수행할 수 있습니다.
    }

    private void ActionStarted(InputAction.CallbackContext context)
    {
        // 액션이 시작될 때 호출되는 메소드
        isActionActive = true;
    }

    private void ActionCanceled(InputAction.CallbackContext context)
    {
        // 액션이 취소될 때 호출되는 메소드
        isActionActive = false;
    }

    private void Update()
    {
        // 액션이 활성화된 상태에서 특정 동작 수행
        if (isActionActive)
        {
            // 여기에서 필요한 작업을 수행할 수 있습니다.
            print("ad");
        }
    }
}
