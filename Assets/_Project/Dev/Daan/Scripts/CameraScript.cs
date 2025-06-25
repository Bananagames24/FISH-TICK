using UnityEngine;

public class CameraScript: MonoBehaviour
{
    [SerializeField] private FishSpawner fishSpawner;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Ultimate ultimateP1;
    [SerializeField] private Ultimate ultimateP2;


    private void Start()
    {
        Input.multiTouchEnabled = false;
    }

    void Update()
    {
        bool anyMouseOrTapUpOrDown = Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1);
        if (anyMouseOrTapUpOrDown)
        {
            TryHitFish();
        }
    }

    private void TryHitFish()
    {
        // Try hit a fish.
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit)) return;

        // If we hit anything else than a fish puddle, we return (do nothing).
        if (!hit.collider.CompareTag("FishPuddle1") && !hit.collider.CompareTag("FishPuddle2")) return;

        // Text +1 score on the fish puddle that was hit.
        Instantiate(fishSpawner.scoreTextPrefab, hit.point, Quaternion.identity);

        // Remove the fish and destroy
        fishSpawner.RemoveFishFromPuddleAndDestroy(hit.collider.gameObject);

        // Do a nice tap effect
        Instantiate(fishSpawner.tapEffectPrefab, hit.point, Quaternion.identity);

        // Increase the score.
        bool isPlayer1 = hit.collider.CompareTag("FishPuddle1");
        gameManager.IncreaseScore(1, isPlayer1);

        ultimateP1.ultimateFillAmount += isPlayer1 ? 0.015f : 0f;
        ultimateP2.ultimateFillAmount += isPlayer1 ? 0f : 0.015f;

    }
}