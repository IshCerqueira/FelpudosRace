using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{

    public Rigidbody2D rb;
    public Transform movimento;
    public GameObject menu;
 

 
    public void OnClick()
    {
        StartCoroutine(FadeOut());
    }
 

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Finish")
        {
            StartCoroutine(CallNextScene());
        }

    }

    IEnumerator CallNextScene()
    {
        SceneManager.LoadScene("CutScene");
        yield return null;
    }



    IEnumerator MoveToEnd()
    {
         
        yield return new WaitForSeconds(0.5f);

        while (movimento.position.x < 13)
        {
            if (rb != null)
            {

                rb.velocity = new Vector2(4 , rb.velocity.y);

                yield return null;
            }
        }

    }


    IEnumerator FadeOut()
    {
        menu.SetActive(false);
        yield return null;
        StartCoroutine(MoveToEnd());
    }
}
