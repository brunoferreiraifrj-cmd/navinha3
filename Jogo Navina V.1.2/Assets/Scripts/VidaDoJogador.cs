using UnityEngine;
using UnityEngine.UI;

public class VidaDoJogador : MonoBehaviour
{
    public Slider barraDeVidaDoJogador;
    public Slider barraDeEnergiaDoEscudo;
    public GameObject escudoDoJogador;

    public int vidaMaximaDoJogador;
    public int vidaAtualDoJogador;
    public int vidaMaximaDoEscudo;
    public int vidaAtualDoEscudo;

    public bool temEscudo;

    void Start()
    {
        vidaAtualDoJogador = vidaMaximaDoJogador;
        vidaAtualDoEscudo = vidaMaximaDoEscudo;

        barraDeVidaDoJogador.maxValue = vidaMaximaDoJogador;
        barraDeVidaDoJogador.value = vidaAtualDoJogador;

        barraDeEnergiaDoEscudo.maxValue = vidaMaximaDoEscudo;
        barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

        barraDeEnergiaDoEscudo.gameObject.SetActive(false);

        escudoDoJogador.SetActive(false);
        temEscudo = false;
    }

    public void AtivarEscudo()
    {
        barraDeEnergiaDoEscudo.gameObject.SetActive(true);

        vidaAtualDoEscudo = vidaMaximaDoEscudo;
        barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;

        escudoDoJogador.SetActive(true);
        temEscudo = true;
    }

    public void GanharVida(int vidaParaReceber)
    {
        vidaAtualDoJogador = Mathf.Min(vidaAtualDoJogador + vidaParaReceber, vidaMaximaDoJogador);
        barraDeVidaDoJogador.value = vidaAtualDoJogador;
    }

    public void MachucarJogador(int danoParaReceber)
    {
        if (temEscudo == false)
        {
            vidaAtualDoJogador -= danoParaReceber;
            
            if (vidaAtualDoJogador < 0) vidaAtualDoJogador = 0; 
            
            barraDeVidaDoJogador.value = vidaAtualDoJogador;

            if (vidaAtualDoJogador <= 0)
            {
                GameManager.Instance.GameOver();
                Debug.Log("Fim do Jogo");
            }
        }
        else
        {
            vidaAtualDoEscudo -= danoParaReceber;

            if (vidaAtualDoEscudo <= 0)
            {
                vidaAtualDoEscudo = 0;
                escudoDoJogador.SetActive(false);
                temEscudo = false;
            }

            barraDeEnergiaDoEscudo.value = vidaAtualDoEscudo;
            barraDeEnergiaDoEscudo.gameObject.SetActive(false);
        }
    }
}
