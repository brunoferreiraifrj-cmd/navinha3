using UnityEngine;

public class DestruidorDeInimigos : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Inimigo"))
        {
            Destroy(other.gameObject);
        }
    }
}
