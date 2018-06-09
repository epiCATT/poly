using System.Collections;
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
        {"Triple Island", 3},
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
    public GameObject RoomsScrollContent;

    public GameObject PlayerInfoPrefab;
    public GameObject PlayerScrollContent;

    [Header("UI Management")]
    public Button CreateButton;
    public Button LeaveButton;
    public Text TitleText;
    public GameObject AvailableRoomsPanel;
    public GameObject AvailablePlayersPanel;


    // Dynamic Data

    private RoomInfo[] roomsList;
    private List<GameObject> roomInfoObjects;

    private PhotonPlayer[] playersList;
    private List<GameObject> playerInfoObjects;

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
        roomsList = PhotonNetwork.GetRoomList();
        ClearRoomList();
        CreateRoomList();
    }

    void OnJoinedLobby()
    {
        if (PhotonNetwork.playerName != "")
            GetPlayerInfos();
        SetInteractable(true);
    }

    void OnJoinedRoom()
    {
        SetInteractable(false);
        UpdatePlayerList();
    }

    void OnPhotonJoinRoomFailed()
    {
        PrintError("Couldn't join room : it may be already full.");
    }

    void OnPhotonPlayerConnected()
    {
        UpdatePlayerList();
    }

    void OnPhotonPlayerPropertiesChanged()
    {
        UpdatePlayerList();
        if (AllPlayersAreReady())
            LoadMap();
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
                PrintError("Please choose a valid map.");
            else
            {
                // Generating player

                PhotonNetwork.playerName = PlayerName.text;
                Color choosenColor = ColorPicker.Color;

                Hashtable PlayerProperties = new Hashtable() {
                    { "Color", new float[] { choosenColor.r,
                                             choosenColor.g,
                                             choosenColor.b } },
                    { "Ready", false } };

                PhotonNetwork.SetPlayerCustomProperties(PlayerProperties);

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

    public void ToggleReady()
    {
        Hashtable customProperties = PhotonNetwork.player.CustomProperties;
        customProperties["Ready"] = !(bool)customProperties["Ready"];
        PhotonNetwork.player.SetCustomProperties(customProperties);
    }

    #endregion


    #region Subfunctions

    private void InitializeData() {
        PhotonNetwork.ConnectUsingSettings("0");
        PhotonNetwork.automaticallySyncScene = true;
        roomInfoObjects = new List<GameObject>();
        playerInfoObjects = new List<GameObject>();
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
        ColorPicker.SetColor(decodeColor((float[])PhotonNetwork.player.CustomProperties["Color"]));
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
            GameObject roomInfoObject = Instantiate(RoomInfoPrefab, RoomsScrollContent.transform);
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

    private void CreatePlayerList()
    {
        foreach (PhotonPlayer player in playersList)
        {
            GameObject playerInfoObject = Instantiate(PlayerInfoPrefab, PlayerScrollContent.transform);
            PlayerInfoManager playerInfoManager = playerInfoObject.GetComponent<PlayerInfoManager>();
            playerInfoManager.thisPlayer = player;
            playerInfoManager.UpdatePlayerInfo();
            playerInfoObjects.Add(playerInfoObject);
        }
    }

    private void ClearPlayerList()
    {
        foreach (GameObject playerInfoObject in playerInfoObjects)
            Destroy(playerInfoObject);

        playerInfoObjects.Clear();
    }

    private void UpdatePlayerList()
    {
        playersList = PhotonNetwork.playerList;
        ClearPlayerList();
        CreatePlayerList();
    }

    private void SetInteractable(bool b)
    {
        PlayerName.interactable = b;
        RoomName.interactable = b;
        MapName.interactable = b;
        ColorPicker.SetInteractable(b);

        CreateButton.gameObject.SetActive(b);
        LeaveButton.gameObject.SetActive(!b);

        TitleText.text = b ? "Available Rooms" : "Available Players";
        AvailableRoomsPanel.SetActive(b);
        AvailablePlayersPanel.SetActive(!b);
    }

    private Color decodeColor(float[] color)
    {
        return new Color(color[0], color[1], color[2]);
    }

    private void LoadMap()
    {
        if (PhotonNetwork.isMasterClient)
        {
            string map = (string)PhotonNetwork.room.CustomProperties["Map"];
            PhotonNetwork.LoadLevelAsync(map);
        }
    }

    private bool AllPlayersAreReady()
    {
        Room room = PhotonNetwork.room;

        int expectedPlayers = room.MaxPlayers;

        if (room.PlayerCount != expectedPlayers)
            return false;

        int i = 0;
        while (i < expectedPlayers && (bool)playersList[i].CustomProperties["Ready"])
        {
            i++;
        }

        return i == expectedPlayers;
    }

    #endregion

}
