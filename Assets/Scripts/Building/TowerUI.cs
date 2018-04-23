using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUI : MonoBehaviour {

    #region Declaration

    // Static Data
    private Text PopulationText;

    // Dynamic Data


    // Subscripts
    private TowerData Data;

    #endregion

    // START
    void Start () {
        InitializeScripts();
        InitializeData();
	}
	

	// UPDATE
	void Update () {
	}


    #region Methods

    public void ActualizeUI()
    {
        PopulationText.text = (Mathf.RoundToInt(Data.Population)).ToString();
    }

    #endregion


    #region Subfunctions

    private void InitializeScripts()
    {
        Data = GetComponentInParent<TowerData>();
    }

    private void InitializeData()
    {
        PopulationText = GetComponent<Text>();
    }

    #endregion
}
