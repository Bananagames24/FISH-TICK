using UnityEngine;
using UnityEngine.AI;

public class Boat : MonoBehaviour
{
    public bool switchSide = false;
    private FishSpawner fishSpawner;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        fishSpawner = FindAnyObjectByType<FishSpawner>();
    }
    
    void Update()
    {
        if (switchSide)
        {
            agent.SetDestination(new Vector3(fishSpawner.fishPuddles1[0].transform.position.x, fishSpawner.fishPuddles1[0].transform.position.y, fishSpawner.fishPuddles1[0].transform.position.z));
        }

        if (!switchSide)
        {
            agent.SetDestination(new Vector3(fishSpawner.fishPuddles2[0].transform.position.x, fishSpawner.fishPuddles2[0].transform.position.y, fishSpawner.fishPuddles2[0].transform.position.z));
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = FindAnyObjectByType<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Boat"))
                {
                    if(!switchSide)
                    {
                        switchSide = true;
                    }
                    else
                    {
                        switchSide = false;
                    }
                }
            }
        }
    }
   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FishPuddle1"))
        {
            fishSpawner.fishPuddles1.Remove(other.gameObject);
            fishSpawner.fishPuddleCount1--;
            Destroy(other.gameObject);
        }

        if (other.CompareTag("FishPuddle2"))
        {
            fishSpawner.fishPuddles2.Remove(other.gameObject);
            fishSpawner.fishPuddleCount2--;
            Destroy(other.gameObject);
        }
    }
}
