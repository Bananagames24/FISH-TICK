using System;
using System.Security;
using UnityEngine;
using UnityEngine.AI;

public class Boat : MonoBehaviour
{
    public bool switchSide = false;
    private FishSpawner fishSpawner;
    private NavMeshAgent agent;
    private bool WhichSide;

    public ParticleSystem boatDestroyFish;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        fishSpawner = FindAnyObjectByType<FishSpawner>();
    }
    
    void Update()
    {
        if(transform.position.x < 0)
        {
            WhichSide = false; // Boat is on the left side
        }
        else
        {
            WhichSide = true; // Boat is on the right side
        }

        GoToFirstFishFromCurrentPuddle();

        if (Input.GetMouseButtonDown(0))
        {
            SwitchSideOnHitBoat();
        }
    }

    private void GoToFirstFishFromCurrentPuddle()
    {
        int puddleIndex = switchSide ? 0 : 1;
        bool hasFish = fishSpawner.GetFirstFishFromPuddle(puddleIndex, out Transform fish);
        if (hasFish)
        {
            agent.SetDestination(fish.position);
        }
    }

    private void SwitchSideOnHitBoat()
    {
        
        Ray ray = FindAnyObjectByType<Camera>().ScreenPointToRay(Input.mousePosition);

        // Try to hit the boat. If we don't hit a boat, we return (do nothing).
        if (!Physics.Raycast(ray, out RaycastHit hit) || !hit.collider.CompareTag("Boat")) return;

        // Only switch side if the boat is actually on the other side
        if ((WhichSide == false && switchSide) || (WhichSide == true && !switchSide))
        {
            switchSide = !switchSide; // Make the boat switch sides.
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FishPuddle1") || other.gameObject.CompareTag("FishPuddle2"))
        {
            Instantiate(boatDestroyFish, other.transform.position, Quaternion.identity);
            fishSpawner.RemoveFishFromPuddleAndDestroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("PufferFish"))
        {
            Instantiate(boatDestroyFish, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Eel"))
        {
            Instantiate(boatDestroyFish, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("AnglerFish"))
        {
            Instantiate(boatDestroyFish, other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
        }
    }
}
