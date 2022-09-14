using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OrarendRepresentationScript : MonoBehaviour
{
    //given
    public GameObject prefab;

    //local
    List<GameObject> prefabs = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < 24; i++)
        {
            GameObject temp = GameObject.Instantiate(prefab, this.transform);
            temp.GetComponent<RectTransform>().localPosition -= new Vector3(0, i * 100, 0);
            temp.transform.GetChild(0).GetComponent<TMP_Text>().text = i + ":00";
            prefabs.Add(temp);
        }
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.mouseScrollDelta.y > 0)
        {
            bool lehetZoomolni = false;
            for (int i = 1; i < prefabs.Count; i++)
                if (prefabs[i].GetComponent<RectTransform>().localPosition.y > -200 * i)
                {
                    prefabs[i].GetComponent<RectTransform>().localPosition -= new Vector3(0, 10 * i, 0);
                    lehetZoomolni = true;
                }
            if (lehetZoomolni)
                this.GetComponent<RectTransform>().sizeDelta += new Vector2(0, 10 * 24);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.mouseScrollDelta.y < 0)
        {
            bool lehetZoomolni = false;
            for (int i = 1; i < prefabs.Count; i++)
                if (prefabs[i].GetComponent<RectTransform>().localPosition.y < -50 * i)
                {
                    prefabs[i].GetComponent<RectTransform>().localPosition += new Vector3(0, 10 * i, 0);
                    lehetZoomolni = true;
                }
            if (lehetZoomolni)
                this.GetComponent<RectTransform>().sizeDelta -= new Vector2(0, 10 * 24);
        }
        
    }
}
