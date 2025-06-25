using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AnglerFish : MonoBehaviour
{
    private bool isActive = false;
    private bool deActivateAbillity = false;
    public int playerSide;
    private float radius = 3;
    private float timer = 5;
    private NavMeshAgent navMeshAgent;
    private float yPos = 0f;
    private float xPos;
    private float zPos;
    private Vector3 Destination;
    [SerializeField] private GameObject light;
    void Start()
    {
        ChoseSide();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(AnglerFishMovement());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ActivateAnglerFishOnMousePosition();
        }

        if (isActive)
        {
            string side = playerSide == 0 ? "FishPuddle1" : "FishPuddle2";
            RefreshBuff(side, true);
            timer -= Time.deltaTime;
            if(timer <= 2&& !deActivateAbillity)
            {
                deActivateAbillity = true;
                StartCoroutine(LightsFlikker());
            }
            if (timer <= 0)
            {
                isActive = false;
                Destroy(gameObject, 1f);
            }
        }
        else
        {
            string side = playerSide == 0 ? "FishPuddle1" : "FishPuddle2";
            RefreshBuff(side, false);
        }

        if (!isActive&& !deActivateAbillity)
        {
            if (navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
            {
                navMeshAgent.SetDestination(AnglerFishMovement());
            }
        }
        else
        {
            navMeshAgent.SetDestination(transform.position);
        }
    }
    private IEnumerator LightsFlikker()
    {
        for (int i = 0; i < 3; i++)
        {
            light.SetActive(false);
            yield return new WaitForSeconds(0.25f);
            light.SetActive(true);
            yield return new WaitForSeconds(0.25f);
        }
    }
    private Vector3 AnglerFishMovement()//what place it is going while roming on one side
    {
        xPos = Random.Range(-10f, -1f);
        zPos = Random.Range(-5, 5);

        if (playerSide == 0)
        {
            Destination = new Vector3(xPos, yPos, zPos);
        }
        else if (playerSide == 1)
        {
            Destination = new Vector3(-xPos, yPos, zPos);
        }

        return Destination;
    }

    private void ActivateAnglerFishOnMousePosition()
    {
        Ray ray = FindAnyObjectByType<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider);
            if (hit.collider.CompareTag("AnglerFish"))
            {
                hit.collider.enabled = false;
                hit.transform.GetComponent<AnglerFish>().AnglerFishAbillity();
            }
        }
    }

    /// <summary>
    /// Activate the buff of all fish puddles with the specified tag within a certain radius.
    /// </summary>
    /// <param name="tag"> The tag of the puddles to include. </param>
    /// <param name="activateBuff"> Wether to activate the buff or not. </param>
    private void RefreshBuff(string tag, bool activateBuff)
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag(tag))
            {
                collider.transform.GetComponent<FishPuddleMurat>().buff = activateBuff;
            }
        }
    }

    private void ChoseSide()
    {
        if (transform.position.z >=0)
        {
            playerSide = 1;
        }
        else
        {
            playerSide = 0;
        }
    }
    private void AnglerFishAbillity()
    {
        isActive = true;
        light.SetActive(true);
        /*
         aimation when active
         instantiate light
         */
    }
}
