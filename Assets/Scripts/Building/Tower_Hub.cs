﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_Hub : MonoBehaviour {


    #region Declaration

    // Static Data


    // Dynamic Data


    // Subscripts
    private TowerData Data;
    private TowerBehavior TBehavior;
    private TowerAppearance Appearance;
    private UnitSpawner Spawner;
    private SelectionCircle Circle;

    #endregion


    // AWAKE
    private void Awake() {
        //InitializeData();
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
        Appearance.ActualizeBody();

        // TO DO : Particle effect

        if (isLab)
            Data.ControllerData.GetLab();
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

    public void Select()
    {
        Circle.Select();
    }

    public void Deselect()
    {
        Circle.Deselect();
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
    }

    //private void InitializeRules() { }
    
    #endregion

}
