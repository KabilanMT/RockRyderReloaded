using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuScript : MonoBehaviour {
    private bool introComplete;
    private bool buttonPressed;
    public Camera titleCamera;
    public Camera menuCamera;
    public GameObject cameraFollower;
    private Vector3 init;
    private Vector3 fin;
    private Quaternion initRot;
    private Quaternion finRot;
    public float speed = 1.0F;
    private float startTime;
    private float distance;
    private float distanceCalc;
    private bool start;
    public float expo = 2.0F;

	// Use this for initialization
	void Start () {
        introComplete = false;
        buttonPressed = false;
        start = false;
        init = titleCamera.gameObject.transform.position;
        fin = menuCamera.gameObject.transform.position;
        initRot = titleCamera.gameObject.transform.rotation;
        finRot = menuCamera.gameObject.transform.rotation;
        distance = Vector3.Distance(init, fin);
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.anyKey)
        {
            if (Input.GetMouseButton(0) || Input.GetMouseButton(1) || Input.GetMouseButton(2) || buttonPressed || !introComplete)
            {
                return;
            }
            else
            {
                start = true;
                startTime = Time.time;
                buttonPressed = !buttonPressed;
            }
        }
        
        if(start)
        {
            float distanceMoved = (Time.time - startTime) * speed;
            distanceMoved = (float)Math.Pow(distanceMoved, expo);
            distanceMoved = distanceMoved / expo;
            float fracDist = distanceMoved / distance;
            cameraFollower.transform.position = Vector3.Slerp(init, fin, fracDist);
            cameraFollower.transform.rotation = Quaternion.Slerp(initRot, finRot, fracDist);
        }
	}

    public void setIntroComplete()
    {
        introComplete = true;
    }
    
}
