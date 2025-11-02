using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScriptRunning : MonoBehaviour
{
    private float length, startpos; 
    public float parallaxSpeed = -4f;    // velocidade de deslocamento
    public float parallaxEffect = 0.5f; // intensidade da paralaxe (profundidade)

    [SerializeField] private PlayerController _playerController;

    void Start()
    {
        parallaxSpeed = -4;
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
   
    }

    void Update()
    {
        if (!_playerController.endGame)
        {
            float dist = Mathf.Repeat(Time.time * parallaxSpeed * parallaxEffect, length); // deslocamento automático ao longo do tempo
            transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);
            parallaxSpeed -= (_playerController.speedModifier/10000);
        }
    }

    
}
