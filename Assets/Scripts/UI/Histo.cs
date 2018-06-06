using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Histo : MonoBehaviour {


    #region Declaration

    // Static Data
    /* 
    public Image imageJoueur1;
    public Image imageJoueur2;
    public Image imageJoueur3;
    public Image imageJoueur4; */
    public Image[] ImagesJoueurs;
    public Image[] ImagesCombat;
    public Text[] TextJoueurs;
    public Text[] TextCombat;


    public GameObject Players;

    

    // Dynamic Data

    private PlayerData[] playerDataList;
    int nplayer;
    float proportion;
    float total;

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
        enableImage();
        couleurImage();
    }

    // UPDATE
    void Update() {

        Actualize();
    }

	#region Getters


    #endregion


	#region Event


    #endregion


	#region Methods

    public void enableImage()
    {
        if(nplayer >=4)
        {
            (ImagesJoueurs[3]).gameObject.SetActive(true);
            (ImagesCombat[3]).gameObject.SetActive(true);
        }
        if(nplayer >=3)
        {
            (ImagesJoueurs[2]).gameObject.SetActive(true);
            (ImagesCombat[2]).gameObject.SetActive(true);
        }
        if(nplayer >=2)
        {
            (ImagesJoueurs[1]).gameObject.SetActive(true);
            (ImagesCombat[1]).gameObject.SetActive(true);
        }
        if(nplayer >=1)
        {
            (ImagesJoueurs[0]).gameObject.SetActive(true);
            (ImagesCombat[0]).gameObject.SetActive(true);
        }
    }

    public void couleurImage()
    {
        for (int i = 0; i < nplayer; i++)
        {
            ImagesJoueurs[i].color = playerDataList[i].Color;
            ImagesCombat[i].color = playerDataList[i].Color;

        }
    }

    public void Actualize()
    {
        total = 0;
        for (int i = 0; i < nplayer; i++)
        {
            total += playerDataList[i].NumberOfUnits;
        }

        for (int j = 0; j < nplayer; j++)
        {
            TextJoueurs[j].text =  playerDataList[j].NumberOfUnits.ToString();
            TextCombat[j].text =  playerDataList[j].CombatPower.ToString();
            proportion = playerDataList[j].NumberOfUnits / total * 500;

            ImagesJoueurs[j].rectTransform.sizeDelta = new Vector2(proportion,30f);
        }
        

        
        /*imageJoueur1.color = Color.red;
        int x = 150;
        imageJoueur1.rectTransform.sizeDelta = new Vector2(x,15);
        Text1.text = ""+ x;  

        imageJoueur2.color = Color.blue;
        int y = 20;
        imageJoueur2.rectTransform.sizeDelta = new Vector2(y,15);
        Text2.text = ""+ y; 

        imageJoueur3.color = Color.green;
        int w = 190;
        imageJoueur3.rectTransform.sizeDelta = new Vector2(w,15);
        Text3.text = ""+ w;  

        int z = 87;
        imageJoueur4.color = Color.yellow;
        imageJoueur4.rectTransform.sizeDelta = new Vector2(z,15);
        Text4.text = ""+ z; */

        

        
        
    }

	#endregion


	#region Subfunctions
    
	private void InitializeData() {
        playerDataList = Players.GetComponentsInChildren<PlayerData>();
        nplayer = playerDataList.Length; 
     }
	//private void InitializeScripts() { }
    //private void InitializeRules() { }
    
    #endregion
}
