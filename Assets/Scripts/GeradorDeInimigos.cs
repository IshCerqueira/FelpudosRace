    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorDeInimigos : MonoBehaviour
{
    // Prefab do inimigo (arraste no Inspector)
    public GameObject inimigoPrefab;
    public GameObject flyingInimigoPrefab;

    public int selector;
    public float intervalo = 3f;
    public float limiteX = 8f;
    public float limiteY = 1f;
    public float velocidade = 5f;
    public float limiteDestruicaoX = -12f;

    [SerializeField] private PlayerController _playerController;

    void Start()
    {
        velocidade = 5f;
        intervalo = 1.75f;

        // Começa a gerar inimigos repetidamente
        InvokeRepeating("GerarInimigo", 0f, intervalo);
    }

    void GerarInimigo()
    {

        if (!_playerController.endGame)
        {
            selector = Random.Range(1, 3);

            switch (selector)
            {
                case 1:
                    // Define posição de spawn (à direita da tela)

                    Vector2 posicaoAleatoria = new Vector2(limiteX, -limiteY);

                    // Instancia o inimigo
                    GameObject inimigo = Instantiate(inimigoPrefab, posicaoAleatoria, Quaternion.identity);

                    // Inicia o movimento automático (corrotina)
                    StartCoroutine(MoverInimigo(inimigo));
                    break;
                case 2:
                    Vector2 posicaoAleatoria2 = new Vector2(limiteX, limiteY + 1);

                    // Instancia o inimigo
                    GameObject flyingInimigo = Instantiate(flyingInimigoPrefab, posicaoAleatoria2, Quaternion.identity);

                    // Inicia o movimento automático (corrotina)
                    StartCoroutine(MoverInimigo(flyingInimigo));
                    break;
            }
        }
            
        
 
    }

    IEnumerator MoverInimigo(GameObject inimigo)
    {
        while (inimigo != null)
        {
            // Move o inimigo da direita para a esquerda
            inimigo.transform.Translate(Vector2.left * (velocidade + _playerController.speedModifier) * Time.deltaTime);

            // Se o inimigo sair do limite visível, destrói o objeto
            if (inimigo.transform.position.x < limiteDestruicaoX)
            {
                Destroy(inimigo);
                yield break; // Sai da corrotina
            }

            yield return null; // Espera o próximo frame
        }
    }

  

}
