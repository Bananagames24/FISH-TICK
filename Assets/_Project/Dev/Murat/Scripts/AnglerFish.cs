using UnityEngine;

public class AnglerFish : MonoBehaviour
{
    private bool isActive = false;
    public int playerSide;
    private float radius = 3;
    private float timer = 5;
    void Start()
    {
        ChoseSide();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
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
        if (isActive)
        {

            switch (playerSide)
            {
                case 0:
                    Collider[] colliders1 = Physics.OverlapSphere(transform.position, radius);
                    foreach (Collider collider in colliders1)
                    {
                        if (collider.CompareTag("FishPuddle1"))
                        {
                            collider.transform.GetComponent<FishPuddleMurat>().buff = true;
                        }
                    }
                    break;
                case 1:
                    Collider[] colliders2 = Physics.OverlapSphere(transform.position, radius);
                    foreach (Collider collider in colliders2)
                    {
                        if (collider.CompareTag("FishPuddle2"))
                        {
                            collider.transform.GetComponent<FishPuddleMurat>().buff = true;
                        }
                    }
                    break;
                default:
                    break;
            }
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isActive = false;
                Destroy(gameObject, 1);
            }
        }
        else
        {
            switch(playerSide)
            {
                case 0:
                    Collider[] colliders1 = Physics.OverlapSphere(transform.position, radius);
                    foreach (Collider collider in colliders1)
                    {
                        if (collider.CompareTag("FishPuddle1"))
                        {
                            collider.transform.GetComponent<FishPuddleMurat>().buff = false;
                        }
                    }
                    break;
                case 1:
                    Collider[] colliders2 = Physics.OverlapSphere(transform.position, radius);
                    foreach (Collider collider in colliders2)
                    {
                        if (collider.CompareTag("FishPuddle2"))
                        {
                            collider.transform.GetComponent<FishPuddleMurat>().buff = false;
                        }
                    }
                    break;
                default:
                    break;
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
    }
}
