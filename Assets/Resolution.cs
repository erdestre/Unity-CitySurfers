using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{

    float resX = 1080, resY = 1920;
    private Vector2 resPos;
    GameObject currentObj;

    private void Start()
    {
        SetResolution(resX, resY);
    }

    private void SetResolution(float newResX, float newResY)
    {
        GetResolution();
        currentObj = gameObject;
        Loop(currentObj, newResX, newResY, resPos);

    }
    private void Loop(GameObject currentObj, float newResX, float newResY, Vector2 resPos)
    {
        foreach (Transform child in currentObj.transform)
        {
            if (child.transform.childCount > 0 && !child.name.Equals("Fill"))
            {
                Loop(child.gameObject, newResX, newResY, resPos);
            }
            RectTransform rt = child.gameObject.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(resX * rt.anchoredPosition.x / newResX, resY * rt.anchoredPosition.y / newResY);
            if (!rt.name.Equals("Fill")) //Fill bug fixed here. 
            {
                rt.sizeDelta = new Vector2(resX * rt.rect.width / newResX, resY * rt.rect.height / newResY);
            }
            UnityEngine.UI.Text text = child.gameObject.GetComponent<UnityEngine.UI.Text>();
            if (text != null)
            {
                child.gameObject.GetComponent<UnityEngine.UI.Text>().fontSize = (int)(text.fontSize * (resX / newResX));
            }

        }
    }

    private void GetResolution()
    {
        resX = gameObject.GetComponent<RectTransform>().rect.width;
        resY = gameObject.GetComponent<RectTransform>().rect.height;
        resPos = gameObject.transform.position;
    }

}