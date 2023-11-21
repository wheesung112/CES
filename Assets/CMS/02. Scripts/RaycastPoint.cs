using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastPoint : MonoBehaviour
{
    public static RaycastPoint instance;

    GameObject hittedObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        LayerMask layerMask = LayerMask.GetMask("Ignore Raycast");

        if (Physics.Raycast(ray, out hit,500,~layerMask))
        {
            //hit.collider.gameObject.transform.localScale = new Vector3(1.5f, 1.5f, 0.2f);            
            //Debug.Log("충돌한 물체: " + hit.collider.gameObject.name);
            //Debug.Log("충돌 지점: " + hit.point);
        }
        Debug.DrawRay(ray.origin, ray.direction * 100
            , Color.red, 0.5f);


    }

}
