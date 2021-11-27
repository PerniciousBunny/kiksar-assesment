using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class ImageLoader: MonoBehaviour
{
    Image image;
    public Sprite placeholder;
    void Awake()
    {
        image = gameObject.transform.GetChild(0).GetComponent<Image>();
    }
    public void updateImage(string url)
    {
        StartCoroutine(DownloadImage(url));
    }
    public void resetImage()
    {
        image.overrideSprite = placeholder;
    }
    IEnumerator DownloadImage(string MediaUrl)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(MediaUrl);
        yield return www.SendWebRequest();
        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(www.error);
        }
        else
        {
            Texture2D tex = ((DownloadHandlerTexture)www.downloadHandler).texture;
            Sprite sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(tex.width / 2, tex.height / 2));
            image.overrideSprite = sprite;
        }       
    }
}
