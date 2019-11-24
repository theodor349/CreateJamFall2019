using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private float maxSize = 8f;
    [SerializeField]
    private float minSize = 2.5f;
    [SerializeField]
    private float moveSpeed = 1f;
    [SerializeField]
    private float sizeSpeed = 1f;
    [SerializeField]
    private Transform[] mainTransforms;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, FindCenter(), moveSpeed * Time.deltaTime);
        float dist = Vector2.Distance(mainTransforms[0].position, mainTransforms[1].position) / 1.5f;
        if (dist > maxSize) dist = maxSize;
        if (dist < minSize) dist = minSize;
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, dist, sizeSpeed * Time.deltaTime);
    }

    Vector3 FindCenter()
    {
        Vector3 center = Vector3.zero;
        for(int i = 0; i < mainTransforms.Length; i++) {
            center += mainTransforms[i].position;
        }
        center /= mainTransforms.Length;
        center.z = -10;
        return center;
    }
}
