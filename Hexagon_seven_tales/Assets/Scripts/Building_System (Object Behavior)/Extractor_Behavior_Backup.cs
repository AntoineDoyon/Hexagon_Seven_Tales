using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Extractor_Behavior_Backup : MonoBehaviour
{
    public int Ore;
    public GameObject Ressources_UIPanel;
    float elapsed = 0f;

    void Start()
    {
        Ressources_UIPanel = GameObject.Find("Ressource_Panel");
        Ressources_UIPanel.GetComponent<UI_Ressources>().UpdateIntRessources(Ore);
        StartCoroutine(More_Ore(1));
    }

    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            OutputTime();
            StartCoroutine(More_Ore(5));
        }

    }

    void OutputTime()
    {
        Debug.Log(Time.time);
    }

    private IEnumerator More_Ore(float waitTime)
    {
        yield return new WaitForSeconds(1);
        Ore = Ore + 1;
        Ressources_UIPanel.GetComponent<UI_Ressources>().UpdateIntRessources(Ore);
    }

}
