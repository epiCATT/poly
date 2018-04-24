using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Hub : MonoBehaviour {


    #region Declaration

    // Static Data


    // Dynamic Data


    // Subscripts
    private _TowerRules Rules;
    private TowerData data;
    private TowerAppearance Appearance;
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
        InitializeRules();
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
            // TO DO : Animation & Particles

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
        Spawner.MoveOne(target);
    }

    #endregion Methods


    #region Subfunctions
    
    private void InitializeScripts()
    {
        Rules = GetComponentInParent<_TowerRules>();
        data = GetComponent<TowerData>();
        Appearance = GetComponentInChildren<TowerAppearance>();
        Spawner = GetComponent<UnitSpawner>();
    }

    private void InitializeRules()
    {

    }
    
    #endregion
}
