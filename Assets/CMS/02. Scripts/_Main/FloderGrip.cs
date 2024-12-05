using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloderGrip : MonoBehaviour
{
    public Transform defaultTransform;
    public Transform openTransform;
    public Transform hand;
    public GameObject fileList;
    bool checkSelect = false;
    bool isAttached = false;
    bool isHovered = false;
    bool collide= false;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("부딪힌 콜라이더: " + other.gameObject.name);
        GetComponent<AnimController>().StartAnim();
        collide = true;
        // 여기에서 필요한 작업을 수행할 수 있습니다.
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("콜라이더가 떠났습니다: " + other.gameObject.name);
        GetComponent<AnimController>().CloseAnim();
        collide = false;
        // 여기에서 필요한 작업을 수행할 수 있습니다.
    }
    void Update(){
        if(isHovered){
            if (Input.GetKey(KeyCode.LeftControl))
            {
                checkSelect = true;
                // Code to execute when Left Control key is held down
            }
        }
        if(checkSelect){
            transform.position = hand.transform.position;
            transform.rotation = Quaternion.Euler(0,180,0);
            if (Input.GetKey(KeyCode.LeftAlt))
            {
               
                checkSelect = false;
            }
        }
        else{
            if(collide) {
                transform.position = openTransform.position;
                transform.rotation = openTransform.rotation;
                fileList.SetActive(true);
            }
            else {
                transform.position = defaultTransform.position;
                transform.rotation = defaultTransform.rotation;
                fileList.SetActive(false);
            }
        }

    }
    public void Hovered(){
        isHovered = true;
    }
    public void HoverCancle(){
        isHovered = false;
    }
    
}
