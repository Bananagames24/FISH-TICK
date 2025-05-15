using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Ultimate : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider UltimateBar;


    private void Update()
    {
        if (UltimateBar.value == UltimateBar.maxValue)
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255, 255);
        }
        else
        {
            gameObject.GetComponent<UnityEngine.UI.Image>().color = new Color(255, 255, 255, 0.5f);
        }
    }
    public void UseUltimate()
    {
        UltimateBar.value = 0;
    }
}
