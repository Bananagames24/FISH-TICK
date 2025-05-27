using UnityEngine;

public class Eel : MonoBehaviour
{
    private GameManager gameManeger;
    private bool abilityActive = false;
    private int playerInput;

    void Start()
    {
        gameManeger = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = FindAnyObjectByType<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider);
                if (hit.collider.CompareTag("Eel"))
                {
                    hit.collider.enabled = false;
                    hit.transform.GetComponent<Eel>().EelInAction(); 
                }
            }
        }

        if(abilityActive)
        {
            if (playerInput == 0)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, 3), Time.deltaTime);
                if (transform.position.z > 2)
                {
                    StartCoroutine(gameManeger.EelAbillity(playerInput));
                    abilityActive = false;
                    Destroy(gameObject,3);
                    Debug.Log(playerInput);
                }
            }
            else if (playerInput == 1)
            {
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, -3), Time.deltaTime);
                if (transform.position.z < -2)
                {
                    StartCoroutine(gameManeger.EelAbillity(playerInput));
                    abilityActive = false;
                    Destroy(gameObject, 3);
                    Debug.Log(playerInput);
                }
            }
        }
    }
    private void EelInAction()
    {
        Debug.Log("abilety active");
        abilityActive = true;
        
        if (transform.position.z<0)
        {
            playerInput = 0;
        }
        else
        {
            playerInput = 1;
        }
    }
}
