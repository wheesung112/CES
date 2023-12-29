using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceTest : MonoBehaviour
{
    public bool isDeforming = false;
    private MeshCollider meshCollider;

    void Start()
    {
        // Rigidbody 설정
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb == null)
            rb = gameObject.AddComponent<Rigidbody>();

        // Make sure to set the Rigidbody to Kinematic to prevent it from being affected by gravity
        rb.isKinematic = true;

        // Collider를 MeshCollider로 설정
        meshCollider = GetComponent<MeshCollider>();
        if (meshCollider == null)
            meshCollider = gameObject.AddComponent<MeshCollider>();

        meshCollider.convex = true; // MeshCollider를 convex로 설정

        // Collider를 Trigger로 설정
        Collider collider = GetComponent<Collider>();
        if (collider != null)
            collider.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if trigger occurs with another object with the specified tag and has a collider
        if (other.CompareTag("DeformingObject") && other.GetComponent<Collider>() != null)
        {
            isDeforming = true;
            // Update the "IsDeforming" property in the Shader
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.SetFloat("_IsDeforming", 1.0f);

            // Attach the other object to the surface and rotate it to match the surface normal
            AttachToSurface(other.transform);

            // Debug 메시지 출력
            Debug.Log("Object entered trigger zone. isDeforming set to true. Attached to surface.");
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Reset deformation when trigger ends
        if (other.CompareTag("DeformingObject") && other.GetComponent<Collider>() != null)
        {
            isDeforming = false;
            // Update the "IsDeforming" property in the Shader
            Renderer renderer = GetComponent<Renderer>();
            renderer.material.SetFloat("_IsDeforming", 0.0f);

            // Debug 메시지 출력
            Debug.Log("Object exited trigger zone. isDeforming set to false.");
        }
    }

    void AttachToSurface(Transform otherTransform)
    {
        // Attach the other object to the surface of this object and rotate it to match the surface normal
        Vector3 surfaceNormal = transform.up; // You can customize this based on your needs

        // Get the closest point on the mesh to the other object's position
        Vector3 closestPoint = meshCollider.ClosestPoint(otherTransform.position);

        // Offset을 정의하고 적용
        float offset = 0.001f; // 이 값을 조절하여 Offset을 적용
        Vector3 offsetPosition = closestPoint + surfaceNormal * offset;

        // Adjust the attachment position based on the offset
        Vector3 attachmentPosition = offsetPosition;
        otherTransform.position = attachmentPosition;

        // Rotate the other object to match the surface normal
        Quaternion rotation = Quaternion.FromToRotation(otherTransform.up, surfaceNormal);
        otherTransform.rotation = rotation * otherTransform.rotation;
    }
}
