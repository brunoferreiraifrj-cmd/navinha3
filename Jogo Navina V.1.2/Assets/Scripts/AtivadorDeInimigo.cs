using UnityEngine;

public class AtivadorDeInimigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Inimigo"))
        {
            other.gameObject.GetComponent<Inimigos>().AtivarInimigo();
        }
    }
}
