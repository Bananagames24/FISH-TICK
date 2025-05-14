using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField] private GameObject fishPuddlePrefab;
    public int fishPuddleCount = 5;
    [SerializeField] private float spawnDelay = 2f;
    Vector3 spawnPoint;
    float x;
    float y;
    float z;

    void Start()
    {
        x = Random.Range(-5, 5);
        y = 0.5f;
        z = Random.Range(-10, 10);
        spawnPoint = new Vector3(x, y, z);
    }

    private void Update()
    {
        spawnDelay -= Time.deltaTime;
        if (spawnDelay <= 0 && fishPuddleCount < 10) 
        { 
            Instantiate(fishPuddlePrefab, spawnPoint, Quaternion.identity);
            spawnDelay = 0.5f;
            fishPuddleCount++;
            x = Random.Range(-5, 5);
            y = 0.5f;
            z = Random.Range(-10, 10);
            spawnPoint = new Vector3(x, y, z);
        }
    }
}
