using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PlayerInfoManager : MonoBehaviour {


    #region Declaration

    // Static Data
    public PhotonPlayer thisPlayer;

    public Image ColorPanel;
    public Text PlayerNameText;
    public Toggle ReadyCheck;

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

    public void UpdatePlayerInfo()
    {
        Hashtable playerProperties = thisPlayer.CustomProperties;
        PlayerNameText.text = thisPlayer.NickName;
        ColorPanel.color = decodeColor( (float[])playerProperties["Color"] );
        ReadyCheck.isOn = (bool)playerProperties["Ready"];
    }

    #endregion


    #region Subfunctions

    //private void InitializeData() { }
    //private void InitializeScripts() { }
    //private void InitializeRules() { }

    private Color decodeColor(float[] color)
    {
        return new Color(color[0], color[1], color[2]);
    }

    #endregion

}
