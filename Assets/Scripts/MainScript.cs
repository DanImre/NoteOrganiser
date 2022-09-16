using System.Collections;
using System;
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


    //classes
    public class Ora
    {
        public string nev { get; set; }
        public string terem { get; set; }
        public DateTime kezdes { get; set; }
        public DateTime vegzes { get; set; }

        public Ora(string nev, string terem, DateTime kezdes, DateTime vegzes)
        {
            this.nev = nev;
            this.terem = terem;
            this.kezdes = kezdes;
            this.vegzes = vegzes;
        }

    }
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
