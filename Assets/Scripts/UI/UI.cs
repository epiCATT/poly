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
        if (SelectedTower != null && TargetTower != null)
        {
            SelectedTower.Move(TargetTower.transform, 1f);
            SelectedTower.Select(Color.white);
        }
	}

	public void Move75()
	{
        if (SelectedTower != null && TargetTower != null)
        {
            SelectedTower.Move(TargetTower.transform, 0.75f);
            SelectedTower.Select(Color.white);
        }
    }

	public void Move50()
	{
        if (SelectedTower != null && TargetTower != null)
        {
            SelectedTower.Move(TargetTower.transform, 0.5f);
            SelectedTower.Select(Color.white);
        }
    }

    public void Move25()
    {
        if (SelectedTower != null && TargetTower != null)
        {
            SelectedTower.Move(TargetTower.transform, 0.25f);
            SelectedTower.Select(Color.white);
        }
    }	

	public void ConvertToLabo()
	{
        if (SelectedTower != null)
        {
            SelectedTower.ChangeType(TowerData.BuildingType.Lab);
            SelectedTower.Select(Color.white);
        }
    }
    public void ConvertToGenerator()
    {
        if (SelectedTower != null)
        { 
            SelectedTower.ChangeType(TowerData.BuildingType.Generator);
            SelectedTower.Select(Color.white);
        }
    }

    public void ConvertToFirewall()
    {
        if (SelectedTower != null)
        {
            SelectedTower.ChangeType(TowerData.BuildingType.Firewall);
            SelectedTower.Select(Color.white);
        }
    }

    public void LevelUP()
	{
        if (SelectedTower != null)
        {
            SelectedTower.LevelUP();
            SelectedTower.Select(Color.white);
        }
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
