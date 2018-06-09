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
    private PhotonView[] ViewList;
    private PlayerData[] PlayerDataList;

    // Subscripts


    #endregion


    // AWAKE
    void Awake() {
        InitializeData();
        if (PhotonNetwork.isMasterClient)
            photonView.RPC("AssignOwnership", PhotonTargets.AllViaServer, PhotonNetwork.playerList);
    }

    // START
    void Start() {
        //InitializeScripts();
        //InitializeRules();

        if (PhotonNetwork.isMasterClient)
            photonView.RPC("BeginGame", PhotonTargets.AllViaServer);
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


    #region Subfunctions

    private void InitializeData() {
        ViewList = Players.GetPhotonViewsInChildren();
        PlayerDataList = Players.GetComponentsInChildren<PlayerData>();
    }

	//private void InitializeScripts() { }
	//private void InitializeRules() { }

    [PunRPC]
    private void AssignOwnership(PhotonPlayer[] PlayerList)
    {
        for (int i = 0; i < PlayerList.Length; i++)
        {
            PhotonPlayer player = PlayerList[i];
            ViewList[i].TransferOwnership(player);
            PlayerData playerData = PlayerDataList[i];
            playerData.Color = decodeColor((float[])player.CustomProperties["Color"]);
            playerData.PlayerNumber = i + 1;
        }
    }

    [PunRPC]
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
