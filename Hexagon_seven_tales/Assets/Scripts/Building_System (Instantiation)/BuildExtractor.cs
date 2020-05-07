using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildExtractor : MonoBehaviour
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
    public LayerMask NonBuildableSurfacesLayer;
    public LayerMask UnManagedLayer;

    private Vector3 buildPos_G;
    private Vector3 buildPos_R;
    private Vector3 buildPos_N;
    private GameObject currentGreenGhostMeshBuilding;
    private GameObject currentRedGhostMeshBuilding;

    [SerializeField]
    public GameObject buildingGreenGhostMeshPrefab;
    public GameObject buildingRedGhostMeshPrefab;
    [SerializeField]
    public GameObject buildingPrefab;
    #endregion

    // Toggle between build Mode and non-build mode
    public void BuildModeToggle()
    {
        BuildModeOn = true;
    }

    private void Update()
    {
        //Manage cancellation order
        if (Input.GetMouseButtonDown(1))  
        {
            BuildModeOn = false;
        }

        //Here what Build Mode On is doing
        if (BuildModeOn)
        {          
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            //Calculate Green Ghost Mesh position ;
            if (Physics.Raycast(ray, out buildPosHit, 300, buildableSurfacesLayer))
            {
                Vector3 pointG = buildPosHit.point;
                buildPos_G = new Vector3(Mathf.Round(pointG.x), Mathf.Round(pointG.y), Mathf.Round(pointG.z));
                canBuild = true;
               
            }

            //Calculate Red Ghost Mesh position and do error handling
            if (Physics.Raycast(ray, out buildPosHit, 300, NonBuildableSurfacesLayer))
             {
                Vector3 pointR = buildPosHit.point;
                buildPos_R = new Vector3(Mathf.Round(pointR.x), Mathf.Round(pointR.y), Mathf.Round(pointR.z));
                canBuild = false;
                
             }

            //Unmanaged Layer
            if (Physics.Raycast(ray, out buildPosHit, 300, UnManagedLayer))
            {
        
                Vector3 pointN = buildPosHit.point;
                buildPos_N = new Vector3(Mathf.Round(pointN.x), Mathf.Round(pointN.y), Mathf.Round(pointN.z));
                canBuild = false;
            }

        }

        // Destroy Green Ghost Mesh when activated and switch to build mode off
        if (!BuildModeOn && currentGreenGhostMeshBuilding != null)
        {
            Destroy(currentGreenGhostMeshBuilding.gameObject);
            canBuild = false;
        }
        // Destroy Red Ghost Mesh when activated and switch to build mode off
        if (!BuildModeOn && currentRedGhostMeshBuilding != null)
        {
            Destroy(currentRedGhostMeshBuilding.gameObject);
            canBuild = false;
        }

        // Place a Green Ghost mesh building at the point at destination for construction
        if (canBuild && currentGreenGhostMeshBuilding == null )
        {
            if(currentRedGhostMeshBuilding!= null)
            {
                Destroy(currentRedGhostMeshBuilding.gameObject);
            }
            currentGreenGhostMeshBuilding = Instantiate(buildingGreenGhostMeshPrefab, buildPos_G, Quaternion.identity);
        }

        // Place a Red Ghost Mesh building at the point at destination to indicate if this is a wrong spot
        if (!canBuild && currentRedGhostMeshBuilding == null && BuildModeOn)
        {
            if (currentGreenGhostMeshBuilding != null)
            {
                Destroy(currentGreenGhostMeshBuilding.gameObject);
            }
            currentRedGhostMeshBuilding = Instantiate(buildingRedGhostMeshPrefab, buildPos_R, Quaternion.identity);
        }

        // update Green Ghost Mesh position
        if (canBuild && currentGreenGhostMeshBuilding != null )
        {
            currentGreenGhostMeshBuilding.transform.position = buildPos_G;

            if (Input.GetMouseButtonDown(0))
            {
                PlaceBuilding();
            }
        }

        // Update Red Ghost Mesh position
        if (!canBuild && currentRedGhostMeshBuilding != null)
        {
            currentRedGhostMeshBuilding.transform.position = buildPos_R;
        }

    }
    //Instantiate the new Extractor at the prefered location 
    private void PlaceBuilding()
    {
        GameObject newBuilding = Instantiate(buildingPrefab, buildPos_G, Quaternion.identity);
        Destroy(currentGreenGhostMeshBuilding.gameObject);
        Destroy(currentRedGhostMeshBuilding.gameObject);
        BuildModeOn = false;
    }
} 