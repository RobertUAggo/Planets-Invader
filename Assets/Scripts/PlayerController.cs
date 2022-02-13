using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")) * speed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Finish")
        {
            Destroy(collision.gameObject);
            transform.localScale *= 1.1f;
        }
    }
}
