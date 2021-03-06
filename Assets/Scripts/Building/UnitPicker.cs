﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPicker : MonoBehaviour {

    #region Declaration

    // Static Data


    // Dynamic Data
    private Transform location;
    private GameObject towerController;
    private PlayerData towerControllerData;
    private UnitData unitData;
    private GameObject unitController;
    private PlayerData unitControllerData;

    // Subscripts
    private TowerData Data;
    private Tower_Hub Hub;
    private Harmonizer Harmonizer;
    private TowerParticles Particles;

    #endregion


    // AWAKE
    private void Awake()
    {
        
    }


    // START
    void Start() {
        InitializeScripts();
        InitializeLocation();
    }


    // UPDATE
    void Update() {
    }


    #region Events

    // Unit enter in collision with tower.
    void OnTriggerEnter(Collider unit)
    {
        ActualizeController();

        if (unit.gameObject.CompareTag("Unit"))
        {
            // Verify unit's player info
            unitData = unit.GetComponent<UnitData>();

            if (unitData.Origin != location)
            {
                unitController = unitData.Controller;

                if (unitController == towerController)
                {
                    Data.AddUnits(1);
                }
                else
                {
                    // Combat Process
                    unitControllerData = unitData.ControllerData;
                    float attackerCombatPower = unitControllerData.CombatPower / towerControllerData.CombatPower; // TO DO : Add Zone Power
                    float population = Data.Population;

                    // If defender wins
                    if (population >= attackerCombatPower)
                    {
                        Data.AddUnits(-attackerCombatPower);
                    }
                    // If attacker wins
                    else
                    {
                        float leftover = attackerCombatPower - population;
                        Data.AddUnits(-population);
                        Hub.ChangeController(unitController);
                        Data.AddUnits(leftover);
                    }

                    // Manage cooldown until harmonization
                    Harmonizer.StartCountdown();
                }
                Debug.Log("Appel des particules");
                Particles.PlayAttaque();
                Destroy(unit.gameObject);
            }

        }

    }

    #endregion Events


    #region Subfunctions

    private void InitializeScripts()
    {
        Data = GetComponentInParent<TowerData>();
        Hub = GetComponentInParent<Tower_Hub>();
        Harmonizer = GetComponentInParent<Harmonizer>();
        Particles = GetComponentInChildren<TowerParticles>();
    }

    private void InitializeLocation()
    {
        location = Data.Location;
    }

    private void ActualizeController()
    {
        towerController = Data.Controller;
        towerControllerData = Data.ControllerData;
    }

    #endregion
}
