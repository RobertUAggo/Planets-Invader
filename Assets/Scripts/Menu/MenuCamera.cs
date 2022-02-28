using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCamera : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private float zoomSpeed = 0.1f;
    [SerializeField] private float moveSpeed = 0.3F;

    private Camera curCamera;
    private Vector3 velocity = Vector3.zero;
    //
    public Camera TargetCamera;
    //
    private void Awake()
    {
        curCamera = GetComponent<Camera>();
    }
    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, TargetCamera.transform.position, ref velocity, moveSpeed, maxSpeed);
        curCamera.fieldOfView = Mathf.Lerp(curCamera.fieldOfView, TargetCamera.fieldOfView + velocity.magnitude / zoomSpeed, Time.deltaTime);
    }
}
