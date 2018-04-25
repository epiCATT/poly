using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {


    #region Declaration

    // Static Data
    public GameObject SelectedTower;
    public GameObject TargetTower;

    // Dynamic Data


    // Subscripts
    private Tower_Hub Hub;

    #endregion


    // AWAKE
    void Awake() {
        //InitializeData();
    }

    // START
    void Start() {
        InitializeScripts();
    }

    // UPDATE
    void Update() {
    }

	#region Getters


    #endregion


	#region Event


    #endregion


	#region Methods

    public void Move100()
	{
		Hub.Move(TargetTower.transform, 1f);
	}
	public void Move75()
	{
		Hub.Move(TargetTower.transform, 0.75f);
	}
	public void Move50()
	{
		Hub.Move(TargetTower.transform, 0.5f);
	}
	public void Move25()
	{
        Hub.Move(TargetTower.transform, 0.25f);
	}	
	public void ConvertToLabo()
	{
		Hub.ChangeType(TowerData.BuildingType.Lab);
	}
	public void ConvertToGenerator()
	{
		Hub.ChangeType(TowerData.BuildingType.Generator);
	}

    public void ConvertToFirewall()
    {
        Hub.ChangeType(TowerData.BuildingType.Firewall);
    }

    public void LevelUP()
	{
		Hub.LevelUP();
	}
	

	#endregion


	#region Subfunctions
    
	//private void InitializeData() { }

	private void InitializeScripts() {
		Hub = SelectedTower.GetComponent<Tower_Hub>();
    }
    
    //private void InitializeRules() { }
    
    #endregion
}
