using UnityEngine;

public class PufferFish : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = FindAnyObjectByType<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("PufferFish"))
                {
                    Destroy(hit.collider.gameObject);
                    PufferFishInAction();
                }
            }
        } 
    }

    void PufferFishInAction()
    {
        
    }
}