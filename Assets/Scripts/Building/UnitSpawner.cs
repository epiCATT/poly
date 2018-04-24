using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {


    #region Declaration

    // Static Data


    // Dynamic Data
    private GameObject UnitPrefab;
    private float TimeBetweenSpawn;
    private Transform spawnLocation;
    private bool isMoving;

    private GameObject initialController;
    private int unitSpawned;
    private int unitToSpawn;
    private float elapsedTime;
    private Transform selectedTarget;

    // Subscripts
    private _TowerRules Rules;
    private TowerData Data;

    #endregion


    // AWAKE
    void Awake() {
        InitializeData();
    }

    // START
    void Start() {
        InitializeScripts();
        InitializeRules();
    }

    // UPDATE
    void Update() {
        if (isMoving)
            sequentialMove(Time.deltaTime);
    }


    #region Getters


    #endregion


    #region Event


    #endregion


    #region Methods

    public void MoveOne(Transform target)
    {
        if (Data.Population >= 1)
        {
            Spawn(target, Data.Controller);
            Data.AddUnits(-1, false);
        }
    }

    public void Move(Transform target, float proportion)
    {
        if (!isMoving)
        {
            isMoving = true;
            unitSpawned = 0;
            unitToSpawn = (int)(Data.Population * proportion);
            initialController = Data.Controller;
            selectedTarget = target;
        }
    }

    #endregion


    #region Subfunctions

    private void InitializeData() {
        spawnLocation = GetComponent<Transform>();
        isMoving = false;
        unitSpawned = 0;
        unitToSpawn = 0;
        elapsedTime = 0;
    }

    private void InitializeScripts() {
        Rules = GetComponentInParent<_TowerRules>();
        Data = GetComponent<TowerData>();
    }
    private void InitializeRules() {
        UnitPrefab = Rules.UnitPrefab;
        TimeBetweenSpawn = Rules.TimeBetweenSpawn;
    }

    private void Spawn(Transform target, GameObject unitController)
    {
        GameObject unit = Instantiate(UnitPrefab, spawnLocation);
        UnitData unitData = unit.GetComponent<UnitData>();
        unitData.Controller = unitController;
        unitData.Target = target;
        unitData.Origin = spawnLocation;
    }

    private void sequentialMove(float deltaTime)
    {
        elapsedTime += deltaTime;

        if (unitSpawned >= unitToSpawn || Data.Controller != initialController || Data.Population < 1)
        {
            isMoving = false;
            elapsedTime = TimeBetweenSpawn;
            unitToSpawn = 0;
            unitSpawned = 0;
        }
        else
        {
            while (elapsedTime >= TimeBetweenSpawn && unitSpawned < unitToSpawn)
            {
                Spawn(selectedTarget, initialController);
                Data.AddUnits(-1, false);
                elapsedTime -= TimeBetweenSpawn;
            }
        }
    }

    #endregion

}
