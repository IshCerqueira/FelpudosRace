using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScene : MonoBehaviour
{
 
    public Transform movimento;
   


    private void Start()
    {
        StartCoroutine(MoveToEnd());
    }

    IEnumerator MoveToEnd()
    {
        yield return new WaitForSeconds(0f);

        gameObject.transform.Translate(Vector2.right * 4 * Time.deltaTime);
        StartCoroutine(MoveToEnd());

    }

}
