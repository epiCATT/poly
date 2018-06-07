using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {


    #region Declaration

    // Static Data
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


    #endregion


    #region Methods

    public void Eliminate(GameObject player)
    {
        activePlayers.Remove(player);
        eliminatedPlayers.Add(player);
        if (activePlayers.Count == 1)
            Congratule();
    }

    public void Congratule()
    {
        EndGamePanel.GetComponentInChildren<Text>().text = "YOU WIN !";
        EndGamePanel.SetActive(true);
    }

    public void Shame()
    {
        EndGamePanel.SetActive(true);
    }

    #endregion


    #region Subfunctions
    
	private void InitializeData() {
        activePlayers = new List<GameObject>();
        eliminatedPlayers = new List<GameObject>();
        foreach (var player in GetComponentsInChildren<PlayerData>())
            activePlayers.Add(player.gameObject);
    }

	//private void InitializeScripts() { }
	//private void InitializeRules() { }
    
    #endregion

}
