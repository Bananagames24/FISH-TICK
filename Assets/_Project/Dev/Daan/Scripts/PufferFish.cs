using UnityEngine;
using UnityEngine.AI;

public class PufferFish : MonoBehaviour
{
    private GameManager gameManager;
    private FishSpawner fishSpawner;
    [SerializeField] private float explosionRadius;
    [SerializeField] private SphereCollider explosionCollider;
    private Vector3 fieldPosition;
    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        fishSpawner = FindAnyObjectByType<FishSpawner>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        fieldPosition.y = 0f;
        fieldPosition.x = Random.Range(-10f, 10f);
        fieldPosition.z = Random.Range(-5f, 5f);
        navMeshAgent.SetDestination(fieldPosition);
        explosionCollider.enabled = false;
        Destroy(gameObject, 10f); // Destroy the PufferFish after 10 seconds if not tapped
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
                    Instantiate(fishSpawner.pufferfishEffectPrefab, hit.point, Quaternion.identity);
                }
            }
        }

        if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            fieldPosition.x = Random.Range(-10f, 10f);
            fieldPosition.z = Random.Range(-5f, 5f);
            navMeshAgent.SetDestination(fieldPosition);
        }
    }

    void PufferFishInAction()
    {
        explosionCollider.enabled = true;
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
                Instantiate(fishSpawner.tapEffectPrefab, other.transform.position, Quaternion.identity);
                Instantiate(fishSpawner.scoreTextPrefab, other.transform.position, Quaternion.identity);
                gameManager.score1 += 1;
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("FishPuddle2"))
            {
                fishSpawner.fishPuddles2.Remove(other.gameObject);
                Instantiate(fishSpawner.tapEffectPrefab, other.transform.position, Quaternion.identity);
                Instantiate(fishSpawner.scoreTextPrefab, other.transform.position, Quaternion.identity);
                gameManager.score2 += 1;
                Destroy(other.gameObject);
            }
            else if (other.CompareTag("PufferFish"))
            {
                PufferFishInAction();
                Instantiate(fishSpawner.pufferfishEffectPrefab, other.transform.position, Quaternion.identity);
            }
        }
    }
}