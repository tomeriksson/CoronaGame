using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private bool paused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if(paused)
                Time.timeScale = 1;
             else
                Time.timeScale = 0;
                paused = !paused;

        }
    }
}
