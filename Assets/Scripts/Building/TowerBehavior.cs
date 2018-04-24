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
        TowerData.BuildingType type = Data.Type;
        if (type == TowerData.BuildingType.Generator)
            Grow(Time.deltaTime);
        else if (type == TowerData.BuildingType.Firewall)
            throw new System.NotImplementedException();
    }


    #region Methods



    #endregion Methods


    #region Subfunctions

    private void InitializeData()
    {
        time = 0;
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
    }

    private void Grow(float deltatime)
    {
        if (Data.Population < GeneratorCap)
        {
            time += deltatime;

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
