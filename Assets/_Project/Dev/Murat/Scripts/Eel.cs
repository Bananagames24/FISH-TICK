using UnityEngine;
using UnityEngine.AI;

public class Eel : MonoBehaviour
{
    private GameManager gameManeger;
    private bool abilityActive = false;
    private bool abilityDisabled = false;
    private int playerInput;
    private NavMeshAgent navMeshAgent;
    float yPos = 0.5f;
    float xPos;
    float zPos;
    Vector3 Destination;

    void Start()
    {
        gameManeger = FindAnyObjectByType<GameManager>();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(EelMovement());
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = FindAnyObjectByType<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider);
                if (hit.collider.CompareTag("Eel"))
                {
                    hit.collider.enabled = false;
                    hit.transform.GetComponent<Eel>().EelInAction(); 
                }
            }
        }

        if(abilityActive)
        {
            if (playerInput == 0)
            {
                navMeshAgent.SetDestination(new Vector3(transform.position.x, transform.position.y, 3));
                if (transform.position.z > 2)
                {
                    StartCoroutine(gameManeger.EelAbillity(playerInput));
                    abilityActive = false;
                    abilityDisabled = true;
                    Destroy(gameObject,3);
                    Debug.Log(playerInput);
                }
            }
            else if (playerInput == 1)
            {
                navMeshAgent.SetDestination(new Vector3(transform.position.x, transform.position.y, -3));
                if (transform.position.z < -2)
                {
                    StartCoroutine(gameManeger.EelAbillity(playerInput));
                    abilityActive = false;
                    abilityDisabled = true;
                    Destroy(gameObject, 3);
                    Debug.Log(playerInput);
                }
            }
        }else
        {
            if(abilityDisabled)
            {

            }else
            {
                
                float dist = Vector3.Distance(transform.position, Destination);
                if (dist < 1f)
                {
                    navMeshAgent.SetDestination(EelMovement());
                    Debug.Log("dest");
                }
            }
        }
    }
    private Vector3 EelMovement()
    {
        xPos = Random.Range(-3f, 3f);
        zPos = Random.Range(-9.5f, -1);
        if(playerInput == 0)
        {
            Destination = new Vector3(xPos, yPos, zPos);
        }else if(playerInput == 1)
        {
            Destination = new Vector3(xPos, yPos, -zPos);
        }
        return Destination;
    }
    private void EelInAction()
    {
        Debug.Log("abilety active");
        abilityActive = true;
        
        if (transform.position.z<0)
        {
            playerInput = 0;

        }
        else
        {
            playerInput = 1;
        }
    }
}
