using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour {


    #region Declaration

    // Static Data
    public Color Color;
    public Image Preview;

    // Dynamic Data
    private Scrollbar[] Scrollbars;

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
        UpdateColor();
    }

    // UPDATE
    void Update() {
    }


    #region Getters


    #endregion


    #region Event


    #endregion


    #region Methods

    public void UpdateColor()
    {
        Color = new Color(Scrollbars[0].value, Scrollbars[1].value, Scrollbars[2].value);
        Preview.color = Color;
    }

    #endregion


    #region Subfunctions
    
	private void InitializeData() {
        Scrollbars = GetComponentsInChildren<Scrollbar>();
    }

	//private void InitializeScripts() { }
	//private void InitializeRules() { }
    
    #endregion

}
