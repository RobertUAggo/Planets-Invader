using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float speed = 2;
    private Vector3 offset;
    private void Start()
    {
        offset = transform.position - target.position;
    }
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * speed);
    }
    public void UpOffset(float dist)
    {
        offset -= transform.forward * dist;
    }
}
