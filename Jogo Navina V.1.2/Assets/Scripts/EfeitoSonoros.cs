using UnityEngine;

public class EfeitoSonoros : MonoBehaviour
{
    public static EfeitoSonoros instance;

    public AudioSource somDaExplosao, somDoLaserDoJogador, somDeImpacto;

    void Awake()
    {
        instance = this;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
