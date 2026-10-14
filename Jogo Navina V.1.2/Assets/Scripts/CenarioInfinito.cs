using UnityEngine;

public class CenarioInfinito : MonoBehaviour
{
    [Tooltip("Velocidade de deslocamento do cenário.")]
    [SerializeField] private float velocidadeDoCenario = 0.1f;

    private Material meuMaterial;
    private Vector2 deslocamentoDoCenario;
    private readonly string propriedadeTextura = "_MainTex"; 

    void Start()
    {
        Renderer rendererComponent = GetComponent<Renderer>();
        
        if (rendererComponent != null)
        {
            meuMaterial = rendererComponent.material;
        }
        else
        {
            Debug.LogError("CenarioInfinito: Nenhum componente Renderer foi encontrado neste GameObject!", this);
        }
    }

    void Update()
    {
        if (meuMaterial != null)
        {
            MovimentarCenario();
        }
    }

    private void MovimentarCenario()
    {
        deslocamentoDoCenario.x = (deslocamentoDoCenario.x + velocidadeDoCenario * Time.deltaTime) % 1f;

        meuMaterial.SetTextureOffset(propriedadeTextura, deslocamentoDoCenario);
    }
}
