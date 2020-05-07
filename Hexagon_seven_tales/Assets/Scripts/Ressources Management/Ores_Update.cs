using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ores_Update : MonoBehaviour
{
    public int Ores;
    public GameObject Ressources_UIPanel;
    float elapsed = 0f;
    public int NumberOfExtractor = 0;
    public bool UpdateOresUI = false;

    void Start()
    {
        Ressources_UIPanel = GameObject.Find("Ressources_Panel");
        Ores = 10;
        Ressources_UIPanel.GetComponent<UI_Ressources>().UpdateIntRessources(Ores);
    }

    void Update()
    {
        if (UpdateOresUI)
        {
            Ressources_UIPanel.GetComponent<UI_Ressources>().UpdateIntRessources(Ores);
        }

        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            if (NumberOfExtractor > 0)
            {
                StartCoroutine(More_Ore(5));
            }
        }
    }

    private IEnumerator More_Ore(float waitTime)
        {
            yield return new WaitForSeconds(1);
            Ores = Ores + NumberOfExtractor;
            Ressources_UIPanel.GetComponent<UI_Ressources>().UpdateIntRessources(Ores);
        }
}
