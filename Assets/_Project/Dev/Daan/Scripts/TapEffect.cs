using UnityEngine;

public class TapEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem tapEffectPrefab;

    void Start()
    {
        tapEffectPrefab.Play();
        Destroy(gameObject, 1);
    }
}
