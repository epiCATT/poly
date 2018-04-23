using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour {

    #region Declaration

    // Static Data
    private Text populationText;

    // Dynamic Data


    // Subscripts
    private TowerData Data;

    #endregion


    // AWAKE
    void Awake()
    {
        InitializeData();
    }


    // START
    void Start () {
        InitializeScripts();
        ActualizeUI();
	}
	

	// UPDATE
	void Update () {
	}


    #region Methods

    public void ActualizeUI()
    {
        int population = Mathf.RoundToInt(Data.Population);
        populationText.text = population.ToString();
    }

    #endregion


    #region Subfunctions

    private void InitializeData()
    {
        populationText = GetComponentInChildren<Text>();
    }

    private void InitializeScripts()
    {
        Data = GetComponentInParent<TowerData>();
    }

    #endregion
}
