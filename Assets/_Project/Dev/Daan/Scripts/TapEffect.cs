using UnityEngine;

public class TapEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem tapEffectPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tapEffectPrefab.Play();
        Destroy(gameObject, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
