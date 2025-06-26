using UnityEngine;

public class FishPuddle : MonoBehaviour
{
    [SerializeField] private FishSpawner fishSpawner;
    [SerializeField] private SphereCollider sphereCollider;
    [SerializeField] private GameObject insideFish;
    [SerializeField] float startTime;
    [SerializeField] float endTime;
    public bool buff = false;

    private void Start()
    {
        fishSpawner = FindAnyObjectByType<FishSpawner>();
        startTime = 0;
        endTime = 5;
    }

    private void Update()
    {
        sphereCollider.center = insideFish.transform.localPosition;

        if (startTime < endTime)
        {
            startTime += Time.deltaTime * 1;
        }
        else if(CompareTag("FishPuddle1"))
        {
            fishSpawner.fishPuddles1.Remove(gameObject);
            Destroy(gameObject);
        }
        else
        {
            fishSpawner.fishPuddles2.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
