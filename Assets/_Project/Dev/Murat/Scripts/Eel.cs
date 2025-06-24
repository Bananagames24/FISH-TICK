using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX.Utility;

public class Eel : MonoBehaviour
{
    private GameManager gameManeger;
    private bool abilityActive = false;
    private bool abilityDisabled = false;
    public int playerInput;
    private NavMeshAgent navMeshAgent;
    [SerializeField] private GameObject elecStun;
    [SerializeField] private List<Vector3> arc1s;
    [SerializeField] private List<Vector3> arc2s;
    [SerializeField] private List<GameObject> temp;
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

        if (abilityActive)
        {
            if (playerInput == 0)
            {
                navMeshAgent.SetDestination(new Vector3(7, transform.position.y, transform.position.z));
                if (transform.position.x > 2)
                {
                    StartCoroutine(gameManeger.EelAbillity(playerInput));
                    for (int i = 0; i < arc1s.Count; i++)
                    {
                        GameObject stun = Instantiate(elecStun);
                        stun.transform.GetChild(0).transform.position = Between(transform.position, new Vector3(0, 0, 0), 0.5f);
                        stun.transform.GetChild(1).transform.position = transform.position;
                        stun.transform.GetChild(2).transform.position = Between(transform.position, arc1s[i], 0.3f);
                        stun.transform.GetChild(3).transform.position = Between(transform.position, arc1s[i], 0.6f);
                        stun.transform.GetChild(4).transform.position = arc1s[i];
                        temp.Add(stun);
                        Destroy(stun, 3);
                    }
                    abilityActive = false;
                    abilityDisabled = true;
                    Destroy(gameObject, 3);
                }
            }
            else if (playerInput == 1)
            {
                navMeshAgent.SetDestination(new Vector3(-7, transform.position.y, transform.position.z));
                if (transform.position.x < -2)
                {
                    StartCoroutine(gameManeger.EelAbillity(playerInput));
                    for (int i = 0; i < arc2s.Count; i++)
                    {
                        GameObject stun = Instantiate(elecStun);
                        stun.transform.GetChild(0).transform.position = Between(transform.position, new Vector3(0, 0, 0), 0.5f);
                        stun.transform.GetChild(1).transform.position = transform.position;
                        stun.transform.GetChild(2).transform.position = Between(transform.position, arc2s[i], 0.3f);
                        stun.transform.GetChild(3).transform.position = Between(transform.position, arc2s[i], 0.6f);
                        stun.transform.GetChild(4).transform.position = arc2s[i];
                        temp.Add(stun);
                        Destroy(stun, 3);
                    }
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
        }
        if (temp.Count!=null)
        {
            if (playerInput == 0)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    temp[i].transform.GetChild(0).transform.position = Between(transform.position, new Vector3(0, 0, 0), 0.5f);
                    temp[i].transform.GetChild(1).transform.position = transform.position;
                    temp[i].transform.GetChild(2).transform.position = Between(transform.position, arc1s[i], 0.3f);
                    temp[i].transform.GetChild(3).transform.position = Between(transform.position, arc1s[i], 0.6f);
                    temp[i].transform.GetChild(4).transform.position = arc1s[i];
                }
            }else if (playerInput == 1)
            {
                for (int i = 0; i < temp.Count; i++)
                {
                    temp[i].transform.GetChild(0).transform.position = Between(transform.position, new Vector3(0, 0, 0), 0.5f);
                    temp[i].transform.GetChild(1).transform.position = transform.position;
                    temp[i].transform.GetChild(2).transform.position = Between(transform.position, arc2s[i], 0.3f);
                    temp[i].transform.GetChild(3).transform.position = Between(transform.position, arc2s[i], 0.6f);
                    temp[i].transform.GetChild(4).transform.position = arc2s[i];
                }
            }
  
        }

    }
    private Vector3 Between(Vector3 a, Vector3 b,float percentage)
    {
        return (b - a) * percentage + a;
    }
    private Vector3 EelMovement()//what place it is going while roming on one side
    {
        xPos = Random.Range(-10f, -1f);
        zPos = Random.Range(-5, 5);

        if (playerInput == 0)
        {
            Destination = new Vector3(xPos, yPos, zPos);
        }
        else if (playerInput == 1)
        {
            Destination = new Vector3(-xPos, yPos, zPos);
        }

        return Destination;
    }
    private void EelInAction()
    {
        abilityActive = true;
        
        if (transform.position.x<0)//checks wat side the eel is on
        {
            playerInput = 0;
        }
        else
        {
            playerInput = 1;
        }
    }
}
