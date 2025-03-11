using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BodyBooster : MonoBehaviour
{

    [SerializeField] private float _forceAmount = 100f;
    private Rigidbody Rigidbody;

    //guarda a pontuação
    private int pontos = 0;

    //ref do texto no canva
    public TextMeshProUGUI textoPontuacao;

    //ref dos paineis
    public GameObject painelGameOver;
    public GameObject painelVitoria;

    void Start()
    {
        //atualiza o texto no começo
        AtualizarPontuacao();

        //só pra ter certeza que os painéis estão desativados no inicio
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

        //faz a bolinha pular ao pressionar espaço
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
            //adiciona na pontuação
            pontos++;

            //chama o método que atualiza a pontuação
            AtualizarPontuacao();

            //destrói o objeto coledido
            Destroy(collision.gameObject);
        }
    }

    //método que atualiza a pontuação
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

    //método para game over
    void GameOver()
    {
        if (painelGameOver != null)
        {
            painelGameOver.SetActive(true);
        }

        Time.timeScale = 0f;
    }

    //método para vitoria
    void Vitoria()
    {
        if (painelVitoria != null)
        {
            painelVitoria.SetActive(true);
        }

        Time.timeScale = 0f;
    }
}
