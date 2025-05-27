using Unity.VisualScripting;
using UnityEngine;

public class PufferFish : MonoBehaviour
{
    private GameManager gameManager;
    private FishSpawner fishSpawner;
    [SerializeField] private float explosionRadius;
    [SerializeField] private SphereCollider explosionCollider;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        fishSpawner = FindAnyObjectByType<FishSpawner>();
        explosionCollider.enabled = false;
        explosionRadius = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = FindAnyObjectByType<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("PufferFish"))
                {
                    PufferFishInAction();
                }
            }
        } 

        transform.position = new Vector3(Mathf.PingPong(Time.time, 2f) + 0.5f,transform.position.y, Mathf.PingPong(Time.time, 6f) + 0.5f);
    }

    void PufferFishInAction()
    {
        explosionCollider.enabled = true;
        explosionRadius = 3f;
        explosionCollider.radius = explosionRadius;
        Destroy(gameObject, 0.2f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(explosionCollider.enabled == true)
        {
            if (other.CompareTag("FishPuddle1"))
            {
                fishSpawner.fishPuddles1.Remove(other.gameObject);
                fishSpawner.fishPuddleCount1--;
                Instantiate(fishSpawner.tapEffectPrefab, other.transform.position, Quaternion.identity);
                gameManager.score1 += 1;
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("FishPuddle2"))
            {
                fishSpawner.fishPuddles2.Remove(other.gameObject);
                fishSpawner.fishPuddleCount2--;
                Instantiate(fishSpawner.tapEffectPrefab, other.transform.position, Quaternion.identity);
                gameManager.score2 += 1;
                Destroy(other.gameObject);
            }
        }
    }
}