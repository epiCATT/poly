using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackWithEscape : MonoBehaviour {


    #region Declaration

    // Static Data
    public string BackScene;

    // Dynamic Data


    // Subscripts


    #endregion


    // AWAKE
    void Awake() {
        //InitializeData();
    }

    // START
    void Start() {
        //InitializeScripts();
	    //InitializeRules();
    }

    // UPDATE
    void Update() {
        if (Input.GetKey(KeyCode.Escape))
        {
            PhotonNetwork.Disconnect();
            SceneManager.LoadScene(BackScene);
        }   
    }


    #region Getters


    #endregion


    #region Event


    #endregion


    #region Methods


    #endregion


    #region Subfunctions
    
	//private void InitializeData() { }
	//private void InitializeScripts() { }
	//private void InitializeRules() { }
    
    #endregion

}
