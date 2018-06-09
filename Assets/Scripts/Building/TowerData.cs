using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerData : MonoBehaviour {

    #region Declaration

    // Static Data
    public TowerData Instance;

    public GameObject InitialController;
    public int StartingPopulation;
    public BuildingType StartingType;
    public int StartingLevel;

    // Dynamic Data
    private GameObject controller;
    private PlayerData controllerData;
    private float population;
    private BuildingType type;
    private int level;
    private Transform location;

    // Subscripts
    private TowerAppearance Appearance;
    private TowerUI UI;
    private TowerBehavior TBehavior;

    #endregion


    public enum BuildingType
    {
        Generator,
        Firewall,
        Lab
    }

    // AWAKE
    private void Awake()
    {
        InitializeData();
    }


    // START
    void Start() {
        InitializeScripts();
        InitializeInfo();
    }
	

	// UPDATE
	void Update () {
	}


    #region Getters

    public GameObject Controller { get { return controller; } }
    public PlayerData ControllerData { get { return controllerData; } }
    public float Population { get { return population; } }
    public BuildingType Type { get { return type; } }
    public int Level { get { return level; } }
    public Transform Location { get { return location; } }

    #endregion Getters


    #region Methods


    public void ActualizeController()
    {
        controllerData = Controller.GetComponent<PlayerData>();
        gameObject.GetPhotonView().TransferOwnership(controller.GetPhotonView().owner);
        // TO DO : Change Etiquette visibility.
    }

    public void AddUnits(float nOfUnit, bool affectPlayer = true)
    {
        population += nOfUnit;
        UI.ActualizeUI();

        if (affectPlayer)
            controllerData.AddUnits(nOfUnit);
    }

    public void SetController(GameObject player)
    {
        controller = player;
        ActualizeController();
    }

    public void SetType(BuildingType newType)
    {
        type = newType;
        Appearance.ActualizeBody();
    }

    public void SetLevel(int newLevel)
    {
        level = newLevel;
        Appearance.ActualizeBody();
    }

    #endregion


    #region Subfunctions

    private void InitializeData()
    {
        Instance = this;
        controller = InitialController;
        ActualizeController();
        population = StartingPopulation;
        type = StartingType;
        level = StartingLevel;
        location = GetComponent<Transform>();
    }

    private void InitializeScripts()
    {
        Appearance = GetComponentInChildren<TowerAppearance>();
        UI = GetComponentInChildren<TowerUI>();
        TBehavior = GetComponentInChildren<TowerBehavior>();
    }

    private void InitializeInfo()
    {
        controllerData.AddUnits(population);
        if (StartingType == BuildingType.Lab)
            controllerData.GetLab();
        else if (StartingType == BuildingType.Firewall)
            TBehavior.UpdateRange();
    }

    #endregion
}
