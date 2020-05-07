using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildFactory : MonoBehaviour
{
    #region
    public float rayLenght;
    private RaycastHit buildPosHit;
    [SerializeField]
    private Camera playerCamera;

    public bool BuildModeOn = false;
    private bool canBuild = false;

    [SerializeField]
    private LayerMask buildableSurfacesLayer;

    private Vector3 buildPos;

    private GameObject currentTemplateBuilding;

    [SerializeField]
    private GameObject buildingTemplatePrefab;
    [SerializeField]
    private GameObject buildingPrefab;
    #endregion

    // Toggle between build Mode and non-build mode
    public void BuildModeToggle()
    {
        BuildModeOn = true;
    }

    //Manage cancellation order
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            BuildModeOn = false;
        }
    //Here what Build Mode On is doing
        if (BuildModeOn)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //Calculate Green Ghost Mesh position 
            if (Physics.Raycast(ray, out buildPosHit, 300, buildableSurfacesLayer))
            {
                Vector3 point = buildPosHit.point;
                buildPos = new Vector3(Mathf.Round(point.x), Mathf.Round(point.y), Mathf.Round(point.z));
                canBuild = true;
            }
            // Destroy Ghost Mesh when Build mode is not activated 
            else
            {
                Destroy(currentTemplateBuilding.gameObject);
                canBuild = false;
            }
        }

        // Destroy Green Ghost Mesh when activated and switch to build mode off
        if (!BuildModeOn && currentTemplateBuilding != null)
        {
            Destroy(currentTemplateBuilding.gameObject);
            canBuild = false;
        }
        // Place a Green Ghost mesh building at the point at destination for contruction
        if (canBuild && currentTemplateBuilding == null)
        {
            currentTemplateBuilding = Instantiate(buildingTemplatePrefab, buildPos, Quaternion.identity);
        }

        // Update Green Ghost Mesh position
        if (canBuild && currentTemplateBuilding != null)
        {
            currentTemplateBuilding.transform.position = buildPos;

            if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
            }
        }
    }
    //Instantiate the new Factory at the prefered location
    private void PlaceBuilding()
    {
        GameObject newBuilding = Instantiate(buildingPrefab, buildPos, Quaternion.identity);
        BuildModeOn = false;
    }
}
