using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraScript : MonoBehaviour
{
    public Transform player;
    public float sensitivity = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position;
        transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0f) * sensitivity * Time.deltaTime;
        if (transform.eulerAngles.x < 180f && transform.eulerAngles.x > 30f)
            transform.eulerAngles = new Vector3(30f, transform.eulerAngles.y, transform.eulerAngles.z);
        if (transform.eulerAngles.x >= 180f && transform.eulerAngles.x < 330f)
            transform.eulerAngles = new Vector3(-30f, transform.eulerAngles.y, transform.eulerAngles.z);
        Debug.Log(transform.forward);
        
    }
}
