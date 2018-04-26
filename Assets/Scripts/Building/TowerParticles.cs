using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerParticles : MonoBehaviour {


    #region Declaration

    // Static Data

    public ParticleSystem Finished;
    public ParticleSystem Tinker;
    public ParticleSystem Attaque;
    public ParticleSystem Switchjoueur;



    // Dynamic Data


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


    #endregion


	#region Methods


    public void PlayFinished()
    {
        Finished.Emit(50);
    }

    public void StopFinished()
    {
        Finished.Stop();
    }

    public void PlayTinker()
    {
        Tinker.Play();
    }

    public void StopTinker()
    {
        Tinker.Stop();
    }

    public void PlayAttaque()
    {
        Attaque.Emit(50);
    }
    public void PlaySwitchjoueur()
    {
        Switchjoueur.Emit(500);
    }


	#endregion


	#region Subfunctions
    
	//private void InitializeData() { }
	//private void InitializeScripts() { }
    //private void InitializeRules() { }
    
    #endregion
}
