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

        // Mesh의 정점 배열을 얻음
        Vector3[] vertices = mesh.vertices;

        // Mesh가 붙어 있는 GameObject의 월드 트랜스폼을 얻음
        Transform meshTransform = meshFilter.transform;

        // Mesh의 정점들을 월드 좌표로 변환하고 Sphere를 생성
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

        // 충돌한 큐브의 충돌 지점
        Vector3 collisionPoint = collision.contacts[0].point;

        // Mesh의 정점 배열을 얻음
        Vector3[] vertices = mesh.vertices;

        // Mesh가 붙어 있는 GameObject의 월드 트랜스폼을 얻음
        Transform meshTransform = meshFilter.transform;

        // 충돌 지점을 Mesh의 로컬 좌표로 변환
        Vector3 localCollisionPoint = meshTransform.InverseTransformPoint(collisionPoint);

        // 가장 가까운 Mesh Vertex 찾기
        int closestVertexIndex = FindClosestVertexIndex(vertices, localCollisionPoint);

        // Mesh의 정점 중 가장 가까운 정점을 월드 좌표로 변환
        Vector3 closestVertexWorld = meshTransform.TransformPoint(vertices[closestVertexIndex]);

        // 충돌한 큐브를 Mesh의 가장 가까운 정점 위치로 이동
        collision.transform.position = closestVertexWorld;

        // 충돌 지점의 Vertex Normal 값 얻기
        Vector3 vertexNormal = mesh.normals[closestVertexIndex];

        // 충돌한 큐브를 Vertex Normal에 맞게 회전
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
