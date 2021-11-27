using System.Collections.Specialized;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjecPoolManager : MonoBehaviour
{   
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab; 
        public int size;
    }
    public GameObject parent;
    public static ObjecPoolManager Instance;
    

    public List<Pool> pools;
    public Dictionary<string,Queue<GameObject>> poolDictionary;
    void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools)
        {
            Queue<GameObject> objectpool = new Queue<GameObject>();
            for(int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab,parent.transform);
                obj.SetActive(false);
                objectpool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectpool);
        }
    }

    public void SpawnFromPool(string name,string url)
    {
        GameObject spawnObject = poolDictionary["Item"].Dequeue();
        spawnObject.SetActive(true);
        spawnObject.GetComponent<ImageLoader>().updateImage(url);
        TextMeshProUGUI textmeshPro = spawnObject.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        textmeshPro.SetText(name);
        poolDictionary["Item"].Enqueue(spawnObject);
    }

    public void ClearPool()
    {
        foreach (GameObject item in poolDictionary["Item"])
        {
            item.SetActive(false);
        }
    }

}
