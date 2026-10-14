using UnityEngine;

public class GeradorDeObjetos : MonoBehaviour
{
    [Header("Configurações de Spawn")]
    [Tooltip("Lista de prefabs que podem ser gerados.")]
    public GameObject[] objetosParaSpawnar;
    
    [Tooltip("Lista de posições onde os objetos podem surgir.")]
    public Transform[] pontosDeSpawn;

    [Header("Tempo")]
    [Tooltip("Tempo mínimo em segundos entre cada spawn.")]
    public float tempoMinimoEntreSpawns = 1f;
    
    [Tooltip("Tempo máximo em segundos entre cada spawn.")]
    public float tempoMaximoEntreSpawns = 3f;
    
    private float tempoAtual;

    void Start()
    {
        ResetarCronometro();
    }

    void Update()
    {
        ControlarContagemRegressiva();
    }

    private void ControlarContagemRegressiva()
    {
        tempoAtual -= Time.deltaTime;

        if (tempoAtual <= 0)
        {
            SpawnarObjeto();
            ResetarCronometro();
        }
    }

    private void SpawnarObjeto()
    {
        if (objetosParaSpawnar == null || objetosParaSpawnar.Length == 0)
        {
            Debug.LogWarning("Nenhum objeto foi atribuído ao array 'objetosParaSpawnar' no Inspector!");
            return;
        }

        if (pontosDeSpawn == null || pontosDeSpawn.Length == 0)
        {
            Debug.LogWarning("Nenhum ponto de spawn foi atribuído ao array 'pontosDeSpawn' no Inspector!");
            return;
        }

        int objetoAleatorio = Random.Range(0, objetosParaSpawnar.Length);
        int pontoAleatorio = Random.Range(0, pontosDeSpawn.Length);

        if (objetosParaSpawnar[objetoAleatorio] != null && pontosDeSpawn[pontoAleatorio] != null)
        {
            Instantiate(
                objetosParaSpawnar[objetoAleatorio], 
                pontosDeSpawn[pontoAleatorio].position, 
                pontosDeSpawn[pontoAleatorio].rotation
            );
        }
    }

    private void ResetarCronometro()
    {
        tempoAtual = Random.Range(tempoMinimoEntreSpawns, tempoMaximoEntreSpawns);
    }
}