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
    }

    // START
    void Start() {

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
        Finished.Play();
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
        Attaque.Play();
    }
    public void PlaySwitchjoueur()
    {
        Switchjoueur.Play();
    }


	#endregion


	#region Subfunctions
    
	//private void InitializeData() { }
	//private void InitializeScripts() { }
    //private void InitializeRules() { }
    
    #endregion
}
