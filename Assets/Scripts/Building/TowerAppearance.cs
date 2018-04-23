using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAppearance : MonoBehaviour {

    #region Declaration

    // Static Data
    private Renderer renderer;

    // Dynamic Data
    private Color controllerColor;

    // Subscripts
    private TowerData Data;

    #endregion

    // AWAKE
    void Awake()
    {
        InitializeData();
    }

    // START
    void Start () {
        InitializeScripts();
        ActualizeBody();
	}
	

	// UPDATE
	void Update () {
	}


    #region Methods

    public void ActualizeBody()
    {
        controllerColor = Data.ControllerData.Color;
        
        // Change tower's color
        renderer.material.color = controllerColor;

        // Change Etiquette Color
        //UnitText.color = controllerColor;

        // Change Particle color
        //Particle.startColor = controllerColor;

        // TO DO : Change tower appearrance

        // TO DO : Change tower's largeness
    }

    #endregion


    #region Subfunctions

    private void InitializeData()
    {
        renderer = GetComponent<Renderer>();
    }

    private void InitializeScripts()
    {
        Data = GetComponentInParent<TowerData>();
    }

    #endregion
}
