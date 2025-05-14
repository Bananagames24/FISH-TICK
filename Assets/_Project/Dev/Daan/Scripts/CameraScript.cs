using UnityEngine;
using System.Collections;
using UnityEngine.iOS;
using Unity.VisualScripting;

public class CameraScript: MonoBehaviour
{
    [SerializeField] private FishSpawner fishSpawner;
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if(hit.collider.tag == "FishPuddle")
                {
                    Destroy(hit.collider.gameObject);
                    fishSpawner.fishPuddleCount--;
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