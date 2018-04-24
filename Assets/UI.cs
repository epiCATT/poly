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
	private UnitSpawner Spawner;

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
    public void totale()
	{
		Spawner.Move(TargetTower.transform,100);
	}
	public void troisq()
	{
		Spawner.Move(TargetTower.transform,75);
	}
	public void moitier()
	{
		Spawner.Move(TargetTower.transform,50);
	}
	public void unq()
	{
        Spawner.Move(TargetTower.transform,25);
	}	
	public void Labo()
	{
		Hub.ChangeType(TowerData.BuildingType.Lab);
	}
	public void Generateru()
	{
		Hub.ChangeType(TowerData.BuildingType.Generator);
	}
	public void levelup()
	{
		Hub.LevelUP();
	}
	public void parefeu()
	{
        Hub.ChangeType(TowerData.BuildingType.Firewall);
	}

	#endregion


	#region Subfunctions
    
	//private void InitializeData() { }
	private void InitializeScripts() {
		Hub = SelectedTower.GetComponent<Tower_Hub>();
		Spawner = SelectedTower.GetComponent<UnitSpawner>();
     }
    //private void InitializeRules() { }
    
    #endregion
}
