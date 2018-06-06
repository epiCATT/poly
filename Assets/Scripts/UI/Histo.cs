using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Histo : MonoBehaviour {


    #region Declaration

    // Static Data
    public Image[] ImagesJoueurs;
    public Image[] ImagesCombat;
    public Text[] TextJoueurs;
    public Text[] TextCombat;
    public GameObject Players;
    public float MaxWidth;

    

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
            proportion = playerDataList[j].NumberOfUnits / total * MaxWidth;

            ImagesJoueurs[j].rectTransform.sizeDelta = new Vector2(proportion, 30f);
        }
        
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
