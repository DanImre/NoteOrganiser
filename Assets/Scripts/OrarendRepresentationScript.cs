using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
            //temp.GetComponent<RectTransform>().localPosition -= new Vector3(0, i * 100, 0);
            temp.transform.GetChild(0).GetComponent<TMP_Text>().text = i + ":00";
            prefabs.Add(temp);
        }
        createSession();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && Input.mouseScrollDelta.y > 0)
        {
            bool lehetZoomolni = false;
            for (int i = 0; i < prefabs.Count; i++)
                if (prefabs[i].GetComponent<RectTransform>().sizeDelta.y > 50)
                {
                    float oldSize = prefabs[i].GetComponent<RectTransform>().sizeDelta.y;
                    prefabs[i].GetComponent<RectTransform>().sizeDelta -= new Vector2(0, 10);
                    float newSize = oldSize - 10;
                    prefabs[i].GetComponent<HourMarkerPrefabScript>().updateInfoPanel(newSize, oldSize);
                    lehetZoomolni = true;
                }
            if (lehetZoomolni)
            {
                Canvas.ForceUpdateCanvases();
                this.transform.GetComponent<VerticalLayoutGroup>().enabled = false;
                this.transform.GetComponent<VerticalLayoutGroup>().enabled = true;
            }
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.mouseScrollDelta.y < 0)
        {
            bool lehetZoomolni = false;
            for (int i = 0; i < prefabs.Count; i++)
                if (prefabs[i].GetComponent<RectTransform>().sizeDelta.y < 150)
                {
                    float oldSize = prefabs[i].GetComponent<RectTransform>().sizeDelta.y;
                    prefabs[i].GetComponent<RectTransform>().sizeDelta += new Vector2(0, 10);
                    float newSize = oldSize + 10;
                    prefabs[i].GetComponent<HourMarkerPrefabScript>().updateInfoPanel(newSize, oldSize);
                    lehetZoomolni = true;
                }
            if (lehetZoomolni)
            {
                Canvas.ForceUpdateCanvases();
                this.transform.GetComponent<VerticalLayoutGroup>().enabled = false;
                this.transform.GetComponent<VerticalLayoutGroup>().enabled = true;
            }
        }
        
    }

    public void createSession()
    {
        prefabs[0].GetComponent<HourMarkerPrefabScript>().RenderSession(new System.DateTime(2000, 1, 1, 1, 0, 0), new System.DateTime(2000, 1, 1, 3, 0, 0), "proba1", "F-2", true);
    }
}
