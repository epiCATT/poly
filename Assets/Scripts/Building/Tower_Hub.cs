using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Hub : MonoBehaviour {


    #region Declaration

    // Static Data


    // Dynamic Data


    // Subscripts
    private TowerData data;
    //private TowerBehavior Beheavior;
    private TowerAppearance Appearance;
    //private TowerUI UI;
    private UnitSpawner Spawner;

    #endregion

    // AWAKE
    private void Awake()
    {
        //InitializeData();
    }


    // START
    void Start() {
        InitializeScripts();
    }


    // UPDATE
    void Update() {
    }

    #region Getters

    public TowerData Data { get { return data; } }

    #endregion


    #region Methods

    public void ChangeController(GameObject player)
    {
        bool isLab = (data.Type == TowerData.BuildingType.Lab);

        if (isLab)
            data.ControllerData.LooseLab();

        data.SetController(player);
        Appearance.ActualizeBody();

        // TO DO : Particle effect

        if (isLab)
            data.ControllerData.GetLab();
    }

    public void ChangeType(TowerData.BuildingType newType)
    {
        // TO DO : Unit Cost
        TowerData.BuildingType type = data.Type;

        if (newType != type)
        {
            if (type == TowerData.BuildingType.Lab)
                data.ControllerData.LooseLab();
            else if (newType == TowerData.BuildingType.Lab)
                data.ControllerData.GetLab();

            // TO DO : Animation & Particles

            data.SetType(newType);
        }
    }

    public void LevelUP()
    {
        // TO DO : Unit Cost

        int level = data.Level;

        if (level < 2)
        {
            // TO DO : Particle effect

            data.SetLevel(level + 1);
        }
    }

    public void Destroy()
    {

        if (data.Level != 0)
        {
            // TO DO : Particle effect

            data.SetLevel(0);
        }
    }

    public void Spawn(Transform target)
    {
        if (data.Population >= 1)
        {
            Spawner.Spawn(target, Data.Controller);
            data.AddUnits(-1, false);
        }
    }

    #endregion Methods


    #region Subfunctions
    
    private void InitializeScripts()
    {
        data = GetComponent<TowerData>();
        //Beheavior = GetComponent<TowerBehavior>();
        Appearance = GetComponentInChildren<TowerAppearance>();
        //UI = GetComponentInChildren<TowerUI>();
        Spawner = GetComponent<UnitSpawner>();
    }
    
    #endregion
}
