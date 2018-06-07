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


    #region Getters

    public float NumberOfUnits { get { return numberOfUnits; } }
    public float CombatPower { get { return combatPower; } }
    #endregion Getters

    // START
    void Start()
    {
        ActualizeCombatPower();
    }


    #region Methods

    public void AddUnits(float nOfUnit)
    {
        numberOfUnits += nOfUnit;
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
    }

    #endregion Methods
}
