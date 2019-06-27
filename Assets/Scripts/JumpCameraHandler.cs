using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCameraHandler : MonoBehaviour {

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
    private float backDistance;
    private float distanceCalc;
    private bool start;
    private bool back;
    public float expo = 2.0F;

    // Use this for initialization
    void Start()
    {
        start = false;
        back = false;
        init = titleCamera.gameObject.transform.position;
        fin = menuCamera.gameObject.transform.position;
        initRot = titleCamera.gameObject.transform.rotation;
        finRot = menuCamera.gameObject.transform.rotation;
        distance = Vector3.Distance(init, fin);
        backDistance = Vector3.Distance(fin, init);
    }

    // Update is called once per frame
    public void startCam()
    {
        start = true;
        startTime = Time.time;
    }
    public void returnCam()
    {
        back = true;
        startTime = Time.time;
    }
    void Update()
    {
        if (start)
        {
            float distanceMoved = (Time.time - startTime) * speed;
            distanceMoved = (float)Math.Pow(distanceMoved, expo);
            distanceMoved = distanceMoved / expo;
            float fracDist = distanceMoved / distance;
            cameraFollower.transform.position = Vector3.Slerp(init, fin, fracDist);
            cameraFollower.transform.rotation = Quaternion.Slerp(initRot, finRot, fracDist);
        }
        if (back)
        {
            float distanceMoved = (Time.time - startTime) * speed;
            distanceMoved = (float)Math.Pow(distanceMoved, expo);
            distanceMoved = distanceMoved / expo;
            float fracDist = distanceMoved / distance;
            cameraFollower.transform.position = Vector3.Slerp(fin, init, fracDist);
            cameraFollower.transform.rotation = Quaternion.Slerp(finRot, initRot, fracDist);
            if (fracDist > 1)
            {
                back = false;
            }
        }
    }
}
