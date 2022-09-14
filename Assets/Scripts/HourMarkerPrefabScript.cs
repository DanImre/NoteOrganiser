using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HourMarkerPrefabScript : MonoBehaviour
{
    MainScript ms;

    // Start is called before the first frame update
    void Start()
    {
        ms = GameObject.Find("MainScriptHolder").GetComponent<MainScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Variables for render:
    public GameObject infoPanel_GO;
    public TMP_Text name_T;
    public TMP_Text GYEA_T;
    public TMP_Text Terem_T;
    public void RenderSession(System.DateTime kezdes, System.DateTime vegzes, string name, string terem, bool gyakorlatE)
    {
        //kontextus:
        //Ezt �gy h�vjuk meg hogy megkeress�k a kezedes.Hour �dik prefabet, ha el van tolva p�r perccel, akkor padding-el lejebb vissz�k
        infoPanel_GO.SetActive(true);
        float topPadding = this.GetComponent<RectTransform>().sizeDelta.y * (kezdes.Minute / 60);
        System.TimeSpan elteltido = vegzes - kezdes;
        float bottomPadding = this.GetComponent<RectTransform>().sizeDelta.y * ((elteltido.Hours*60 + elteltido.Minutes) / -60 + 1);

        RectTransform rt = infoPanel_GO.GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(rt.offsetMax.x, topPadding);
        rt.offsetMin = new Vector2(rt.offsetMin.x, bottomPadding);

        name_T.text = name;
        if (gyakorlatE)
            GYEA_T.text = "Gyakorlat";
        else
            GYEA_T.text = "El�ad�s";
        Terem_T.text = terem;
    }

    public void updateInfoPanel(float newSize,float oldSize)
    {
        if (!infoPanel_GO.activeSelf)
            return;

        RectTransform rt = infoPanel_GO.GetComponent<RectTransform>();
        if (rt.offsetMin.y != 0)
            rt.offsetMin = new Vector2(rt.offsetMin.x, rt.offsetMin.y * newSize / oldSize);
    }
}
