using UnityEngine;
using System.Collections.Generic;

public class FishSpawner : MonoBehaviour
{
    [Header("Fish Prefabs")]
    [SerializeField] public GameObject tapEffectPrefab;
    [SerializeField] public GameObject pufferfishEffectPrefab;
    [SerializeField] private GameObject fishPuddlePrefab1;
    [SerializeField] private GameObject fishPuddlePrefab2;
    [SerializeField] private GameObject pufferFishPrefab;

    [Header("Fish Puddle Settings")]
    public int fishPuddleCount1 = 0;
    [SerializeField] private float spawnDelay1 = 4f;
    public int fishPuddleCount2 = 0;
    [SerializeField] private float spawnDelay2 = 4f;
    private float pufferFishChance = 0;
    Vector3 spawnPoint1;
    Vector3 spawnPoint2;

    [Header("Fish Puddle Lists")]
    public List<GameObject> fishPuddles1 = new List<GameObject>();
    public List<GameObject> fishPuddles2 = new List<GameObject>();
    float y = -3f;
    float x1;
    float z1;
    float x2;
    float z2;

    void Start()
    {
        pufferFishChance = 0.0025f;
        x1 = Random.Range(-5, 5);
        z1 = Random.Range(-10, -1);
        x2 = Random.Range(-5, 5);
        z2 = Random.Range(1, 10);
        spawnPoint1 = new Vector3(x1, y, z1);
        spawnPoint2 = new Vector3(x2, y, z2);
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
            Debug.Log("PUFFERFISH");
            Instantiate(pufferFishPrefab, transform.parent);
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

    private void SpawnFishOnRandomPosition(GameObject prefab, Vector3 spawnPoint, float zMin, float zMax, List<GameObject> puddle, bool puddle1)
    {
        GameObject fish = Instantiate(prefab, spawnPoint, Quaternion.identity);
        puddle.Add(fish);


        x2 = Random.Range(-4.5f, 4.5f);
        z2 = Random.Range(1, 9.5f);
        z1 = Random.Range(-9.5f, -1f);

        if (puddle1)
        {
            fishPuddleCount1++;
            spawnDelay1 = Random.Range(0.5f, 1.5f);
            spawnPoint1 = new Vector3(x2, y, z1);
        }
        else
        {
            fishPuddleCount2++;
            spawnDelay2 = Random.Range(0.5f, 1.5f);
            spawnPoint2 = new Vector3(x2, y, z2);
        }
        
    }
}
