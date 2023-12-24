using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SufaceSnaptest : MonoBehaviour
{
    public LayerMask snapLayer;
    private void OnCollisionStay(Collision collision)
    {
        // �浹�� ������Ʈ�� ���̾ Snapping ������ ���̾����� Ȯ��
        if (((1 << collision.gameObject.layer) & snapLayer) != 0)
        {
            print("Collision " + collision.transform.name);
            // �浹�� ������ Normal ���͸� ���� ������Ʈ�� ȸ����Ű��, ǥ�鿡 Snap
            Vector3 normal = collision.contacts[0].normal;
            Vector3 snappedPosition = collision.contacts[0].point;

            // ���⿡���� Collider�� �߽��� �������� ��
            Vector3 pivotOffset = transform.position - GetComponent<Collider>().bounds.center;

            // �浹�� ������Ʈ�� RectTransform�� ������ �ִٸ�
            RectTransform rectTransform = collision.transform.GetComponent<RectTransform>();
            if (rectTransform != null)
            {
                // UI ��ü�� ��ġ �� ȸ�� ����
                rectTransform.position = snappedPosition + pivotOffset;
                rectTransform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
            }
            else
            {
                // �Ϲ����� ��� (UI�� �ƴ� ���) ��ġ �� ȸ�� ����
                collision.transform.position = snappedPosition + pivotOffset;
                collision.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // �浹�� ������Ʈ�� ���̾ Snapping ������ ���̾����� Ȯ��
        if (((1 << collision.gameObject.layer) & snapLayer) != 0)
        {
            print("Collision " + collision.transform.name);
            // �浹�� ������ Normal ���͸� ���� ������Ʈ�� ȸ����Ű��, ǥ�鿡 Snap
            Vector2 normal = collision.contacts[0].normal;
            Vector2 snappedPosition = collision.contacts[0].point;

            // ���⿡���� Collider�� �߽��� �������� ��
            Vector2 pivotOffset = (Vector2)transform.position - ((BoxCollider2D)GetComponent<Collider2D>()).offset;

            // �浹�� ������Ʈ�� transform�� ȸ�� �� �̵�
            collision.transform.position = snappedPosition + pivotOffset;
            collision.transform.rotation = Quaternion.FromToRotation(Vector3.up, normal);
        }

    }
}
