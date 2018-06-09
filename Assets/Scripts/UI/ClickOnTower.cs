﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class ClickOnTower : Photon.MonoBehaviour
{


    #region Declaration

    // Static Data
    public PhotonView View;
    public GameObject CanvasJoueur;
    public GameObject CanvasPause;

    // Dynamic Data
    private GameObject selectedTower;
    private GameObject targetTower;
    private PhotonView selectedView;
    private Tower_Hub hubMain;
    private Tower_Hub hubTarget;
    private Camera cameraJoueur;

    // Subscripts
    private UI ui;
    private PlayerData playerData;



    #endregion


    // AWAKE
    void Awake()
    {
        InitializeData();
    }

    // START
    void Start()
    {
        InitializeScripts();
        //InitializeRules();
        InitializeLayer();
    }

    // UPDATE
    void Update()
    {
        Scan();
    }


    #region Methods



    #endregion


    #region Subfunctions

    private void InitializeData()
    {
        if (!View.isMine)
        {
            gameObject.SetActive(false);
            CanvasJoueur.SetActive(false);
            CanvasPause.SetActive(false);
        }
        cameraJoueur = GetComponent<Camera>();
    }

    private void InitializeScripts()
    {
        ui = GetComponent<UI>();
        playerData = GetComponentInParent<PlayerData>();
    }

    //private void InitializeRules() { }

    private void Scan()
    {
        Ray ray = cameraJoueur.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        RaycastHit hit2;

        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(ray, out hit))
            {

                if (hit.transform.tag == "Tower")
                {
                    SelectMain(false);

                    selectedTower = hit.transform.parent.gameObject;
                    selectedView = selectedTower.GetPhotonView();
                    hubMain = selectedTower.GetComponent<Tower_Hub>();

                    if (hubMain.GetData.ControllerData == playerData)
                        SelectMain(true);
                    else
                        SelectMain(false);
                }
                else if (hit.transform.gameObject.layer != 5)
                    SelectMain(false);
            }
            else
                SelectMain(false);
        }

        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (Physics.Raycast(ray, out hit2))
            {
                if (hit2.transform.tag == "Tower")
                {
                    SelectTarget(false);

                    targetTower = hit2.transform.parent.gameObject;
                    hubTarget = targetTower.GetComponent<Tower_Hub>();

                    SelectTarget(true);
                }
                else if (hit2.transform.gameObject.layer != 5)
                    SelectMain(false);
            }
            else
                SelectTarget(false);
        }
    }

    private void InitializeLayer()
    {
        int playerNumber = playerData.PlayerNumber;
        cameraJoueur.cullingMask |= (1 << (7 + playerNumber));
    }

    private void SelectMain(bool succes)
    {
        if (succes)
        {
            ui.SelectedTower = hubMain;
            ui.selectedView = selectedView;
            hubMain.Select(Color.white);
        }
        else if (hubMain != null)
        {
            hubMain.Deselect();
            selectedTower = null;
            hubMain = null;
            ui.SelectedTower = null;
            ui.selectedView = null;
        }
    }

    private void SelectTarget(bool succes)
    {
        if (succes)
        {
            ui.TargetTower = targetTower;
            hubTarget.Select(playerData.Color);
        }
        else if (hubTarget != null)
        {
            hubTarget.Deselect();
            targetTower = null;
            hubTarget = null;
            ui.TargetTower = null;
        }
    }

    #endregion
}