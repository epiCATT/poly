using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnTower : MonoBehaviour {


    #region Declaration

    // Static Data


    // Dynamic Data
    private GameObject selectedTower;
    private Tower_Hub hub;
    private Camera cameraJoueur;

    // Subscripts
    private UI ui;


    #endregion


    // AWAKE
    void Awake() {
        InitializeData();
    }

    // START
    void Start() {
        InitializeScripts();
		//InitializeRules();
    }

    // UPDATE
    void Update()
    {
        Scan();
    }


    #region Methods

    

    #endregion


    #region Subfunctions

    private void InitializeData() {
        cameraJoueur = GetComponentInChildren<Camera>();
    }

    private void InitializeScripts() {
        ui = GetComponentInChildren<UI>();
    }

    //private void InitializeRules() { }

    private void Scan()
    {
        Ray ray = cameraJoueur.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Tower")
                {
                    selectedTower = hit.transform.parent.gameObject;
<<<<<<< HEAD:Assets/Scripts/Building/ClickOnTower.cs
                    ui.SelectedTower = selectedTower.GetComponent<Tower_Hub>();

                }
                else 
                {

=======
                    hub = selectedTower.GetComponent<Tower_Hub>();
                    
                    if (hub.GetData.Controller == gameObject)
                        ui.SelectedTower = hub;
                    else
                        ui.SelectedTower = null;
>>>>>>> CameraJoueur:Assets/Scripts/UI/ClickOnTower.cs
                }
                else                
                    ui.SelectedTower = null;
            }
            else
                ui.SelectedTower = null;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Tower")
                {
                    selectedTower = hit.transform.parent.gameObject;
                    ui.TargetTower = selectedTower;
                                    
                }
                else 
                {
   
                }

            }
        }
    }

    #endregion
}
