using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnTower : MonoBehaviour {


    #region Declaration

    // Static Data


    // Dynamic Data
    private GameObject selectedTower;
    private GameObject targetTower;
    private Tower_Hub hubMain;
    private Tower_Hub hubTarget;
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
        RaycastHit hit2;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Tower")
                {
                    if (hubMain != null)
                        hubMain.Deselect();

                    selectedTower = hit.transform.parent.gameObject;
                    hubMain = selectedTower.GetComponent<Tower_Hub>();

                    if (hubMain.GetData.Controller == gameObject)
                    {
                        ui.SelectedTower = hubMain;
                        hubMain.Select(true);
                    }
                }
            }
            else
                hubMain.Deselect();
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out hit2))
            {
                if (hit2.transform.tag == "Tower")
                {
                    if (hubTarget != null)
                        hubTarget.Deselect();

                    targetTower = hit2.transform.parent.gameObject;
                    hubTarget = targetTower.GetComponent<Tower_Hub>();
                    ui.TargetTower = targetTower;
                    hubTarget.Select(false);
                }
            }
            else
            { 
                hubTarget.Deselect();
                ui.TargetTower = null;
            }
    }
    }

    #endregion
}
