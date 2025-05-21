using UnityEngine;
using UnityEngine.UIElements;

public class FishPuddle : MonoBehaviour
{
    [SerializeField] private FishSpawner fishSpawner;
    Vector3 minSize;
    Vector3 maxSize;

    private void Start()
    {
        fishSpawner = FindAnyObjectByType<FishSpawner>();
        minSize = new Vector3(0.001f, 0.001f, 0.001f);
        maxSize = new Vector3(0.6f, 0.6f, 0.6f);
        transform.localScale = minSize;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 1, 0) * 25 * Time.deltaTime);

        if(transform.localScale.x < maxSize.x)
        {
            transform.localScale += new Vector3(0.05f, 0.05f, 0.05f) * Time.deltaTime;
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
