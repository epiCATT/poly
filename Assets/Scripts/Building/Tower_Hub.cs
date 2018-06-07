using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Hub : MonoBehaviour {


    #region Declaration

    // Static Data


    // Dynamic Data


    // Subscripts
    private TowerData Data;
    private TowerBehavior TBehavior;
    private TowerUI UI;
    private TowerAppearance Appearance;
    private UnitSpawner Spawner;
    private SelectionCircle Circle;
    private TowerParticles Particles;
    private FirewallTrigger FWTrigger;

    #endregion


    // AWAKE
    private void Awake() {
        // InitializeData();
    }

    // START
    void Start() {
        InitializeScripts();
        //InitializeRules();
    }

    // UPDATE
    void Update() {
    }


    #region Getters

    public TowerData GetData { get { return Data; } }

    #endregion


    #region Methods

    public void ChangeController(GameObject player)
    {
        bool isLab = (Data.Type == TowerData.BuildingType.Lab);

        if (isLab)
            Data.ControllerData.LooseLab();

        Data.SetController(player);

        Particles.PlaySwitchjoueur();

        Appearance.ActualizeBody();

        UI.ActualizeLayer();

        if (isLab)
            Data.ControllerData.GetLab();

        if (Data.Type == TowerData.BuildingType.Firewall)
            FWTrigger.ActualizeController();
    }

    public void ChangeType(TowerData.BuildingType newType)
    {
        TBehavior.ChangeType(newType);
    }

    public void LevelUP()
    {
        TBehavior.LevelUP();
    }

    public void Spawn(Transform target)
    {
        Spawner.MoveOne(target);
    }

    public void Move(Transform target, float proportion)
    {
        Spawner.Move(target, proportion);
    }

    public void Select(bool main)
    {
        Circle.Select(main);
        if (main && Data.Type == TowerData.BuildingType.Firewall)
            FWTrigger.Select();
    }

    public void Deselect()
    {
        Circle.Deselect();
        FWTrigger.Deselect();
    }

    #endregion Methods


    #region Subfunctions

    //private void InitializeData() { }

    private void InitializeScripts()
    {
        Data = GetComponent<TowerData>();
        TBehavior = GetComponent<TowerBehavior>();
        Appearance = GetComponentInChildren<TowerAppearance>();
        Spawner = GetComponent<UnitSpawner>();
        Circle = GetComponentInChildren<SelectionCircle>();
        Particles = GetComponentInChildren<TowerParticles>();
        FWTrigger = GetComponentInChildren<FirewallTrigger>();
        UI = GetComponentInChildren<TowerUI>();
    }

    //private void InitializeRules() { }
    
    #endregion

}
