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

    public void SetColor(Color color)
    {
        Color = color;
        Scrollbars[0].value = color.r;
        Scrollbars[1].value = color.g;
        Scrollbars[2].value = color.b;
    }

    public void SetInteractable(bool b)
    {
        Scrollbars[0].interactable = b;
        Scrollbars[1].interactable = b;
        Scrollbars[2].interactable = b;
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
