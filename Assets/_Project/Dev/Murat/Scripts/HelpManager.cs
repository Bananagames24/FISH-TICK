using System.Collections.Generic;
using UnityEngine;

public class HelpManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> helpList;
    private int page = 0;
    [SerializeField] private GameObject turnPage1;
    [SerializeField] private GameObject turnPage2;
    private void Start()
    {
        ThePage();
    }
    private void ThePage()
    {
        if (page == 0)
        {
            turnPage1.SetActive(false);
        }
        else
        {
            turnPage1.SetActive(true);
        }
        if (page == helpList.Count - 1)
        {
            turnPage2.SetActive(false);
        }
        else
        {
            turnPage2.SetActive(true);
        }
        for (int i = 0; i < helpList.Count; i++)
        {
            if (i == page)
            {
                helpList[i].SetActive(true);
            }
            else
            {
                helpList[i].SetActive(false);
            }
        }
    }
    public void PageTurn1()
    {
        if (page != 0)
        {
            page--;
            ThePage();
        }
    }
    public void PageTurn2()
    {
        if (page != helpList.Count - 1)
        {
            page++;
            ThePage();
        }
    }
}
