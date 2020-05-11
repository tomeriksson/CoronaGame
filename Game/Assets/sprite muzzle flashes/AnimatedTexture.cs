using UnityEngine;
using System.Collections;

public class AnimatedTexture : MonoBehaviour
{
    public float fps = 5.0f;
    public Texture2D[] frames;

    private int frameIndex;
    private MeshRenderer rendererMy;

    void Start()
    {
        rendererMy = GetComponent<MeshRenderer>();
        rendererMy.enabled = false;
    }

   private void NextFrame()
    {
         rendererMy.sharedMaterial.SetTexture("_MainTex", frames[frameIndex]);
         frameIndex = (frameIndex + 1) % frames.Length;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            rendererMy.enabled = true;
            NextFrame();
            InvokeRepeating("NextFrame", 1 / fps, 1 / fps);
        }else if (Input.GetMouseButtonUp(0))
        {
            rendererMy.enabled = false;

        }
    }
}