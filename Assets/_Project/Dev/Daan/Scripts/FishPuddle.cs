using UnityEngine;
using UnityEngine.UIElements;

public class FishPuddle : MonoBehaviour
{
    [SerializeField] private FishSpawner fishSpawner;
    Vector3 minSize;
    Vector3 maxSize;

    public float scoreMultiplier = 1f;

    private void Start()
    {
        fishSpawner = FindAnyObjectByType<FishSpawner>();
        minSize = new Vector3(0.1f, 0.1f, 0.1f);
        maxSize = new Vector3(0.6f, 0.6f, 0.6f);
        transform.localScale = minSize;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * 25 * Time.deltaTime);
        if (transform.localScale.x >= 0.4f)
        {
            scoreMultiplier = 2f;
        }
        if(transform.localScale.x < maxSize.x)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f) * Time.deltaTime;
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
