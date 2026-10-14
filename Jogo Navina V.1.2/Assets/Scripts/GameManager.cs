using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public AudioSource musicaDoJogo;
    public AudioSource musicaDeGameOver;

    public Text textoDoPontuacaoAtual;
    public GameObject painelDeGameOver;
    public Text textoDoPontuacaoFinal;
    public Text textoDeHighScore;

    public int pontuacaoAtual;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        Time.timeScale = 1f;
        musicaDoJogo.Play();

        pontuacaoAtual = 0;
        textoDoPontuacaoAtual.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }   

    public void AumentarPontuacao(int pontosParaGanhar)
    {
        pontuacaoAtual += pontosParaGanhar;
        textoDoPontuacaoAtual.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        musicaDoJogo.Stop();
        musicaDeGameOver.Play();

        painelDeGameOver.SetActive(true);
        textoDoPontuacaoFinal.text = "PONTUAÇÃO: " + pontuacaoAtual;
    }
}
