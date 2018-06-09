using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestController : MonoBehaviour {

    // Donnees statiques
    public GameObject Player1;
    public GameObject Player2;
    public GameObject Tower1;
    public GameObject Tower2;

    private PlayerData playerData1;
    private PlayerData playerData2;
    private Tower_Hub towerHub1;
    private Tower_Hub towerHub2;
    private TowerData towerData1;
    private TowerData towerData2;

    // START
    void Start()
    {
        playerData1 = Player1.GetComponent<PlayerData>();
        playerData2 = Player2.GetComponent<PlayerData>();
        towerHub1 = Tower1.GetComponent<Tower_Hub>();
        towerHub2 = Tower2.GetComponent<Tower_Hub>();
        towerData1 = towerHub1.GetData;
        towerData2 = towerHub2.GetData;
    }

    // Update is called once per frame
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (towerData1.Controller == Player1)
            {
                playerData1.AddUnits(-towerData1.Population);
                towerHub1.ChangeController(Player2);
                playerData2.AddUnits(towerData1.Population);
            }
            else
            {
                playerData2.AddUnits(-towerData1.Population);
                towerHub1.ChangeController(Player1);
                playerData1.AddUnits(towerData1.Population);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (towerData2.Controller == Player1)
            {
                playerData1.AddUnits(-towerData2.Population);
                towerHub2.ChangeController(Player2);
                playerData2.AddUnits(towerData2.Population);
            }
            else
            {
                playerData2.AddUnits(-towerData2.Population);
                towerHub2.ChangeController(Player1);
                playerData1.AddUnits(towerData2.Population);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            towerHub1.Spawn(Tower2.transform.position);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            towerHub2.Spawn(Tower1.transform.position);
        }
    }
}
