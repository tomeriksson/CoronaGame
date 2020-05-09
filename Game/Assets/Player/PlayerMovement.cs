using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            anim.SetBool("isRunning", true);
        } else if (Input.GetKeyUp("space")) {
            anim.SetBool("isRunning", false);

        }

        if (Input.GetKey("d"))
        {
            anim.SetBool("isShooting", true);
        }
        else if (Input.GetKeyUp("d"))
        {
            anim.SetBool("isShooting", false);

        }

    }
}
