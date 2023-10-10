using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject [] toDiactovate = GameObject.FindGameObjectsWithTag("Cube");
        foreach (GameObject g in toDiactovate)
        {
            g.name = "Renamed";          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
