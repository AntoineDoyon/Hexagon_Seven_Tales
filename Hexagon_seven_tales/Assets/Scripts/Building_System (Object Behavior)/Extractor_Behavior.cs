using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor_Behavior : MonoBehaviour
{
    public bool Building_state = true;
    public GameObject RessourcesManager;
    public string Ressources = "Ores";
    public bool Update_Status;

    void Start()
    {
        RessourcesManager = GameObject.Find("RessourcesManager");
        Update_Status = RessourcesManager.GetComponent<Ores_Update>().UpdateOresUI = true;
        RessourcesManager.GetComponent<Ores_Update>().Ores -= 10;
        Update_Status = RessourcesManager.GetComponent<Ores_Update>().UpdateOresUI = false;
        RessourcesManager.GetComponent<Ores_Update>().NumberOfExtractor += 5;
        if (Ressources == "Ores")
        {
            //RessourcesManager = RessourcesManager.GetComponent<Ores_Update>();
            if (Building_state)
            {
                //RessourcesManager.NumberOfExtractor = RessourcesManager.NumberOfExtractor + 1;
            }
        }
        
    }

    void Update()
    {
        //Evaluate State of the building
        //Evaluate Power Consuption 
        //Evaluate Modifier effects
    }
}
