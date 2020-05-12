using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    Transform player;
    UnityEngine.AI.NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        if(GameObject.FindGameObjectWithTag("Player").activeInHierarchy)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        agent = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.transform.LookAt(player);
        agent.destination = player.position;
        print(player.position);
    }
}
