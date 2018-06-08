﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class RoomInfoManager : MonoBehaviour {


    #region Declaration

    // Static Data
    public RoomInfo thisRoomInfo;

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
        RoomText.text = thisRoomInfo.Name;
        PlayerText.text = thisRoomInfo.PlayerCount + "/" + thisRoomInfo.MaxPlayers;
        Debug.Log(thisRoomInfo.CustomProperties["MapName"]);
        MapText.text = (string)thisRoomInfo.CustomProperties["MapName"];
    }

    #endregion


    #region Subfunctions
    
	//private void InitializeData() { }
	//private void InitializeScripts() { }
	//private void InitializeRules() { }
    
    #endregion

}
