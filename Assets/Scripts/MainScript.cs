using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    //given:
    public GameObject OrarendRepresentation_GO;
    public GameObject OrarendUpload_GO;
    public GameObject Settings_GO;

    //local:
    private bool OrarendAlreadyUploaded = false;
    

    public void orarendButtonPressed()
    {
        if (OrarendAlreadyUploaded)
        {
            OrarendRepresentation_GO.SetActive(true);
            return;
        }

        OrarendUpload_GO.SetActive(true);
        //beolvasás
        
    }

    public void settingsButtonPressed()
    {
        List<int> lista = new List<int>();

        int counter = 0;
        for (int i = 0; i < lista.Count; i++)
            if(lista[i] == 1)
            {
                ++counter;
                lista.RemoveAt(i);
                --i;
            }
    }
}
