using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {
    public Camera birdCamera;
    public Camera loadCamera;
    public Camera titleCamera;
    public GameObject birdCameraEnd;
    public GameObject Bird;
    public GameObject BirdSit;
    public GameObject BirdUp;
    public GameObject BirdEnd;
    private Vector3 initCam;
    private Vector3 finCam;
    private Quaternion initRotCam;
    private Quaternion finRotCam;
    private Vector3 initBird;
    private Vector3 waypointBird;
    private Vector3 finBird;
    private Vector3 Bird2;
    private Vector3 Bird2Final;


    public float speed = 1.0F;
    public float birdSpeed = 1.0F;
    public float birdSitSpeed = 1.0F;
    private float startTime;
    private float startTime2;
    private float distanceCam;
    private float distanceCalcCam;

    private float distanceBird;
    private float distanceCalcBird;
    private float distanceBirdFinal;
    private float distanceCalcBirdFinal;

    private float bird2Distance;
    private float bird2Calc;

    private bool start;
    private bool start2;
    
	// Use this for initialization
	void Start () {
        start = false;
        start2 = false;

        initCam = birdCamera.gameObject.transform.position;
        finCam = birdCameraEnd.gameObject.transform.position;
        initRotCam = birdCamera.gameObject.transform.rotation;
        finRotCam = birdCameraEnd.gameObject.transform.rotation;

        initBird = Bird.gameObject.transform.position;
        finBird = BirdEnd.gameObject.transform.position;

        Bird2 = BirdSit.gameObject.transform.position;
        Bird2Final = BirdUp.gameObject.transform.position;

        distanceCam = Vector3.Distance(initCam, finCam);
        distanceBird = Vector3.Distance(initBird, waypointBird);
        distanceBirdFinal = Vector3.Distance(waypointBird, finBird);
        bird2Distance = Vector3.Distance(Bird2, Bird2Final);

        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        float distanceCamMoved = (Time.time - startTime) * speed;
        float fracCamDist = distanceCamMoved / distanceCam;
        birdCamera.transform.position = Vector3.Lerp(initCam, finCam, fracCamDist);
        birdCamera.transform.rotation = Quaternion.Slerp(initRotCam, finRotCam, fracCamDist);
        
        float distanceBirdMoved = (Time.time - startTime) * birdSpeed;
        float fracBirdDist = distanceBirdMoved / distanceBird;
        Bird.transform.position = Vector3.Lerp(initBird, finBird, fracBirdDist);

        if(fracCamDist > 1 && !start)
        {
            start = true;
            GameObject menuHandler = GameObject.Find("CameraHandler");
            MenuScript temp = (MenuScript)menuHandler.GetComponent(typeof(MenuScript));
            temp.setIntroComplete();

            birdCamera.enabled = false;
            loadCamera.enabled = false;
            titleCamera.enabled = true;
        }
        if (fracBirdDist > 1.1 && !start2)
        {
            startTime2 = Time.time;
            start2 = true;
        }
        if (start2)
        {
            float distanceSitBird = (Time.time - startTime2) * speed;
            float bird2Dist = distanceSitBird / bird2Distance;
            BirdSit.transform.position = Vector3.Slerp(Bird2, Bird2Final, bird2Dist);
        }
    }
}
