using UnityEngine;

public class LaserDoJogador : MonoBehaviour
{
    public float velocidadeDoLaser;
    public int danoParaDar;
    public GameObject impactDoLaseDoJogador; 

    void Start()
    {
        Destroy(gameObject, 5f); 
    }

    void Update()
    {
        MovimentarLaser();
    }

    private void MovimentarLaser()
    {
        transform.Translate(Vector3.up * velocidadeDoLaser * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            other.gameObject.GetComponent<Inimigos>().MachucarInimigo(danoParaDar);

            GameObject impacto = Instantiate(impactDoLaseDoJogador, transform.position, transform.rotation);
            EfeitoSonoros.instance.somDeImpacto.Play();

            Destroy(gameObject);
        }
    }
}
