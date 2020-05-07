using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Activate_Menu : MonoBehaviour
{
    // Assign both of these in the editor.
    public GameObject Menu;

    public void Activate_Windows()
    {
        {
            Menu.SetActive(true);
        }
    }
}
