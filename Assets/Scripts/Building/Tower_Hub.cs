using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Hub : Photon.MonoBehaviour {


    #region Declaration

    // Static Data
    public Tower_Hub Instance;

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
        InitializeData();
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

    [PunRPC]
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

    [PunRPC]
    public void ChangeType(string newType)
    {
        switch (newType)
        {
            case "Generator":
                TBehavior.ChangeType(TowerData.BuildingType.Generator);
                break;
            case "Lab":
                TBehavior.ChangeType(TowerData.BuildingType.Lab);
                break;
            case "Firewall":
                TBehavior.ChangeType(TowerData.BuildingType.Firewall);
                break;
            default:
                throw new System.ArgumentException("Not a buildingtype");
        }
        
    }

    [PunRPC]
    public void LevelUP()
    {
        TBehavior.LevelUP();
    }

    public void Spawn(Vector3 target)
    {
        Spawner.MoveOne(target);
    }

    [PunRPC]
    public void Move(Vector3 target, float proportion)
    {
        Spawner.Move(target, proportion);
    }

    public void Select(Color color)
    {
        Circle.Select(color);
        if (Data.Type == TowerData.BuildingType.Firewall)
            FWTrigger.Select();
    }

    public void Deselect()
    {
        Circle.Deselect();
        FWTrigger.Deselect();
    }

    #endregion Methods


    #region Subfunctions

    private void InitializeData() {
        Instance = this;
    }

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
