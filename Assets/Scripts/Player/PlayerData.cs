using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerData : MonoBehaviour {

    // Donnees statiques
    public int PlayerNumber;
    public Color Color;
    

    // Donnees dynamiques
    private float numberOfUnits;
    private int possessedLabs;
    private float combatPower;

    // Elements UI
    public Text UnitText;
    public Text CbPowText;

    // Donnees d'initialization
    public int StartingUnits;
    public int StartingLabs;

    #region Getters

    public float NumberOfUnits { get { return numberOfUnits; } }
    public float CombatPower { get { return combatPower; } }
    #endregion Getters

    // START
    void Start()
    {
        //InitAllInfos();
        //numberOfUnits = StartingUnits;
        //possessedLabs = StartingLabs;
        ActualizeCombatPower();
    }


    #region Methods

    public void InitAllInfos()
    {
        // TO DO
        throw new System.NotImplementedException();
    }

    public void AddUnits(float nOfUnit)
    {
        numberOfUnits += nOfUnit;
        ActualizeUI();
    }

    public void GetLab()
    {
        possessedLabs += 1;
        ActualizeCombatPower();
    }

    public void LooseLab()
    {
        possessedLabs -= 1;
        ActualizeCombatPower();
    }

    private void ActualizeCombatPower()
    {
        if (possessedLabs >= 3)
            combatPower = 2.5f;
        else
            combatPower = 1f + 0.5f * possessedLabs;

        ActualizeUI();
    }

    private void ActualizeUI()
    {
        UnitText.text = "Number of units : " + (Mathf.RoundToInt(numberOfUnits)).ToString();
        CbPowText.text = "Combat Power : " + combatPower.ToString();
    }

    #endregion Methods
}
