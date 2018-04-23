using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAppearance : MonoBehaviour {

    #region Declaration

    // Static Data


    // Dynamic Data
    private Color controllerColor;

    // Subscripts
    private TowerData Data;

    #endregion

    // START
    void Start () {
        InitializeScripts();
	}
	

	// UPDATE
	void Update () {
	}


    #region Methods

    public void ActualizeBody()
    {
        controllerColor = Data.ControllerData.Color;
        
        // Change tower's color
        GetComponent<Renderer>().material.color = controllerColor;

        // Change Etiquette Color
        //UnitText.color = controllerColor;

        // Change Particle color
        //Particle.startColor = controllerColor;

        // TO DO : Change tower appearrance

        // TO DO : Change tower's largeness
    }

    #endregion


    #region Subfunctions

    private void InitializeScripts()
    {
        Data = GetComponentInParent<TowerData>();
    }

    #endregion
}
