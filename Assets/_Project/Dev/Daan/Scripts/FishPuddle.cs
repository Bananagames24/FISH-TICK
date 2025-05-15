using UnityEngine;

public class FishPuddle : MonoBehaviour
{
    [SerializeField] private FishSpawner fishSpawner;
    Vector3 minSize;
    Vector3 maxSize;

    public float scoreMultiplier = 1f;

    private void Start()
    {
        fishSpawner = FindAnyObjectByType<FishSpawner>();
        minSize = new Vector3(0.3f, 0.3f, 0.3f);
        maxSize = new Vector3(1.5f, 1.5f, 1.5f);
        transform.localScale = minSize;
    }

    private void Update()
    {
        if(transform.localScale.x >= 1)
        {
            scoreMultiplier = 2f;
        }
        if(transform.localScale.x < maxSize.x)
        {
            transform.localScale += new Vector3(0.15f, 0.15f, 0.15f) * Time.deltaTime;
        }
        else if(CompareTag("FishPuddle1"))
        {
            fishSpawner.fishPuddleCount1--;
            Destroy(gameObject);
        }
        else if (CompareTag("FishPuddle2"))
        {
            fishSpawner.fishPuddleCount2--;
            Destroy(gameObject);
        }
    }
}
