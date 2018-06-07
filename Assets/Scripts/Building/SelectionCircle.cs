using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionCircle : MonoBehaviour {


    #region Declaration

    // Static Data


    // Dynamic Data
    private MeshRenderer mrenderer;


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
    public void Select(Color color)
    {
        mrenderer.enabled = true;
        mrenderer.material.color = color;
    }

    public void Deselect()
    {
        mrenderer.enabled = false;
    }

    #endregion


    #region Subfunctions

    private void InitializeData() {
        mrenderer = GetComponentInChildren<MeshRenderer>();
    }

    //private void InitializeScripts() { }
    //private void InitializeRules() { }

    #endregion
}
