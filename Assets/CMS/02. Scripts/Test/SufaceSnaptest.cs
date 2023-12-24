using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SufaceSnaptest : MonoBehaviour
{
    public LayerMask snapLayer;
    private void OnCollisionStay(Collision collision)
    {
        // 충돌한 오브젝트의 레이어가 Snapping 가능한 레이어인지 확인
        if (((1 << collision.gameObject.layer) & snapLayer) != 0)
        {
            print("Collision " + collision.transform.name);
            // 충돌한 지점의 Normal 벡터를 통해 오브젝트를 회전시키고, 표면에 Snap
            Vector3 normal = collision.contacts[0].normal;
            Vector3 snappedPosition = collision.contacts[0].point;

            // 여기에서는 Collider의 중심을 기준으로 함
            Vector3 pivotOffset = transform.position - GetComponent<Collider>().bounds.center;

            // 충돌한 오브젝트가 RectTransform을 가지고 있다면
            RectTransform rectTransform = collision.transform.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                // UI 객체의 위치 및 회전 설정
                rectTransform.position = snappedPosition + pivotOffset;
                rectTransform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
            }
            else
            {
                // 일반적인 경우 (UI가 아닌 경우) 위치 및 회전 설정
                collision.transform.position = snappedPosition + pivotOffset;
                collision.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // 충돌한 오브젝트의 레이어가 Snapping 가능한 레이어인지 확인
        if (((1 << collision.gameObject.layer) & snapLayer) != 0)
        {
            print("Collision " + collision.transform.name);
            // 충돌한 지점의 Normal 벡터를 통해 오브젝트를 회전시키고, 표면에 Snap
            Vector2 normal = collision.contacts[0].normal;
            Vector2 snappedPosition = collision.contacts[0].point;

            // 여기에서는 Collider의 중심을 기준으로 함
            Vector2 pivotOffset = (Vector2)transform.position - ((BoxCollider2D)GetComponent<Collider2D>()).offset;

            // 충돌한 오브젝트의 transform을 회전 및 이동
            collision.transform.position = snappedPosition + pivotOffset;
            collision.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
        }

    }
}
