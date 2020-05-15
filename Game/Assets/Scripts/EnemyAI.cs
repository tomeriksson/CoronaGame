using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    GameObject player;
    //NavMeshAgent agent;
    public Rigidbody rb;
    private Vector3 HIGHT_OFFSET = new Vector3(0, 0.67f, 0);

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position + HIGHT_OFFSET);
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * 0.5f + HIGHT_OFFSET, ForceMode.VelocityChange);
    }
}
