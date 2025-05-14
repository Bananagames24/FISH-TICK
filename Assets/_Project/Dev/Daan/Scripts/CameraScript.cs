using UnityEngine;
using System.Collections;
using UnityEngine.iOS;
using Unity.VisualScripting;

public class CameraScript: MonoBehaviour
{
    [SerializeField] private FishSpawner fishSpawner;
    [SerializeField] private GameManager gameManager;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "FishPuddle1")
                {
                    Destroy(hit.collider.gameObject);
                    fishSpawner.fishPuddleCount1--;
                    gameManager.Score1++;
                    Debug.Log("Hit a fish puddle!");
                }
                else if(hit.collider.tag == "FishPuddle2")
                {
                    Destroy(hit.collider.gameObject);
                    fishSpawner.fishPuddleCount2--;
                    gameManager.Score2++;
                    Debug.Log("Hit a fish puddle!");
                }
                else
                {
                Debug.Log("Hit something else!");
                }
                
            }
        }
    }
}