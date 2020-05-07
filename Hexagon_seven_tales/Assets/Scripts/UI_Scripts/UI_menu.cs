using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI_menu : MonoBehaviour
{
 
    public void PlayTheGame()
    {
        SceneManager.LoadScene("Hexagon_7Tales_Intro");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
