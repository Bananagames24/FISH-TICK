using UnityEngine;

public class FishPuddle : MonoBehaviour
{
    [SerializeField] private FishSpawner fishSpawner;
    [SerializeField] float startTime;
    [SerializeField] float endTime;

    private void Start()
    {
        fishSpawner = FindAnyObjectByType<FishSpawner>();
        startTime = 0;
        endTime = 5;
    }

    private void Update()
    {
        if(startTime < endTime)
        {
            startTime += Time.deltaTime * 1;
        }
        else if(CompareTag("FishPuddle1"))
        {
            fishSpawner.fishPuddleCount1--;
            fishSpawner.fishPuddles1.Remove(gameObject);
            Destroy(gameObject);
        }
        else if (CompareTag("FishPuddle2"))
        {
            fishSpawner.fishPuddleCount2--;
            fishSpawner.fishPuddles2.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
