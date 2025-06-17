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
            ActivateAnglerFishOnMousePosition();
        }

        if (isActive)
        {
            string side = playerSide == 0 ? "FishPuddle1" : "FishPuddle2";
            RefreshBuff(side, true);
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isActive = false;
                Destroy(gameObject, 1);
            }
        }
        else
        {
            string side = playerSide == 0 ? "FishPuddle1" : "FishPuddle2";
            RefreshBuff(side, false);
        }

    }

    private static void ActivateAnglerFishOnMousePosition()
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
                collider.transform.GetComponent<FishPuddleMurat>().buff = activateBuff;
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
