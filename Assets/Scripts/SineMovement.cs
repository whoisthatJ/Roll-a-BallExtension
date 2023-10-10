using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineMovement : MonoBehaviour
{
    public float amp = 0.5f;
    public float freq = 2f;
    float posY;
    // Start is called before the first frame update
    void Start()
    {
        posY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, posY + Mathf.Sin(Time.timeSinceLevelLoad*freq) * amp, transform.position.z);
    }
}
