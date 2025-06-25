using UnityEngine;
using System.Collections.Generic;

public class FishSpawner : MonoBehaviour
{
    [Header("Fish Prefabs")]
    [SerializeField] public GameObject tapEffectPrefab;
    [SerializeField] public GameObject pufferfishEffectPrefab;
    [SerializeField] public GameObject fishPuddlePrefab1;
    [SerializeField] public GameObject fishPuddlePrefab2;
    [SerializeField] private GameObject pufferFishPrefab;
    [SerializeField] private GameObject eelPrefab;
    [SerializeField] public GameObject scoreTextPrefab;

    [Header("Fish Puddle Settings")]
    public int fishPuddleCount1 = 0;
    [SerializeField] private float spawnDelay1 = 4f;
    public int fishPuddleCount2 = 0;
    [SerializeField] private float spawnDelay2 = 4f;
    private float pufferFishChance = 0;
    private float eelChance = 0;
    public Vector3 spawnPoint1;
    public Vector3 spawnPoint2;

    [Header("Fish Puddle Lists")]
    public List<GameObject> fishPuddles1 = new List<GameObject>();
    public List<GameObject> fishPuddles2 = new List<GameObject>();
    float y = -3f;
    float x1;
    float z1;
    float x2;

    void Start()
    {
        pufferFishChance = 0.003f;
        eelChance = 0.001f;
        x1 = Random.Range(-10, -1);
        z1 = Random.Range(-5, 5);
        x2 = Random.Range(1, 10);

        spawnPoint1 = new Vector3(x1, y, z1);
        spawnPoint2 = new Vector3(x2, y, z1);
    }

    private void Update()
    {
        if (spawnDelay1 >= 0)
        {
            spawnDelay1 -= Time.deltaTime;
        }
        
        if (spawnDelay2 >= 0)
        {
            spawnDelay2 -= Time.deltaTime;
        }

        if (spawnDelay1 <= 0 && fishPuddleCount1 < 10) 
        { 
            SpawnFishOnRandomPosition(fishPuddlePrefab1, spawnPoint1, -9.5f, -1f, fishPuddles1, true);
        }
        
        if (spawnDelay2 <= 0 && fishPuddleCount2 < 10)
        {
            SpawnFishOnRandomPosition(fishPuddlePrefab2, spawnPoint2, 1f, 9.5f, fishPuddles2, false);
        }
    }

    private void FixedUpdate()
    {
        if (Random.value <= pufferFishChance)
        {
            Vector3 position =  new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-5f, 5f));
            Instantiate(pufferFishPrefab, position, Quaternion.identity);
        }

        if (Random.value <= eelChance)
        {
            Vector3 position = new Vector3(Random.Range(-10f, 10f), 0, Random.Range(-5f, 5f));
            Instantiate(eelPrefab, position, Quaternion.identity);
        }
    }

    public bool GetFirstFishFromPuddle(int puddleIndex, out Transform fish)
    {
        List<GameObject> puddle = puddleIndex == 0 ? fishPuddles1 : fishPuddles2;
        if (puddle == null || puddle.Count == 0)
        {
            fish = null;
            return false;
        }

        fish = puddle[0].transform;
        return true;
    }

    public void RemoveFishFromPuddleAndDestroy(GameObject fish)
    {
        // If the fish does not have the correct tag, we do nothing.
        if (!fish.CompareTag("FishPuddle1") && !fish.CompareTag("FishPuddle2")) return;
        
        if (fish.CompareTag("FishPuddle1"))
        {
            fishPuddles1.Remove(fish);
            fishPuddleCount1--;
        }
        else
        {
            fishPuddles2.Remove(fish);
            fishPuddleCount2--;
        }
        Destroy(fish);
    }

    public void SpawnFishOnRandomPosition(GameObject prefab, Vector3 spawnPoint, float xMin, float xMax, List<GameObject> puddle, bool puddle1)
    {
        GameObject fish = Instantiate(prefab, spawnPoint, Quaternion.identity);
        puddle.Add(fish);

        x1 = Random.Range(-10, -1);
        z1 = Random.Range(-5, 5);
        x2 = Random.Range(1, 10);

        if (puddle1)
        {
            fishPuddleCount1++;
            spawnDelay1 = Random.Range(0.1f, 0.7f);
            spawnPoint1 = new Vector3(x1, y, z1);
        }
        else
        {
            fishPuddleCount2++;
            spawnDelay2 = Random.Range(0.1f, 0.7f);
            spawnPoint2 = new Vector3(x2, y, z1);
        }
    }
}
