using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitData : MonoBehaviour {

    // Donnees statiques
    public Transform Target;
    public Transform Origin;
    public GameObject Controller;
    private PlayerData controllerData;
    private NavMeshAgent agent;


    // START
    void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        controllerData = Controller.GetComponent<PlayerData>();
        
        // Changing unit color
        GetComponent<Renderer>().material.color = controllerData.Color;
    }
	
	// UPDATE
	void Update ()
    {
        agent.SetDestination(Target.position);
	}

    #region Getter

    public PlayerData ControllerData { get { return controllerData; } }

    #endregion


    #region Event

    private void OnDestroy()
    {
        controllerData.AddUnits(-1);
    }

    #endregion
}
