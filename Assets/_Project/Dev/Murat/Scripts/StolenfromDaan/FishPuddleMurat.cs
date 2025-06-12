using UnityEngine;

public class FishPuddleMurat : MonoBehaviour
{
    [SerializeField] private FishSpawner fishSpawner;
    [SerializeField] float startTime;
    [SerializeField] float endTime;
    public bool buff=false ;

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
            //fishSpawner.fishPuddleCount1--;
            //fishSpawner.fishPuddles1.Remove(gameObject);
           // Destroy(gameObject);
        }
        else if (CompareTag("FishPuddle2"))
        {
           // fishSpawner.fishPuddleCount2--;
           // fishSpawner.fishPuddles2.Remove(gameObject);
           // Destroy(gameObject);
        }
    }
}
