using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //_____aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa_____
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Fire1");
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");
        }
        //Debug.Log(Input.GetAxis("Horizontal"));
        //rb.velocity.Set(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"))*speed;

        Debug.Log(Input.GetAxis("Mouse X"));

    }
    private void OnMouseDown()
    {
        //gameObject.SetActive(false);
        transform.Translate(Vector3.right);
    }
}
