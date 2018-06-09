using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkGameManager : Photon.MonoBehaviour {


    #region Declaration

    // Static Data
    public GameObject Players;
    public GameObject Towers;
    public GameObject MainCanvas;

    // Dynamic Data
    private PhotonPlayer[] PlayerList;
    private Room ActualRoom;
    private PhotonView[] ViewList;
    private PlayerData[] PlayerDataList;

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

    private void OnLevelWasLoaded(int level)
    {
        InitializeData();
        AssignOwnership();
        BeginGame();
    }

    #endregion


    #region Methods



    #endregion


    #region Subfunctions

    private void InitializeData() {
        ActualRoom = PhotonNetwork.room;
        PlayerList = PhotonNetwork.playerList;
        ViewList = Players.GetPhotonViewsInChildren();
        PlayerDataList = Players.GetComponentsInChildren<PlayerData>();
    }

	//private void InitializeScripts() { }
	//private void InitializeRules() { }

    private void AssignOwnership()
    {
        for (int i = 0; i < ActualRoom.PlayerCount; i++)
        {
            PhotonPlayer player = PlayerList[i];
            ViewList[i].TransferOwnership(player);
            PlayerData playerData = PlayerDataList[i];
            playerData.Color = decodeColor((float[])player.CustomProperties["Color"]);
            playerData.PlayerNumber = i + 1;
        }
    }

    private void BeginGame()
    {
        Players.SetActive(true);
        Towers.SetActive(true);
        MainCanvas.SetActive(true);
    }

    private Color decodeColor(float[] color)
    {
        return new Color(color[0], color[1], color[2]);
    }

    #endregion

}
