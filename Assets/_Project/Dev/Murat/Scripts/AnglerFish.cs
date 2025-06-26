using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class AnglerFish : MonoBehaviour
{
    private bool isActive = false;
    private bool deActivateAbillity = false;
    public int playerSide;
    private float radius = 4.5f;
    private float timer = 5;
    private NavMeshAgent navMeshAgent;
    private float yPos = 0f;
    private float xPos;
    private float zPos;
    private Vector3 destination;
    [SerializeField] private GameObject anglerFishLight;

    void Start()
    {
        ChooseSide();
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.SetDestination(AnglerFishMovement());
        anglerFishLight.SetActive(false);

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
                StartCoroutine(LightsFlicker());
            }
            if (timer <= 0)
            {
                RefreshBuff(side, false);
                isActive = false;
                Destroy(gameObject);
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
        else if (navMeshAgent!=null)
        {
            navMeshAgent.SetDestination(transform.position);
        }
    }

    private IEnumerator LightsFlicker()
    {
        anglerFishLight.SetActive(false);
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(0.25f);
            anglerFishLight.SetActive(true);
            yield return new WaitForSeconds(0.25f);
            anglerFishLight.SetActive(false);
        }
    }

    private Vector3 AnglerFishMovement()//what place it is going while roaming on one side
    {
        xPos = Random.Range(-10f, -1f);
        zPos = Random.Range(-5, 5);

        if (playerSide == 0)
        {
            destination = new Vector3(xPos, yPos, zPos);
        }
        else if (playerSide == 1)
        {
            destination = new Vector3(-xPos, yPos, zPos);
        }

        return destination;
    }

    private void ActivateAnglerFishOnMousePosition()
    {
        Ray ray = FindAnyObjectByType<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
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
                collider.gameObject.GetComponent<FishPuddle>().buff = activateBuff;
            }
        }
    }

    private void ChooseSide()
    {
        if (transform.position.x >= 0)
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
        anglerFishLight.SetActive(true);
        /*
         aimation when active
         */
    }
}
