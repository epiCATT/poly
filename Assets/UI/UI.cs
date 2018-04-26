using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {


    #region Declaration

    // Static Data
    public Tower_Hub SelectedTower;
    public GameObject TargetTower;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;
    public GameObject button4;
    public GameObject button5;
    public GameObject button6;
    public GameObject button7;
    public GameObject button8;

    // Dynamic Data


    // Subscripts


    #endregion


    // AWAKE
    void Awake() {
        //InitializeData();
    }

    // START
    void Start() {
    
    }

    // UPDATE
    void Update() {
    }


	#region Methods

    public void Move100()
	{
		SelectedTower.Move(TargetTower.transform, 1f);
	}
	public void Move75()
	{
		SelectedTower.Move(TargetTower.transform, 0.75f);
	}
	public void Move50()
	{
		SelectedTower.Move(TargetTower.transform, 0.5f);
	}
	public void Move25()
	{
        SelectedTower.Move(TargetTower.transform, 0.25f);
	}	
	public void ConvertToLabo()
	{
		SelectedTower.ChangeType(TowerData.BuildingType.Lab);
	}
	public void ConvertToGenerator()
	{
		SelectedTower.ChangeType(TowerData.BuildingType.Generator);
	}

    public void ConvertToFirewall()
    {
        SelectedTower.ChangeType(TowerData.BuildingType.Firewall);
    }

    public void LevelUP()
	{
		SelectedTower.LevelUP();
	}

    public void exitbn()
    {
        Application.Quit();
    }




    #endregion


    #region Subfunctions

    //private void InitializeData() { }
    //private void InitializeScripts() { };
    //private void InitializeRules() { }
    
    #endregion
}
