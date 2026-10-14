using UnityEngine;

public class LaserDoInimigo : MonoBehaviour 
{
    [Header("Configurações do Laser")]
    public float velocidadeDoLaser = 10f;
    public int danoParaDar = 1;
    public float tempoDeVida = 4f;

    [Header("Efeitos")]
    public GameObject impactDoLaserDoInimigo;

    void Start() 
    {
        Destroy(gameObject, tempoDeVida); 
    }

    void Update() 
    {
        MovimentoLaser(); 
    }

    private void MovimentoLaser() 
    {
        transform.Translate(Vector3.down * velocidadeDoLaser * Time.deltaTime); 
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player")) 
        {
            if (other.gameObject.TryGetComponent<VidaDoJogador>(out VidaDoJogador scriptVida))
            {
                scriptVida.MachucarJogador(danoParaDar);
            }

            CriarEfeitoImpacto();
            Destroy(gameObject); 
        }
        
        else if (other.gameObject.CompareTag("ParedesDoCenario"))
        {
            CriarEfeitoImpacto();
            Destroy(gameObject);
        }
    }

    private void CriarEfeitoImpacto()
    {
        if (impactDoLaserDoInimigo != null)
        {
            Instantiate(impactDoLaserDoInimigo, transform.position, Quaternion.identity);
        }
    }
}