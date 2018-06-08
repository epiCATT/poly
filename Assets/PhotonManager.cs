﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using Hashtable = ExitGames.Client.Photon.Hashtable;

public class PhotonManager : MonoBehaviour {


    #region Declaration

    // Static Data

    public Dictionary<string, byte> ExpectedPlayersOnMap = new Dictionary<string, byte>()
    {
        {"Chess Board", 2},
        {"Ile Triple", 3},
        {"Quad Canyon", 4}
    };

    [Header("Player Inputs")]

    public InputField PlayerName;
    public InputField RoomName;
    public Dropdown MapName;

    public ColorPicker ColorPicker;

    [Header("Network Feedback")]

    public Text StateText;
    public Text ErrorText;

    public GameObject RoomInfoPrefab;
    public GameObject ContentOfScrollView;

    [Header("UI Management")]
    public Button CreateButton;
    public Button LeaveButton;
    public GameObject AvailableRoomsPanel;


    // Dynamic Data
    private RoomInfo[] roomsList;
    private List<GameObject> roomInfoObjects;

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
        UpdateState();
    }


    #region Getters


    #endregion


    #region Event

    void OnReceivedRoomListUpdate()
    {
        Debug.Log("Received List Update");
        roomsList = PhotonNetwork.GetRoomList();
        ClearRoomList();
        CreateRoomList();
    }

    void OnJoinedLobby()
    {
        if (PhotonNetwork.playerName != "")
            GetPlayerInfos();
    }

    void OnJoinedRoom()
    {
        SetInteractable(false);
    }

    void OnPhotonJoinFailed()
    {
        PrintError("Couldn't join room : may be full, try another one.");
    }

    #endregion


    #region Methods

    public void CreateOrJoinRoom()
    {
        if (PlayerName.text == string.Empty)
            PrintError("Please enter a nickname.");
        else if (RoomName.text == string.Empty)
            PrintError("Please enter a room name.");
        else if (ColorPicker.Color == Color.black || ColorPicker.Color == Color.white)
            PrintError("Please choose a color that is not pure white or pure black");
        else
        {
            byte expectedPlayers;
            if (!ExpectedPlayersOnMap.TryGetValue(MapName.captionText.text, out expectedPlayers))
                PrintError("Please choose a map.");
            else
            {
                // Generating player
                PhotonNetwork.playerName = PlayerName.text;
                //Hashtable PlayerProperties = new Hashtable() { { "Color", ColorPicker.Color }, { "Ready", false } };
                //PhotonNetwork.SetPlayerCustomProperties(PlayerProperties);

                // Creating options
                RoomOptions options = new RoomOptions();
                options.MaxPlayers = expectedPlayers;
                Hashtable RoomProperties = new Hashtable() { { "Map", MapName.captionText.text } };
                options.CustomRoomProperties = RoomProperties;
                options.CustomRoomPropertiesForLobby = new string[] { "Map" };

                // Generating Room
                if (PhotonNetwork.JoinOrCreateRoom(RoomName.text, options, PhotonNetwork.lobby))
                    ClearError();
            }
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        SetInteractable(true);
    }

    #endregion


    #region Subfunctions

    private void InitializeData() {
        PhotonNetwork.ConnectUsingSettings("0");
        roomInfoObjects = new List<GameObject>();
    }

	//private void InitializeScripts() { }
	//private void InitializeRules() { }

    private void UpdateState()
    {
        StateText.text = PhotonNetwork.connectionStateDetailed.ToString();
    }

    private void GetPlayerInfos()
    {
        PlayerName.text = PhotonNetwork.playerName;
        ColorPicker.SetColor((Color)PhotonNetwork.player.CustomProperties["Color"]);
    }

    private void PrintError(string error)
    {
        if (!ErrorText.IsActive())
            ErrorText.enabled = true;
        ErrorText.text = error;
    }

    private void ClearError()
    {
        ErrorText.enabled = false;
    }

    private void CreateRoomList()
    {
        foreach (RoomInfo roomInfo in roomsList)
        {
            GameObject roomInfoObject = Instantiate(RoomInfoPrefab, ContentOfScrollView.transform);
            RoomInfoManager roomInfoManager = roomInfoObject.GetComponent<RoomInfoManager>();
            roomInfoManager.thisRoomInfo = roomInfo;
            roomInfoManager.RoomName = RoomName;
            roomInfoManager.MapName = MapName;
            roomInfoManager.UpdateRoomInfo();
            roomInfoObjects.Add(roomInfoObject);
        }
    }

    private void ClearRoomList()
    {
        foreach (GameObject roomInfoObject in roomInfoObjects)
            Destroy(roomInfoObject);

        roomInfoObjects.Clear();
    }

    private void SetInteractable(bool b)
    {
        PlayerName.interactable = b;
        RoomName.interactable = b;
        MapName.interactable = b;
        ColorPicker.SetInteractable(b);
        CreateButton.gameObject.SetActive(b);
        AvailableRoomsPanel.SetActive(b);
        LeaveButton.gameObject.SetActive(!b);
    }

    #endregion

}