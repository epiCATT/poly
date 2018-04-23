using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour {

    #region Declaration

    // Static Data
    public GameObject UnitPrefab;

    // Dynamic Data
    private Transform spawnLocation;

    // Subscripts


    #endregion


    // START
    private void Start()
    {
        spawnLocation = GetComponent<Transform>().parent;
    }

    /// <summary>
    /// Spawn a clone of the unit prefab heading to target location.
    /// </summary>
    /// <param name="target">Place the unit heads to.</param>
    /// <param name="unitController">Player controlling the unit.</param>
    public void Spawn(Transform target, GameObject unitController)
    {
        GameObject unit = Instantiate(UnitPrefab, spawnLocation);
        UnitData unitData = unit.GetComponent<UnitData>();
        unitData.Controller = unitController;
        unitData.Target = target;
        unitData.Origin = spawnLocation;
    }
}
