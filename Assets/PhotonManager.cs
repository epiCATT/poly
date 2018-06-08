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
        {"Ile Triple", 3},
        {"Quad Canyon", 4}
    };

    [Header("Player Inputs")]

    public Text PlayerName;
    public Text RoomName;
    public Text MapName;

    public ColorPicker ColorPicker;

    [Header("Network Feedback")]

    public Text StateText;
    public Text ErrorText;

    public GameObject RoomInfoPrefab;
    public GameObject ContentOfScrollView;


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
        roomsList = PhotonNetwork.GetRoomList();
        ClearRoomList();
        CreateRoomList();
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
            if (!ExpectedPlayersOnMap.TryGetValue(MapName.text, out expectedPlayers))
                PrintError("Please choose a map.");
            else
            {
                // Creating options
                RoomOptions options = new RoomOptions();
                options.MaxPlayers = expectedPlayers;
                options.CustomRoomProperties = new Hashtable() { { "MapName", MapName.text } };

                // Generating Room
                if (PhotonNetwork.JoinOrCreateRoom(RoomName.text, options, PhotonNetwork.lobby))
                    MaskError();
                else
                    PrintError("Failed to join room : it may be full, try a different name.");
            }
        }
    }

    #endregion


    #region Subfunctions

    private void InitializeData() {
        PhotonNetwork.ConnectUsingSettings("0");
    }

	//private void InitializeScripts() { }
	//private void InitializeRules() { }

    private void UpdateState()
    {
        StateText.text = PhotonNetwork.connectionStateDetailed.ToString();
    }

    private void PrintError(string error)
    {
        if (!ErrorText.IsActive())
            ErrorText.enabled = true;
        ErrorText.text = error;
    }

    private void MaskError()
    {
        ErrorText.enabled = false;
    }

    private void CreateRoomList()
    {
        foreach (RoomInfo roomInfo in roomsList)
        {
            GameObject roomInfoObject = Instantiate(RoomInfoPrefab, ContentOfScrollView.transform);
            roomInfoObject.GetComponent<RoomInfoManager>().UpdateRoomInfo();
            roomInfoObjects.Add(roomInfoObject);
        }
    }

    private void ClearRoomList()
    {
        foreach (GameObject roomInfoObject in roomInfoObjects)
        {
            Destroy(roomInfoObject);
        }
        roomInfoObjects.Clear();
    }

    #endregion

}
