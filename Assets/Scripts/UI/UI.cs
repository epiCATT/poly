using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour {


    #region Declaration

    // Static Data
    public PhotonView selectedView;
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
            //SelectedTower.Move(TargetTower.transform, 1f);
            Debug.Log("RPC Method called on " + selectedView.gameObject.name);
            selectedView.RPC("Move", PhotonTargets.AllViaServer, TargetTower.transform.position, 1f);
        }
	}

	public void Move75()
	{
        if (SelectedTower != null && TargetTower != null)
        {
            //SelectedTower.Move(TargetTower.transform, 0.75f);
            Debug.Log("RPC Method called on " + selectedView.gameObject.name);
            selectedView.RPC("Move", PhotonTargets.AllViaServer, TargetTower.transform.position, 0.75f);
        }
    }

	public void Move50()
	{
        if (SelectedTower != null && TargetTower != null)
        {
            //SelectedTower.Move(TargetTower.transform, 0.5f);
            Debug.Log("RPC Method called on " + selectedView.gameObject.name);
            selectedView.RPC("Move", PhotonTargets.AllViaServer, TargetTower.transform.position, 0.5f);
        }
    }

    public void Move25()
    {
        if (SelectedTower != null && TargetTower != null)
        {
            //SelectedTower.Move(TargetTower.transform, 0.25f);
            Debug.Log("RPC Method called on " + selectedView.gameObject.name);
            selectedView.RPC("Move", PhotonTargets.AllViaServer, TargetTower.transform.position, 0.25f);
        }
    }	

	public void ConvertToLabo()
	{
        if (SelectedTower != null)
        {
            //SelectedTower.ChangeType(TowerData.BuildingType.Lab);
            Debug.Log("RPC Method called on " + selectedView.gameObject.name);
            selectedView.RPC("ChangeType", PhotonTargets.AllViaServer, "Lab");
        }
    }
    public void ConvertToGenerator()
    {
        if (SelectedTower != null)
        {
            //SelectedTower.ChangeType(TowerData.BuildingType.Generator);
            Debug.Log("RPC Method called on " + selectedView.gameObject.name);
            selectedView.RPC("ChangeType", PhotonTargets.AllViaServer, "Generator");
        }
    }

    public void ConvertToFirewall()
    {
        if (SelectedTower != null)
        {
            //SelectedTower.ChangeType(TowerData.BuildingType.Firewall);
            Debug.Log("RPC Method called on " + selectedView.gameObject.name);
            selectedView.RPC("ChangeType", PhotonTargets.AllViaServer, "Firewall");
        }
    }

    public void LevelUP()
	{
        if (SelectedTower != null)
        {
            //SelectedTower.LevelUP();
            Debug.Log("RPC Method called on " + selectedView.gameObject.name);
            selectedView.RPC("LevelUP", PhotonTargets.AllViaServer);
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
