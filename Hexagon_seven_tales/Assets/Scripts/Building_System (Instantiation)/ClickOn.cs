using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOn : MonoBehaviour
{
    [SerializeField]
    private Material red;
    [SerializeField]
    private Material green;
    //public GameObject HUD;
    private bool IsGreen = true;
    private MeshRenderer myRend;
    public Material Original;

    // Start is called before the first frame update
    void Start()
    {
        myRend = GetComponent<MeshRenderer>();
    }

    public void ClickMe()
    {
        if (IsGreen)
        {         
            //Debug.Log(IsGreen);
           // myRend.material = green;
            //HUD.GetComponent<UI_pannel_missions>().SpaceshipClicked = true;
           // IsGreen = !IsGreen;
        }
        else
        {
            //myRend.material = Original;
            //IsGreen = true;
        }
    }
}
