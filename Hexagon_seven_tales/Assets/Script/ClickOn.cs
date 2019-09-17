using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material green;
    public GameObject HUD;

    private MeshRenderer myRend;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<MeshRenderer>();
        HUD  = GameObject.Find("HUD");
    }

    public void ClickMe()
    {
        myRend.material = green;
        HUD.GetComponent<UI_pannel_missions>().SpaceshipClicked = true;
    }
}
