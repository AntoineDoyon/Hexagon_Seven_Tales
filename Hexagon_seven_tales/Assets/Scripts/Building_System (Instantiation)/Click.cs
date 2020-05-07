using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
#region
    [SerializeField]
    private LayerMask clickableLayer;
    //private bool IsClicked = false;
    #endregion

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit rayHit;

            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out rayHit, Mathf.Infinity, clickableLayer))
            {
                rayHit.collider.GetComponent<ClickOn>().ClickMe();
            }
           
        }
    }
}
