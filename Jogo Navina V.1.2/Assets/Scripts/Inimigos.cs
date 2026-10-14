using UnityEngine;

public class Inimigos : MonoBehaviour
{
    [Header("Configurações do Laser")]
    [SerializeField] private GameObject laserDoInimigo;
    [SerializeField] private Transform localDoDisparo;
    [SerializeField] private float tempoMaximoEntreOsLasers;
    private float tempoAtualDosLasers;

    [Header("Configurações de Drop")]
    [SerializeField] private GameObject itemParaDropar;
    [SerializeField] [Range(0, 100)] private int chanceParaDropar;

    [Header("Atributos do Inimigo")]
    [SerializeField] private float velocidadeDoInimigo;
    [SerializeField] private int vidaMaximaDoInimigo;
    private int vidaAtualDoInimigo;
    [SerializeField] private int pontosParaDar;
    [SerializeField] private int danoDaNave = 1;
    [SerializeField] private GameObject efeitoDeExplosao;
    public int danoJogador = 10;

    [Header("Estados do Inimigo")]
    [SerializeField] private bool inimigoAtirador;
    [HideInInspector] public bool inimigoAtivado;

    private VidaDoJogador scriptJogador;
    private bool jaMorreu = false;

    void Start()
    {
        inimigoAtivado = true; 
        vidaAtualDoInimigo = vidaMaximaDoInimigo;
        
        GameObject objetoJogador = GameObject.FindGameObjectWithTag("Player");
        if (objetoJogador != null)
        {
            scriptJogador = objetoJogador.GetComponent<VidaDoJogador>();
        }

        tempoAtualDosLasers = Random.Range(0.5f, Mathf.Max(0.5f, tempoMaximoEntreOsLasers));
    }

    void Update()
    {
        if (!inimigoAtivado) return;

        MovimentarInimigo();

        if (inimigoAtirador)
        {
            AtirarLaser();
        }
    }

    public void AtivarInimigo()
    {
        inimigoAtivado = true;
    }

    private void MovimentarInimigo()
    {
        transform.Translate(Vector3.down * velocidadeDoInimigo * Time.deltaTime);
    }

    private void AtirarLaser()
    {
        if (laserDoInimigo == null || localDoDisparo == null) return;

        tempoAtualDosLasers -= Time.deltaTime;

        if (tempoAtualDosLasers <= 0f)
        {
            Instantiate(laserDoInimigo, localDoDisparo.position, localDoDisparo.rotation);
            tempoAtualDosLasers = tempoMaximoEntreOsLasers;
        }
    }

    public void MachucarInimigo(int dano)
    {
        if (jaMorreu) return;

        vidaAtualDoInimigo -= dano;
        
        if (vidaAtualDoInimigo <= 0)
        {
            Morrer();
        }
    }

    private void Morrer()
    {
        if (jaMorreu) return;
        jaMorreu = true;

        if (GameManager.Instance != null)
        {
            GameManager.Instance.AumentarPontuacao(pontosParaDar);
        }

        if (efeitoDeExplosao != null)
        {
            Instantiate(efeitoDeExplosao, transform.position, transform.rotation);
        }

        if (EfeitoSonoros.instance != null)
        {
            EfeitoSonoros.instance.somDaExplosao.Play();
        }

        if (itemParaDropar != null && chanceParaDropar > 0)
        {
            int numeroAleatorio = Random.Range(1, 101);
            if (numeroAleatorio <= chanceParaDropar)
            
            if (scriptJogador != null)
            {
                scriptJogador.MachucarJogador(danoDaNave);
            }
            Destroy(gameObject);
        }
    }
}