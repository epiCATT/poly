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
    public void Select(bool main)
    {
<<<<<<< HEAD
        mrenderer.enabled = true;
=======
        if (main)
            renderer.material.color = Color.white;
        else
            renderer.material.color = Color.red;


        renderer.enabled = true;
>>>>>>> origin/Map-Opé
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
