using Unity.VisualScripting;
using UnityEngine;

public class CameraScriptMurat: MonoBehaviour
{
    [SerializeField] private FishSpawner fishSpawner;
    [SerializeField] private GameManager gameManager;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.CompareTag("FishPuddle1"))
                {
                    //fishSpawner.fishPuddles1.Remove(hit.collider.gameObject);
                   // Destroy(hit.collider.gameObject);
                   // Instantiate(fishSpawner.tapEffectPrefab, hit.point, Quaternion.identity);
                  //  fishSpawner.fishPuddleCount1--;
                    if (hit.transform.GetComponent<FishPuddleMurat>().buff)
                    {
                        gameManager.score1 += 3;
                    }
                    else
                    {
                        gameManager.score1 += 1;
                    }
                }
                else if(hit.collider.CompareTag("FishPuddle2"))
                {
                 //   fishSpawner.fishPuddles2.Remove(hit.collider.gameObject);
                 //   Destroy(hit.collider.gameObject);
                 //   Instantiate(fishSpawner.tapEffectPrefab, hit.point, Quaternion.identity);
                  //  fishSpawner.fishPuddleCount2--;
                    if (hit.transform.GetComponent<FishPuddleMurat>().buff)
                    {
                        gameManager.score2 += 3;
                    }
                    else
                    {
                        gameManager.score2 += 1;
                    }
                }
            }
        }
    }
}