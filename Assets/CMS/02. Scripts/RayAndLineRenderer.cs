using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayAndLineRenderer : MonoBehaviour
{
    public Transform parentTarget;
    public Transform targetObject;
    public float rayLength = 10f;
    public Color startColor = Color.red;
    public Color endColor = Color.green;
    private LineRenderer lineRenderer;

    public bool isRayed;
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
        lineRenderer.startColor = startColor;
        lineRenderer.endColor = endColor;

    }

    // Update is called once per frame
    void Update()
    {
        // 카메라에서 특정 오브젝트로 Ray를 쏘기
        Ray ray = new Ray(targetObject.position, parentTarget.TransformDirection(-Vector3.up));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, rayLength))
        {
            // Ray에 충돌한 경우
            Vector3 hitPoint = hit.point;

            // 라인 렌더러 업데이트
            lineRenderer.SetPosition(0, ray.origin);
            lineRenderer.SetPosition(1, hitPoint);

            // 여기에서 추가적인 작업을 수행할 수 있습니다.
            lineRenderer.startColor = Color.white;
            lineRenderer.endColor = Color.white;
            isRayed = true;
        }
        else
        {
            isRayed = false;
            // Ray에 충돌하지 않은 경우
            Vector3 endPoint = ray.origin + ray.direction * rayLength;

            // 라인 렌더러 업데이트
            lineRenderer.SetPosition(0, ray.origin);
            lineRenderer.SetPosition(1, endPoint);


            lineRenderer.startColor = startColor;
            lineRenderer.endColor = endColor;
            //lineRenderer.material.color = startColor;
            // 여기에서 추가적인 작업을 수행할 수 있습니다.
        }
    }
}
