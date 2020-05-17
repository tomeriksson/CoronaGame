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
    private PlayerHealth playerHealth;
    //NavMeshAgent agent;
    public Rigidbody rb;
    public float attackdamage;
    //private Vector3 HIGHT_OFFSET = new Vector3(0, 0.67f, 0);

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position
            //   + HIGHT_OFFSET
            );
    }

    void FixedUpdate()
    {
        rb.AddForce(transform.forward * 0.4f
            // + HIGHT_OFFSET
            , ForceMode.VelocityChange);
    }

    //Detect collisions between the GameObjects with Colliders attached

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            playerHealth.Damage(attackdamage);
        }
    }
}