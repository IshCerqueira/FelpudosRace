using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeFruta : MonoBehaviour
{
    // Prefab do inimigo (arraste no Inspector)
    public GameObject pearPrefab;
    public GameObject orangePrefab;
    public GameObject lemonPrefab;

    public int selector;
    public float intervalo = 1f;
    public float limiteX = 8f;
    public float limiteY = 1f;
    public float velocidade = 5f;
    public float limiteDestruicaoX = -12f;

    [SerializeField] private PlayerController _playerController;

    void Start()
    {
        velocidade = 5f;
        intervalo = 4f;

        // Começa a gerar inimigos repetidamente
        InvokeRepeating("GerarFruta", 1f, intervalo);
    }

    void GerarFruta()
    {
        if (!_playerController.endGame)
        {
            selector = Random.Range(1, 4);

            Vector2 posicaoAleatoria = new Vector2(limiteX, -limiteY);

            switch (selector)
            {
                case 1:
                    GameObject pear = Instantiate(pearPrefab, posicaoAleatoria, Quaternion.identity);
                    StartCoroutine(MoverFruta(pear));
                    break;
                case 2:
                    GameObject lemon = Instantiate(lemonPrefab, posicaoAleatoria, Quaternion.identity);
                    StartCoroutine(MoverFruta(lemon));
                    break;
                case 3:
                    GameObject orange = Instantiate(orangePrefab, posicaoAleatoria, Quaternion.identity);
                    StartCoroutine(MoverFruta(orange));
                    break;
            }
        }
    }

    IEnumerator MoverFruta(GameObject fruta)
    {
        while (fruta != null)
        {
            // Move o inimigo da direita para a esquerda
            fruta.transform.Translate(Vector2.left * (velocidade + _playerController.speedModifier) * Time.deltaTime);

            // Se o inimigo sair do limite visível, destrói o objeto
            if (fruta.transform.position.x < limiteDestruicaoX)
            {
                Destroy(fruta);
                yield break; // Sai da corrotina
            }

            yield return null; // Espera o próximo frame
        }
    }


}
