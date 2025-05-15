using UnityEngine;

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
                if(hit.collider.CompareTag("FishPuddle1"))
                {
                    fishSpawner.fishPuddles1.Remove(hit.collider.gameObject);
                    Destroy(hit.collider.gameObject);
                    fishSpawner.fishPuddleCount1--;
                    gameManager.score1 += 1;
                }
                else if(hit.collider.CompareTag("FishPuddle2"))
                {
                    fishSpawner.fishPuddles2.Remove(hit.collider.gameObject);
                    Destroy(hit.collider.gameObject);
                    fishSpawner.fishPuddleCount2--;
                    gameManager.score2 += 1;
                }
            }
        }
    }
}