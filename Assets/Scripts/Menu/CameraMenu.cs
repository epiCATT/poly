using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour {


    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;



    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * 0.1f;
        transform.eulerAngles = new Vector3(0f, yaw, 0.0f);
    }
}

