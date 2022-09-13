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
            OrarendRepresentation_GO.SetActive(true);
        else
            OrarendUpload_GO.SetActive(true);
        
    }

    public void settingsButtonPressed()
    {
    }
}
