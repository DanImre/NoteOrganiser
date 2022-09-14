using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PirosLegyen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Image img;

    public void pirossa()
    {
        img = this.GetComponent<Image>();
        img.color = new Color(255, 0, 0);
    }
}
