using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Histo : MonoBehaviour {


    #region Declaration

    // Static Data
    public Image imageJoueur1;
    public Image imageJoueur2;

    // Dynamic Data
    private RectTransform rt1;
    private RectTransform rt2;

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
    public void On()
    {
        imageJoueur1.color = Color.red;
    }

	#endregion


	#region Subfunctions
    
	private void InitializeData() {
        rt1 = imageJoueur1.GetComponent<RectTransform>();
        rt2 = imageJoueur2.GetComponent<RectTransform>();
     }
	//private void InitializeScripts() { }
    //private void InitializeRules() { }
    
    #endregion
}
