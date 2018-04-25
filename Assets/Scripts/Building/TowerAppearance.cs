using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAppearance : MonoBehaviour {

    #region Declaration

    // Static Data
    public Mesh LabModel;
    public Mesh GeneratorModel;
    public Mesh FirewallModel;
    public Material Material1;
    public Material Material2;
    public Material Material3;
    private Renderer mrenderer;
    private MeshFilter mfilter;

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
        UpdateModel();
        UpdateMaterial();
        UpdateColor();
    }

    #endregion


    #region Subfunctions

    private void InitializeData()
    {
        mrenderer = GetComponent<Renderer>();
        mfilter = GetComponent<MeshFilter>();
    }

    private void InitializeScripts()
    {
        Data = GetComponentInParent<TowerData>();
    }

    private void UpdateModel()
    {
        switch (Data.Type)
        {
            case TowerData.BuildingType.Generator:
                mfilter.mesh = GeneratorModel;
                break;
            case TowerData.BuildingType.Firewall:
                mfilter.mesh = FirewallModel;
                break;
            case TowerData.BuildingType.Lab:
                mfilter.mesh = LabModel;
                break;
            default:
                throw new System.ArgumentException("Type not Initialized.");
        }
    }

    private void UpdateMaterial()
    {
        switch (Data.Level)
        {
            case 0:
                mrenderer.material = Material1;
                break;
            case 1:
                mrenderer.material = Material2;
                break;
            case 2:
                mrenderer.material = Material3;
                break;
            default:
                throw new System.ArgumentException("Level out of bound.");
        }
    }

    private void UpdateColor()
    {
        controllerColor = Data.ControllerData.Color;

        // Change tower's color
        mrenderer.material.color = controllerColor;

        // Change Etiquette Color
        //UnitText.color = controllerColor;

        // Change Particle color
        //Particle.startColor = controllerColor;
    }

    #endregion
}
