using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.UI;

public class FishSpawner : MonoBehaviour
{
    [Header("Fish Prefabs")]
    [SerializeField] public GameObject tapEffectPrefab;
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
    float y = 0.5f;
    float x1;
    float z1;
    float x2;
    float z2;

    void Start()
    {
        pufferFishChance = 0.1f;
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
            fishPuddles1.Add(Instantiate(fishPuddlePrefab1, spawnPoint1, Quaternion.identity));
            spawnDelay1 = Random.Range(0.5f, 1.5f);
            fishPuddleCount1++;
            x1 = Random.Range(-4.5f, 4.5f);
            z1 = Random.Range(-9.5f, -1);
            spawnPoint1 = new Vector3(x1, y, z1);
        }
        
        if (spawnDelay2 <= 0 && fishPuddleCount2 < 10)
        {
            fishPuddles2.Add(Instantiate(fishPuddlePrefab2, spawnPoint2, Quaternion.identity));
            spawnDelay2 = Random.Range(0.5f, 1.5f);
            fishPuddleCount2++;
            x2 = Random.Range(-4.5f, 4.5f);
            z2 = Random.Range(1, 9.5f);
            spawnPoint2 = new Vector3(x2, y, z2);
        }
    }

    private void FixedUpdate()
    {
        if (pufferFishChance >= Random.Range(0, 500))
        {
            Debug.Log("PUFFERFISH");
            Instantiate(pufferFishPrefab, transform.parent);
        }
    }
}
