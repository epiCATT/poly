using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {


    #region Declaration

    // Static Data
    public Tower_Hub SelectedTower;
    public GameObject TargetTower;

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
        SelectedTower.Select(true);
	}
	public void Move75()
	{
		SelectedTower.Move(TargetTower.transform, 0.75f);
        SelectedTower.Select(true);
    }
	public void Move50()
	{
		SelectedTower.Move(TargetTower.transform, 0.5f);
        SelectedTower.Select(true);
    }
	public void Move25()
	{
        SelectedTower.Move(TargetTower.transform, 0.25f);
        SelectedTower.Select(true);
    }	
	public void ConvertToLabo()
	{
		SelectedTower.ChangeType(TowerData.BuildingType.Lab);
        SelectedTower.Select(true);
    }
	public void ConvertToGenerator()
	{
		SelectedTower.ChangeType(TowerData.BuildingType.Generator);
        SelectedTower.Select(true);
    }

    public void ConvertToFirewall()
    {
        SelectedTower.ChangeType(TowerData.BuildingType.Firewall);
        SelectedTower.Select(true);
    }

    public void LevelUP()
	{
		SelectedTower.LevelUP();
        SelectedTower.Select(true);
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
