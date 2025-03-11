using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BodyBooster : MonoBehaviour
{

    [SerializeField] private float _forceAmount = 100f;
    private Rigidbody Rigidbody;

    //guarda a pontua��o
    private int pontos = 0;

    //ref do texto no canva
    public TextMeshProUGUI textoPontuacao;

    //ref dos paineis
    public GameObject painelGameOver;
    public GameObject painelVitoria;

    void Start()
    {
        //atualiza o texto no come�o
        AtualizarPontuacao();

        //s� pra ter certeza que os pain�is est�o desativados no inicio
        if (painelGameOver != null)
            painelGameOver.SetActive(false);

        if (painelVitoria != null)
            painelVitoria.SetActive(false);
    }

    private void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>(); //pega o rigidbody da bolinha
    }

    private void Update()
    {
        //verifica se a bolinha caiu no limite imposto
        if (transform.position.y < -50f)
        {
            GameOver();
        }

        //faz a bolinha pular ao pressionar espa�o
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rigidbody.AddForce(Vector3.up * _forceAmount);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //verifica se o objeto colidido tem a tag certa
        if (collision.gameObject.CompareTag("Ponto"))
        {
            //adiciona na pontua��o
            pontos++;

            //chama o m�todo que atualiza a pontua��o
            AtualizarPontuacao();

            //destr�i o objeto coledido
            Destroy(collision.gameObject);
        }
    }

    //m�todo que atualiza a pontua��o
    void AtualizarPontuacao()
    {
        if (textoPontuacao != null)
        {
            textoPontuacao.text = "Pontos: " + pontos.ToString();
        }

        //verifica se o jogador fez 6 pontos
        if (pontos >= 6)
        {
            Vitoria();
        }
    }

    //m�todo para game over
    void GameOver()
    {
        if (painelGameOver != null)
        {
            painelGameOver.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    //m�todo para vitoria
    void Vitoria()
    {
        if (painelVitoria != null)
        {
            painelVitoria.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}
