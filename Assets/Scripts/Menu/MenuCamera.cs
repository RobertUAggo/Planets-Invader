using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    [SerializeField] private float maxZoom = 130;
    [SerializeField] private float zoomSpeed = 1f;
    [SerializeField] private float zoomDistScale = 100;
    [SerializeField] private float maxSpeed = 10f;
    [SerializeField] private float moveSpeed = 1F;

    private Vector3 velocity = Vector3.zero;
    //
    private Camera curCamera;
    private Camera targetCamera;
    //
    private void Awake()
    {
        curCamera = GetComponent<Camera>();
    }
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetCamera.transform.position, ref velocity, moveSpeed, maxSpeed);
        curCamera.fieldOfView = Mathf.Lerp(curCamera.fieldOfView, Mathf.Clamp(targetCamera.fieldOfView + Vector3.Distance(transform.position, targetCamera.transform.position) * zoomDistScale, targetCamera.fieldOfView, maxZoom), Time.deltaTime * zoomSpeed);
    }
    public void SetTargetCamera(Camera targetCamera)
    {
        this.targetCamera = targetCamera;
    }
    public void FastSet(Camera targetCamera)
    {
        this.targetCamera = targetCamera;
        transform.position = targetCamera.transform.position;
        curCamera.fieldOfView = maxZoom;
    }
}
