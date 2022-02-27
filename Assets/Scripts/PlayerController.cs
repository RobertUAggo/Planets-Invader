using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Vertical"), 0, -Input.GetAxisRaw("Horizontal")).normalized;
        
        rb.AddTorque(input * speed, ForceMode.Acceleration);
        //rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Finish")
        {
            Destroy(collision.gameObject);
            transform.localScale *= 1.1f;
            rb.mass *= 1.1f;
            GameScript.Instance.CameraScript.UpOffset(1f);
        }
    }
}
