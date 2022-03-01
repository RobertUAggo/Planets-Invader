using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private Vector3 offset;
    private Transform target;
    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime * speed);
    }
    public void UpOffset(float dist)
    {
        offset -= transform.forward * dist;
    }
    public void SetTartget(Transform target)
    {
        this.target = target;
        offset = transform.position - target.position;
    }
}
