using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5f;
    public Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(x, 0f, z);
        dir = Vector3.forward * z + Vector3.right * x;
        Vector3 direction = cameraTransform.forward * z + cameraTransform.right * x;
        rb.AddForce(direction.normalized * speed);
    }
}
