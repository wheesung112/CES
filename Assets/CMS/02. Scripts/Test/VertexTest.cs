using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexTest : MonoBehaviour
{
    MeshFilter meshFilter;
    //public GameObject point;
    // Start is called before the first frame update
    public GameObject point;
    void Start()
    {
        meshFilter = transform.GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("MeshFilter not assigned!");
            return;
        }

        Mesh mesh = meshFilter.mesh;

        // Mesh�� ���� �迭�� ����
        Vector3[] vertices = mesh.vertices;

        // Mesh�� �پ� �ִ� GameObject�� ���� Ʈ�������� ����
        Transform meshTransform = meshFilter.transform;

        // Mesh�� �������� ���� ��ǥ�� ��ȯ�ϰ� Sphere�� ����
        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 worldVertex = meshTransform.TransformPoint(vertices[i]);
            Instantiate(point, worldVertex, Quaternion.identity);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        print("Collision");
        if (meshFilter == null)
            return;

        Mesh mesh = meshFilter.mesh;

        // �浹�� ť���� �浹 ����
        Vector3 collisionPoint = collision.contacts[0].point;

        // Mesh�� ���� �迭�� ����
        Vector3[] vertices = mesh.vertices;

        // Mesh�� �پ� �ִ� GameObject�� ���� Ʈ�������� ����
        Transform meshTransform = meshFilter.transform;

        // �浹 ������ Mesh�� ���� ��ǥ�� ��ȯ
        Vector3 localCollisionPoint = meshTransform.InverseTransformPoint(collisionPoint);

        // ���� ����� Mesh Vertex ã��
        int closestVertexIndex = FindClosestVertexIndex(vertices, localCollisionPoint);

        // Mesh�� ���� �� ���� ����� ������ ���� ��ǥ�� ��ȯ
        Vector3 closestVertexWorld = meshTransform.TransformPoint(vertices[closestVertexIndex]);

        // �浹�� ť�긦 Mesh�� ���� ����� ���� ��ġ�� �̵�
        collision.transform.position = closestVertexWorld;

        // �浹 ������ Vertex Normal �� ���
        Vector3 vertexNormal = mesh.normals[closestVertexIndex];

        // �浹�� ť�긦 Vertex Normal�� �°� ȸ��
        collision.transform.rotation = Quaternion.FromToRotation(Vector3.up, vertexNormal);
    }

    private int FindClosestVertexIndex(Vector3[] vertices, Vector3 point)
    {
        float minDistance = float.MaxValue;
        int closestIndex = 0;

        for (int i = 0; i < vertices.Length; i++)
        {
            float distance = Vector3.Distance(vertices[i], point);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestIndex = i;
            }
        }

        return closestIndex;
    }
}
