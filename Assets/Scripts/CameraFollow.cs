using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    public Transform childCamera;
    public float smoothness = 5f;
    public bool rotate;
    public bool move;
    public Vector3 extraOffset;
    public float rotSpeed;
    public float moveSpeed;

    public float mouseRotSpeedX = 10f;


    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = Vector3.Distance(offset, extraOffset);
        Debug.Log(player.name);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Something();
        //Vector3 newPos = player.transform.position + offset;
        //Debug.Log(transform.forward);
        transform.position = Vector3.Lerp(transform.position, player.transform.position, smoothness * Time.deltaTime);
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY, mouseX, 0f);
        
        transform.eulerAngles = new Vector3(Mathf.Clamp(transform.eulerAngles.x > 180f ? transform.eulerAngles.x - 360f : transform.eulerAngles.x, - 30f, 30f), transform.eulerAngles.y, transform.eulerAngles.z);
        
    }


    void Something()
    {
        if (rotate)
            transform.eulerAngles = Vector3.MoveTowards(transform.eulerAngles, new Vector3(transform.eulerAngles.x, -90f, transform.eulerAngles.z), 90f * Time.deltaTime);
        if (move)
            offset = Vector3.MoveTowards(offset, extraOffset, moveSpeed * Time.deltaTime);
        if (transform.eulerAngles.y < 270f)
            rotate = false;
        if (offset.Equals(extraOffset))
            move = false;
    }
}
