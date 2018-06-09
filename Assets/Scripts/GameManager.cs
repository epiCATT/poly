using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Photon.MonoBehaviour {


    #region Declaration

    // Static Data
    public GameObject Players;
    public GameObject EndGamePanel;

    // Dynamic Data
    private List<GameObject> activePlayers;
    private List<GameObject> eliminatedPlayers;

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
    }


    #region Getters


    #endregion


    #region Event
    
    void OnPlayerDisconnected(NetworkPlayer Player)
    {
        List<GameObject> playersToDelete = new List<GameObject>();

        foreach (var player in activePlayers)
        {
            if (!player.GetPhotonView().isOwnerActive)
                playersToDelete.Add(player);
        }

        foreach (var player in playersToDelete)
            Eliminate(player);
    }

    #endregion


    #region Methods

    public void Eliminate(GameObject player)
    {
        activePlayers.Remove(player);
        eliminatedPlayers.Add(player);
        photonView.RPC("Shame", player.GetPhotonView().owner);

        if (activePlayers.Count == 1)
            photonView.RPC("Congratule", activePlayers[0].GetPhotonView().owner);
    }

    [PunRPC]
    public void Congratule()
    {
        EndGamePanel.GetComponentInChildren<Text>().text = "YOU WIN !";
        EndGamePanel.SetActive(true);
    }

    [PunRPC]
    public void Shame()
    {
        EndGamePanel.SetActive(true);
    }

    public void LeaveGame()
    {
        PhotonNetwork.LeaveRoom();
        SceneManager.LoadScene("LobbyMultijoueur");
    }

    #endregion


    #region Subfunctions
    
	private void InitializeData() {
        activePlayers = new List<GameObject>();
        eliminatedPlayers = new List<GameObject>();
        foreach (var player in Players.GetComponentsInChildren<PlayerData>())
            activePlayers.Add(player.gameObject);
    }

	//private void InitializeScripts() { }
	//private void InitializeRules() { }
    
    #endregion

}
