using UnityEngine;

public class DestruirComOTempo : MonoBehaviour
{
    [SerializeField] private float tempoDeVida = 2.0f; 

    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }
}