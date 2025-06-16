using System;
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

        switchSide = !switchSide; // Make the boat switch sides.
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("FishPuddle1") || other.gameObject.CompareTag("FishPuddle2"))
        {
            fishSpawner.RemoveFishFromPuddleAndDestroy(other.gameObject);
        }
    }
}
