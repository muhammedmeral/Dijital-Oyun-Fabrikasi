using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        transform.position += new Vector3(0f, 0f, transform.GetChild(0).GetComponent<Renderer>().bounds.size.z * 2);
    }
}
