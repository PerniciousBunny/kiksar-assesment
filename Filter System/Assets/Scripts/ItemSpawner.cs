using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
public class ItemSpawner : MonoBehaviour
{
    ObjecPoolManager objectpooler;
    public ItemListObject itemDatabase = new ItemListObject();
    string category = "Watches";
    string subCategory = "Male";
    void Start()
    {
        objectpooler = ObjecPoolManager.Instance;
        TextAsset asset = Resources.Load("Items") as TextAsset;
        itemDatabase = JsonUtility.FromJson<ItemListObject>(asset.text);
        showItems(itemDatabase.Items);
    }    

    void showItems(List<Items> items)
    {
        objectpooler.ClearPool();
        foreach (Items item in items)
        {
            objectpooler.SpawnFromPool(item.Name,item.Url);
        }
    }
    public void updateCategory(TMP_Dropdown dropdown)
    {
        category = dropdown.captionText.text;
        Debug.Log(category);
    }
    public void updateSubCategory(TMP_Dropdown dropdown)
    {
        subCategory = dropdown.captionText.text;
    }

    public void applyFilter()
    {
        List<Items> filteredList = (from item in itemDatabase.Items
                                    where item.Category == category && item.SubCategory == subCategory
                                    select item).ToList();
        showItems(filteredList);
    }

    public void clearFilter()
    {
        showItems(itemDatabase.Items);
    }
}
