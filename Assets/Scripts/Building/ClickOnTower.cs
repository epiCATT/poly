using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickOnTower : MonoBehaviour {


    #region Declaration

    // Static Data


    // Dynamic Data
    private GameObject selectedTower;

    // Subscripts
    private UI ui;

    #endregion


    // AWAKE
    void Awake() {
        //InitializeData();
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

    //private void InitializeData() { }

    private void InitializeScripts() {
        ui = GetComponent<UI>();
    }

    //private void InitializeRules() { }

    private void Scan()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "Tower")
                {
                    selectedTower = hit.transform.parent.gameObject;
                    ui.SelectedTower = selectedTower.GetComponent<Tower_Hub>();

                }
                else 
                {

                }
            }
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
