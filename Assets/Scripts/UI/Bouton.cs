using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bouton : MonoBehaviour {

    public GameObject GeneratorTEST;
    public GameObject FirewallTEST;
    public GameObject LaboTEST;

    public GameObject Tower1;
    public GameObject Tower2;
    public GameObject Tower3;
    public GameObject Tower4;
    public GameObject Tower2BIS;
    public GameObject Tower1BIS;
    private int count = 0; 
    public Text MainText;
    public GameObject UpgradeButton;
    public GameObject button25;
    public GameObject button50;
    public GameObject button75;
    public GameObject button100;
    public GameObject Tower5WithLess;
    public GameObject Tower6WithMore;
    public GameObject ToLabButton;
    public GameObject Panel;
    public Text finaltext;
    public GameObject Panel2;
    public GameObject board;

    #region Declaration

    // Static Data


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
    }

	#region Getters


    #endregion


	#region Event


    #endregion


	#region Methods


	#endregion

    public void tedt()
    {
        if (count == 0)
        {
            MainText.text = "Meet the Generator";
            GeneratorTEST.SetActive(true);
            LaboTEST.SetActive(false);
        }
        if (count == 1)
        {
            MainText.text = "Meet the Firewall";
            FirewallTEST.SetActive(true);
            GeneratorTEST.SetActive(false);
        }
        if (count == 2)
        {
            MainText.text = "Your team's color is red, therefore your buildings are red.";
            FirewallTEST.SetActive(false);
            Tower1.SetActive(true);
            
        }
        if (count == 3)
        {
            MainText.text = "Left click on the building of your color, then right click on the other one.";
            Tower1.SetActive(false);
            Tower2.SetActive(true);
            Tower3.SetActive(true);
            button100.SetActive(true);
            button75.SetActive(true);
            button50.SetActive(true);
            button25.SetActive(true);


        }
        if (count == 4)
        {
            
            MainText.text = "Left click on the two batiments, then on either 25, 50, 75 or 100%";
            Tower2.SetActive(false);
            Tower2BIS.SetActive(true);
            Tower3.SetActive(false);
            Tower4.SetActive(true);
            
            
        }
        if (count == 5)
        {
            MainText.text = "Redo an attack, this one shouldn't go too well.";
            Tower2BIS.SetActive(false);
            Tower5WithLess.SetActive(true);
            Tower6WithMore.SetActive(true);
            Tower4.SetActive(false);
            Tower2.SetActive(false);
        }
        if (count == 6)
        {
            MainText.text = "Left click on the building and then 'Upgrade'.";
            Tower1.SetActive(true);
            Tower5WithLess.SetActive(false);
            Tower6WithMore.SetActive(false);
            button100.SetActive(false);
            button75.SetActive(false);
            button50.SetActive(false);
            button25.SetActive(false);
            UpgradeButton.SetActive(true);
        }
        if (count == 7)
        {
            Tower1.SetActive(false);
            Tower1BIS.SetActive(true);
            MainText.text = "Change the buildig's type by simply clicking 'To Lab'.";
            UpgradeButton.SetActive(false);
            
            ToLabButton.SetActive(true);
        }
        if (count == 8)
        {
            
            finaltext.text = "You are now good to go !";
            Tower1BIS.SetActive(false);
            Panel2.SetActive(true);            
            ToLabButton.SetActive(false);
            MainText.text = null;
            Panel.SetActive(false);
            board.SetActive(false);
            
            
        }

        count++;
    }

	#region Subfunctions
    
	//private void InitializeData() { }
	//private void InitializeScripts() { }
    //private void InitializeRules() { }
    
    #endregion
}
