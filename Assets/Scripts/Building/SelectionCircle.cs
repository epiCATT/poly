using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCircle : MonoBehaviour {


    #region Declaration

    // Static Data


    // Dynamic Data
    private MeshRenderer renderer;


    // Subscripts


    #endregion


    // AWAKE
    void Awake() {
        InitializeData();
    }

    // START
    void Start() {
        //InitializeScripts();
		//InitializeRules();
    }

    // UPDATE
    void Update() {
    }

	#region Getters


    #endregion


	#region Event


    #endregion


	#region Methods
    public void Select()
    {
        renderer.enabled = true;
    }

    public void Deselect()
    {
        renderer.enabled = false;
    }

    #endregion


    #region Subfunctions

    private void InitializeData() {
        renderer = GetComponentInChildren<MeshRenderer>();
    }
    //private void InitializeScripts() { }
    //private void InitializeRules() { }

    #endregion
}
