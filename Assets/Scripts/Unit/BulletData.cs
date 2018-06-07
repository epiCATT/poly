using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BulletData : MonoBehaviour {


    #region Declaration

    // Static Data
    public Transform Target;
    public PlayerData ControllerData;

    // Dynamic Data
    private NavMeshAgent agent;

    // Subscripts


    #endregion


    // AWAKE
    void Awake() {
        
    }

    // START
    void Start() {
        InitializeScripts();
        //InitializeRules();
        InitializeData();
    }

    // UPDATE
    void Update() {
        if (Target != null)
            agent.SetDestination(Target.position);
        else
            Destroy(this.gameObject);
    }


    #region Getters


    #endregion


    #region Event

    private void OnTriggerEnter(Collider unit)
    {
        if (unit.transform == Target)
        {
            Destroy(unit.gameObject);
            Destroy(this.gameObject);
        }
    }

    #endregion


    #region Methods


    #endregion


    #region Subfunctions

    private void InitializeData() {
        GetComponentInChildren<Renderer>().material.color = ControllerData.Color;
        GetComponent<Transform>().Translate(new Vector3(0f, 5f, 0f));
    }

	private void InitializeScripts() {
        agent = GetComponent<NavMeshAgent>();
    }

	//private void InitializeRules() { }
    
    #endregion

}
