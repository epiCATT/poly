using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harmonizer : MonoBehaviour {

    #region Declaration

    // Static Data


    // Dynamic Data
    private bool onCountdown;
    private float timeTillAttacked;

    // Subscripts
    private TowerData Data;

    #endregion

    // AWAKE
    void Awake()
    {
        InitializeData();
    }


    // START
    void Start()
    {
        InitializeScripts();
    }


    // UPDATE
    void Update()
    {
        if (onCountdown)
            ManageCountdown(Time.deltaTime);
    }


    #region Methods

    public void StartCountdown()
    {
        onCountdown = true;
        timeTillAttacked = 0;
    }

    public void Harmonize()
    {
        float population = Data.Population;
        float rounded = Mathf.RoundToInt(population) - population;

        Data.AddUnits(rounded);
    }

    #endregion


    #region Subfunctions

    private void InitializeData()
    {
        onCountdown = false;
        timeTillAttacked = 0;
    }

    private void InitializeScripts()
    {
        Data = GetComponent<TowerData>();
    }

    private void ManageCountdown(float deltaTime)
    {
        timeTillAttacked += deltaTime;
        if (timeTillAttacked >= 5)
        {
            onCountdown = false;
            timeTillAttacked = 0;
            Harmonize();
        }
    }

    #endregion
}
