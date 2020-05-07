using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory_Behavior : MonoBehaviour
{
    public bool Building_state = true;
    public GameObject RessourcesManager;
    public string Ressources = "Ores";
    public bool Update_Status;

    void Start()
    {
        RessourcesManager = GameObject.Find("RessourcesManager");
        Update_Status = RessourcesManager.GetComponent<Ores_Update>().UpdateOresUI = true;
        RessourcesManager.GetComponent<Ores_Update>().Ores -= 100;
        Update_Status = RessourcesManager.GetComponent<Ores_Update>().UpdateOresUI = false;

            if (Building_state)
            {
                //What happen if the building have a different state
            }


    }

    void Update()
    {
        //Evaluate State of the building
        //Evaluate Power Consuption 
        //Evaluate Modifier effects
    }
}
