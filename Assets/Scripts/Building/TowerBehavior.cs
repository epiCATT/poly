using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBehavior : MonoBehaviour {

    #region Declaration

    // Static Data

    // Dynamic Data
    private float BaseGenerationTime;
    private float GeneratorCap;
    private float TinkerTime;
    private float ConvertionCost;
    private float[] UpgradeCost;
    private bool isOperational;
    private int newLevel;
    private TowerData.BuildingType newType;
    private float time;

    // Subscripts
    private _TowerRules Rules;
    private TowerData Data;

    #endregion


    // AWAKE
    void Awake() {
        InitializeData();
    }


    // START
    void Start () {
        InitializeScripts();
        InitializeRules();
    }
	

	// UPDATE
	void Update () {
        if (isOperational)
            DoYourJob();
        else
            Tinker();
    }


    #region Methods



    #endregion Methods


    #region Subfunctions

    private void InitializeData()
    {
        time = 0;
        isOperational = true;
    }

    private void InitializeScripts()
    {
        Rules = GetComponentInParent<_TowerRules>();
        Data = GetComponent<TowerData>();
    }

    private void InitializeRules()
    {
        BaseGenerationTime = Rules.BaseGenerationTime;
        GeneratorCap = Rules.GeneratorCap;
        TinkerTime = Rules.TinkerTime;
        ConvertionCost = Rules.ConvertionCost;
        UpgradeCost = new float[2];
        UpgradeCost[0] = Rules.UpgradeCost1;
        UpgradeCost[1] = Rules.UpgradeCost2;
    }

    private void DoYourJob()
    {
        TowerData.BuildingType type = Data.Type;
        if (type == TowerData.BuildingType.Generator)
            Grow();
        else if (type == TowerData.BuildingType.Firewall)
            throw new System.NotImplementedException();
    }

    public void LevelUP()
    {
        if (isOperational)
        {
            int currentLevel = Data.Level;
            float cost = UpgradeCost[currentLevel];

            if (currentLevel < 2 && Data.Population >= cost)
            {
                Data.AddUnits(-cost);
                isOperational = false;
                newLevel = currentLevel + 1;
                newType = Data.Type;

                // TO DO : Start Particles
            }
        }
    }

    public void ChangeType(TowerData.BuildingType newType)
    {
        if (isOperational)
        {
            TowerData.BuildingType currentType = Data.Type;

            if (newType != currentType && Data.Population >= ConvertionCost)
            {
                if (currentType == TowerData.BuildingType.Lab)
                    Data.ControllerData.LooseLab();

                Data.AddUnits(-ConvertionCost);
                isOperational = false;
                newLevel = 0;
                this.newType = newType;

                // TO DO : Start Particles
            }
        }
    }

    private void Tinker()
    {
        time += Time.deltaTime;

        if (time >= TinkerTime)
        {
            Data.SetLevel(newLevel);
            Data.SetType(newType);
            isOperational = true;
            time = 0;

            if (newType == TowerData.BuildingType.Lab)
                Data.ControllerData.GetLab();

            // TO DO :  Stop Particles & Play Animation
        }
    }

    private void Grow()
    {
        if (Data.Population < GeneratorCap)
        {
            time += Time.deltaTime;
            float timeNeeded = BaseGenerationTime / (Data.Level+1);

            while (time >= timeNeeded)
            {
                Data.AddUnits(1);
                time -= timeNeeded;
            }
        }
        else
            time = 0;
    }

    #endregion
}
