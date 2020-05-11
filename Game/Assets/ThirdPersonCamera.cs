using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform lookAt;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position- lookAt.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    
        transform.position = lookAt.position + offset;
        transform.LookAt(lookAt.position);
    }
}
