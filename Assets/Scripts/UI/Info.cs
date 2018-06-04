using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info : MonoBehaviour {
    [SerializeField] public Image customeimage;
    void Start() {
        customeimage.enabled = false;
    }
    public void On()
    {
        if(customeimage.enabled == false)
        {
            customeimage.enabled = true;
        }
        else
        {
            customeimage.enabled = false;
        }

    }

    
}
