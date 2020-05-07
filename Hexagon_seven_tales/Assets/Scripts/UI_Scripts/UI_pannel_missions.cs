using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UI_pannel_missions : MonoBehaviour
{
    public GameObject ActionHUD;
    public GameObject Dialogue;
    public GameObject ObjectiveBar;
    public GameObject BuildSelectionMenu;
    public Text Title;
    public Button ButtonBuild;
    public Button Button2;
    public Button Button3;
    public bool SpaceshipClicked;
    public bool BuildButtonClicked;

    private void Awake()

    {
        SpaceshipClicked = false;
        BuildButtonClicked = false;
        ActionHUD.SetActive(false);
        BuildSelectionMenu.SetActive(false);

    }

    void Start()
    {
        StartCoroutine(Intro());
    }


    void Update()
    {
       
        
        if (SpaceshipClicked)
        {
            ActionHUD.SetActive(true);
        }

    }

    IEnumerator Intro()
    {
        yield return new WaitForSeconds(1f);
        Dialogue.SetActive(true);
        yield return new WaitForSeconds(4f);
        ObjectiveBar.SetActive(true);
        yield return new WaitForSeconds(2f);
        Dialogue.SetActive(false);
        yield return new WaitForSeconds(4f);
        ObjectiveBar.SetActive(false);
    }


}
