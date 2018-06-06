using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBehavior : MonoBehaviour {

    #region Declaration

    // Static Data
    private float BaseGenerationTime;
    private float GeneratorCap;
    private float FireWallRange;
    private float FireWallCD;
    private float TinkerTime;
    private float ConvertionCost;
    private float[] UpgradeCost;
    private GameObject BulletPrefab;

    // Dynamic Data
    private Transform spawnLocation;
    private bool isOperational;
    private int newLevel;
    private TowerData.BuildingType newType;
    private float time;
    private float timeNeeded;
    

    // Subscripts
    private _TowerRules Rules;
    private TowerData Data;
    private TowerParticles Particles;
    private FirewallTrigger FWTrigger;

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

    public void UpdateRange()
    {
        FWTrigger.UpdateRange(FireWallRange * (1f + (float)Data.Level / 3f));
    }

    #endregion Methods


    #region Subfunctions

    private void InitializeData()
    {
        time = 0;
        isOperational = true;
        spawnLocation = GetComponent<Transform>();
    }

    private void InitializeScripts()
    {
        Rules = GetComponentInParent<_TowerRules>();
        Data = GetComponent<TowerData>();
        Particles = GetComponentInChildren<TowerParticles>();
        FWTrigger = GetComponentInChildren<FirewallTrigger>();
    }

    private void InitializeRules()
    {
        BaseGenerationTime = Rules.BaseGenerationTime;
        GeneratorCap = Rules.GeneratorCap;
        FireWallRange = Rules.FirewallRange;
        FireWallCD = 1 / Rules.FirewallRateOfFire;
        TinkerTime = Rules.TinkerTime;
        ConvertionCost = Rules.ConvertionCost;
        UpgradeCost = new float[2];
        UpgradeCost[0] = Rules.UpgradeCost1;
        UpgradeCost[1] = Rules.UpgradeCost2;
        BulletPrefab = Rules.BulletPrefab;
    }

    private void DoYourJob()
    {
        TowerData.BuildingType type = Data.Type;
        if (type == TowerData.BuildingType.Generator)
            Grow();
        else if (type == TowerData.BuildingType.Firewall)
            Aim();
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

                Particles.PlayTinker();
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

                Particles.PlayTinker();
            }
        }
    }

    private void Tinker()
    {
        time += Time.deltaTime;

        if (time >= TinkerTime)
        {
            Particles.StopTinker();
            Particles.PlayFinished();
            Data.SetLevel(newLevel);
            Data.SetType(newType);
            isOperational = true;
            time = 0;

            if (newType == TowerData.BuildingType.Lab)
                Data.ControllerData.GetLab();

            else if (newType == TowerData.BuildingType.Firewall)
                UpdateRange();
        }
    }

    private void Grow()
    {
        if (Data.Population < GeneratorCap)
        {
            time += Time.deltaTime;
            timeNeeded = BaseGenerationTime / (Data.Level+1);

            while (time >= timeNeeded)
            {
                Data.AddUnits(1);
                time -= timeNeeded;
            }
        }
        else
            time = 0;
    }

    private void Aim()
    {
        time += Time.deltaTime;
        timeNeeded = FireWallCD / (Data.Level + 1);

        while (time > timeNeeded)
        {
            Transform target = FWTrigger.GetTarget();

            if (target != null)
            {
                Shoot(target);
                time -= timeNeeded;
            }
            else
                time = timeNeeded;
        }
    }

    private void Shoot(Transform target)
    {
        GameObject bullet = Instantiate(BulletPrefab, spawnLocation);
        BulletData bulletData = bullet.GetComponent<BulletData>();
        bulletData.Target = target;
        bulletData.ControllerData = Data.ControllerData;
    }
    
    #endregion
}
