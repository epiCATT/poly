using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirewallTrigger : MonoBehaviour {


    #region Declaration

    // Static Data
    private MeshRenderer mrenderer;
    private Transform Sphere;

    // Dynamic Data
    private List<Transform> Targets;
    private GameObject towerController;
    private UnitData unitData;

    // Subscripts
    private TowerData Data;


    #endregion


    // AWAKE
    void Awake() {
        InitializeData();
    }

    // START
    void Start() {
        InitializeScripts();
	    //InitializeRules();
        ActualizeController();
    }

    // UPDATE
    void Update() {

    }


    #region Getters


    #endregion


    #region Event

    void OnTriggerEnter(Collider unit)
    {
        if (unit.gameObject.CompareTag("Unit"))
        {
            unitData = unit.GetComponent<UnitData>();

            if (unitData.Controller != towerController)
                Targets.Add(unit.transform);
        }
    }

    private void OnTriggerExit(Collider unit)
    {
        if (unit.gameObject.CompareTag("Unit"))
            Targets.Remove(unit.transform);
    }

    #endregion


    #region Methods

    public void ActualizeController()
    {
        towerController = Data.Controller;

        int i = 0;
        while (i < Targets.Count)
        {
            unitData = Targets[i].GetComponent<UnitData>();

            if (unitData.Controller == towerController)
                Targets.RemoveAt(i);
            else
                i++;
        }
    }

    public Transform GetTarget()
    {
        Transform unit = null;

        while (unit == null && Targets.Count != 0)
        {
            unit = Targets[0];
            Targets.RemoveAt(0);
        }

        return unit;
    }

    public void Select()
    {
        mrenderer.enabled = true;
    }

    public void Deselect()
    {
        mrenderer.enabled = false;
    }

    public void UpdateRange(float size)
    {
        Sphere.localScale = new Vector3(size, size, size);
    }

    #endregion


    #region Subfunctions

    private void InitializeData() {
        Targets = new List<Transform>();
        mrenderer = GetComponent<MeshRenderer>();
        Sphere = GetComponent<Transform>();
    }

    private void InitializeScripts() {
        Data = GetComponentInParent<TowerData>();
    }

    //private void InitializeRules() { }

    #endregion

}
