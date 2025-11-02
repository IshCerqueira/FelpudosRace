using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScriptRunning : MonoBehaviour
{
    private float length, startpos; 
    public float parallaxSpeed = 1f;    // velocidade de deslocamento
    public float parallaxEffect = 0.5f; // intensidade da paralaxe (profundidade)

    void Start()
    {
        parallaxSpeed = -4;
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        float dist = Mathf.Repeat(Time.time * parallaxSpeed * parallaxEffect, length); // deslocamento automático ao longo do tempo
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
    }
}
