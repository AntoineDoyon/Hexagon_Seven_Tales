using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI_Ressources : MonoBehaviour {

    public Text Total_Ores;

    public void UpdateIntRessources(int Ores)
    {
        Total_Ores.text = Ores.ToString();
    }
}