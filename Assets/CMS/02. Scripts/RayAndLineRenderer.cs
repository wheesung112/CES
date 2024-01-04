using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAndLineRenderer : MonoBehaviour
{
    public Transform targetObject;
    public float rayLength = 10f;

    private LineRenderer lineRenderer;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        if (lineRenderer == null)
        {
            // LineRenderer가 없으면 추가
            lineRenderer = gameObject.AddComponent<LineRenderer>();
        }

        // LineRenderer 설정
        lineRenderer.positionCount = 2;
        lineRenderer.startWidth = 0.02f;
        lineRenderer.endWidth = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        // 카메라에서 특정 오브젝트로 Ray를 쏘기
        Ray ray = new Ray(targetObject.position, targetObject.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            // Ray에 충돌한 경우
            Vector3 hitPoint = hit.point;

            // 라인 렌더러 업데이트
            lineRenderer.SetPosition(0, ray.origin);
            lineRenderer.SetPosition(1, hitPoint);

            // 여기에서 추가적인 작업을 수행할 수 있습니다.
        }
        else
        {
            // Ray에 충돌하지 않은 경우
            Vector3 endPoint = ray.origin + ray.direction * rayLength;

            // 라인 렌더러 업데이트
            lineRenderer.SetPosition(0, ray.origin);
            lineRenderer.SetPosition(1, endPoint);

            // 여기에서 추가적인 작업을 수행할 수 있습니다.
        }
    }
}
