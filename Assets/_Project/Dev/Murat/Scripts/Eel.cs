using UnityEngine;
using UnityEngine.AI;

public class Eel : MonoBehaviour
{
    private GameManager gameManeger;
    private bool abilityActive = false;
    private bool abilityDisabled = false;
    public int playerInput;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    float yPos = 0f;
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
                if (hit.collider.CompareTag("Eel"))//checks if the eel has been tapped
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
                }
            }
        }
        else
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance && !abilityDisabled)
            {
                navMeshAgent.SetDestination(EelMovement());
            }
        }/*
        if (Mathf.Abs(navMeshAgent.velocity.x+ navMeshAgent.velocity.y+ navMeshAgent.velocity.z)>=0.3f)
        {
            animator.Play(1);
            animator.
        }
        else
        {
            animator.Play(0);
        }*/

    }
    private Vector3 EelMovement()//what place it is going while roming on one side
    {
        xPos = Random.Range(-4.5f, 4.5f);
        zPos = Random.Range(-9.5f, -1);

        if (playerInput == 0)
        {
            Destination = new Vector3(xPos, yPos, zPos);
        }
        else if (playerInput == 1)
        {
            Destination = new Vector3(xPos, yPos, -zPos);
        }

        return Destination;
    }
    private void EelInAction()
    {
        abilityActive = true;
        
        if (transform.position.z<0)//checks wat side the eel is on
        {
            playerInput = 0;
        }
        else
        {
            playerInput = 1;
        }
    }
}
