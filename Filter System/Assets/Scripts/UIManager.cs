using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject FilterList;
    public GameObject FilterIcon;
    // Start is called before the first frame update
    public void HideFilter()
    {
        FilterList.SetActive(false);
        FilterIcon.SetActive(true);
    }
    public void ShowFilter()
    {
        FilterList.SetActive(true);
        FilterIcon.SetActive(false);
    }


}
