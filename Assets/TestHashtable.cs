using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class TestHashtable : MonoBehaviour {


    #region Declaration

    // Static Data
    public Text InText;
    public Text OutText;

    // Dynamic Data
    private Hashtable table;

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
        table.Add("txt", InText.text);
        OutText.text = (string)table["txt"];
    }

    // UPDATE
    void Update() {
    }


    #region Getters


    #endregion


    #region Event


    #endregion


    #region Methods


    #endregion


    #region Subfunctions
    
	private void InitializeData() {
        table = new Hashtable();
    }

	//private void InitializeScripts() { }
	//private void InitializeRules() { }
    
    #endregion

}
