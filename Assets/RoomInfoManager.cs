using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class RoomInfoManager : MonoBehaviour {


    #region Declaration

    // Static Data
    public RoomInfo RoomInfo;

    public Text RoomText;
    public Text MapText;
    public Text PlayerText;

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

    public void UpdateRoomInfo()
    {
        RoomText.text = RoomInfo.Name;
        PlayerText.text = RoomInfo.PlayerCount + "/" + RoomInfo.MaxPlayers;

        object MapName;
        if (RoomInfo.CustomProperties.TryGetValue("MapName", out MapName))
            MapText.text = MapName.ToString();
    }

    #endregion


    #region Subfunctions
    
	//private void InitializeData() { }
	//private void InitializeScripts() { }
	//private void InitializeRules() { }
    
    #endregion

}
