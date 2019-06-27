using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour {
    public GameObject ball;
    Rigidbody ballRb;
    float power = 3;
    float boosty;
    float boostz;
    int breadEaten;
    public static float vspeed;
    bool hitfloor = false;
    public static int numberOfBoosts = 3;
    public static bool launched = false;
    Text boostText;
    string rampName = "RampV1";
    string powerupTag = "Powerup";
    string fuelPowerupTag = "fuel Powerup";
    string boostPowerupTag = "boost Powerup";
    string floorName = "Floor";
    Vector3 vel;
    Vector3 angVel;
    bool hitGround;

    public AudioClip bonk;
    public AudioClip youDidIt;
    public AudioClip floorSound;
    AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
        ballRb = gameObject.GetComponent<Rigidbody>();
        boostText = GameObject.Find("boostText").GetComponent<Text>();
        boostText.text = numberOfBoosts.ToString();
        ballRb.AddForce(ballRb.velocity.normalized * power);
        hitGround = false;
        boosty = 10;
        boostz = -12;
        Time.timeScale = 0.0f;
    }

	// Update is called once per frame
	void Update () {
        vspeed = GetComponent<Rigidbody>().velocity.z;
        //Debug.Log(vspeed);

        if (hitGround == false)
        {
            if (launched == true)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick1Button0))
                {
                    useboost();
                }
            }
        }

        if (Input.anyKey)
        {
            Time.timeScale = 1.0f;
        }
    }

    void FixedUpdate()
    {
        vel = ballRb.velocity;
        angVel = ballRb.angularVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == rampName)
        {
            ballRb.AddForce(0, -15, -13, ForceMode.Impulse);
        }
        else if(collision.gameObject.name == floorName)
        {
            hitfloor = true;
            audioSource.PlayOneShot(floorSound, 1.0F);
        }
        if (collision.gameObject.tag.Contains(powerupTag))
        {
            Debug.Log("VEL IS: " + vel);
            Debug.Log("ANG VEL IS: " + angVel);
            ballRb.velocity = vel;
            ballRb.angularVelocity = angVel;
            collision.gameObject.SetActive(false);

            if(collision.gameObject.tag == "boost Powerup")
            {
                numberOfBoosts += 1;
                boostText.text = numberOfBoosts.ToString();
                audioSource.PlayOneShot(youDidIt, 1.0F);
            }
            else if(collision.gameObject.tag == "fuel Powerup")
            {
                RocketScript.fuel += 50;
                audioSource.PlayOneShot(youDidIt, 1.0F);
            }
        }
        if (collision.collider.name == "Floor")
        {
            hitGround = true;
            audioSource.PlayOneShot(floorSound, 1.0F);
        }
        if (collision.gameObject.tag == "Obstacle")
        {
            audioSource.PlayOneShot(bonk, 1.0F);
        }

    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.name == rampName)
        {
            ballRb.AddForce(0, 0, -20, ForceMode.Impulse);
            Physics.gravity = new Vector3(0, -1.0F, 0);
            ballRb.useGravity = true;
            launched = true;
        } else if(collision.gameObject.tag == powerupTag){

        }
    }


    void useboost()
    {
        if (numberOfBoosts > 0)
        {
            breadEaten = PlayerPrefs.GetInt("BreadEaten");
            boosty = boosty + breadEaten * 0.15f;
            boostz = boostz - breadEaten * 0.5f;
            ballRb.AddForce(0, boosty, boostz, ForceMode.Impulse);
            Debug.Log(boosty + " " + boostz);
            Debug.Log("Applied Boost");
            numberOfBoosts -= 1;
            boostText.text = numberOfBoosts.ToString();
        }
        else
        {
            Debug.Log("All Boosts Used!");
        }
    }
}
