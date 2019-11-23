using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField]
    private float maxSize;
    [SerializeField]
    private float minSize;
    [SerializeField]
    private float fovChangeSpeed;

    [SerializeField]
    private Transform[] mainTransforms;

    private Camera cam;

    private void Awake()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
