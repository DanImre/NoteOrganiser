using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    public Button Edit_B;
    public void RenderSession(System.DateTime kezdes, System.DateTime vegzes, string name, string terem, bool gyakorlatE)
    {
        //kontextus:
        //Ezt úgy hívjuk meg hogy megkeressük a kezedes.Hour ödik prefabet, ha el van tolva pár perccel, akkor padding-el lejebb visszük
        infoPanel_GO.SetActive(true);
        float topPadding = this.GetComponent<RectTransform>().sizeDelta.y * (kezdes.Minute / 60f);
        System.TimeSpan elteltido = vegzes - kezdes;
        float bottomPadding = this.GetComponent<RectTransform>().sizeDelta.y * ((elteltido.Hours*60 + elteltido.Minutes) / 60f - 1) + topPadding;

        RectTransform rt = infoPanel_GO.GetComponent<RectTransform>();
        rt.offsetMax = new Vector2(rt.offsetMax.x, -topPadding);
        rt.offsetMin = new Vector2(rt.offsetMin.x, -bottomPadding);

        name_T.text = name;
        if (gyakorlatE)
            GYEA_T.text = "Gyakorlat";
        else
            GYEA_T.text = "Elõadás";
        Terem_T.text = terem;
    }

    public void updateInfoPanel(float newSize,float oldSize)
    {
        if (!infoPanel_GO.activeSelf)
            return;

        RectTransform rt = infoPanel_GO.GetComponent<RectTransform>();
        rt.offsetMin = new Vector2(rt.offsetMin.x, rt.offsetMin.y * newSize / oldSize);

        rt = name_T.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x * newSize / oldSize, rt.sizeDelta.y * newSize / oldSize);
        rt = GYEA_T.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x * newSize / oldSize, rt.sizeDelta.y * newSize / oldSize);
        rt = Terem_T.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x * newSize / oldSize, rt.sizeDelta.y * newSize / oldSize);
        rt = Edit_B.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(rt.sizeDelta.x * newSize / oldSize, rt.sizeDelta.y * newSize / oldSize);
    }

    public void EditButtonPressed()
    {
        this.transform.parent.GetComponent<OrarendRepresentationScript>().EditLesson();
    }
}
