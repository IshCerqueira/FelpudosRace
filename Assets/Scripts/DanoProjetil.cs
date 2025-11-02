using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanoProjetil : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Inimigo")
        {
          
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else if (other.gameObject.tag == "StopBullet")
        {
            Destroy(gameObject);
        }

    }
}
