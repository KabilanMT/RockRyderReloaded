using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RocketScript : MonoBehaviour
{

    public GameObject ball;
    public GameObject rocket;
    Rigidbody ballRb;
    Rigidbody rocketRb;
    RigidbodyConstraints originalConstraints;
    public static int fuel = 100;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    bool hitGround;
    Text fuelText;

    // Use this for initialization
    void Start()
    {
        ballRb = ball.GetComponent<Rigidbody>();
        rocketRb = rocket.GetComponent<Rigidbody>();
        fuelText = GameObject.Find("fuelText").GetComponent<Text>();
        originalConstraints = ballRb.constraints;
        rocket.SetActive(false);
        hitGround = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R) || Input.GetKey(KeyCode.Joystick1Button2))
        {
            if (PlayerPrefs.GetInt("RocketBought") == 1)
            {
                if (Glider.gliderDeployed == true)
                {
                    useRocket();
                }
            }
        }
        else
        {
            rocket.SetActive(false);
            ballRb.constraints = RigidbodyConstraints.None;
            ballRb.constraints = RigidbodyConstraints.FreezePositionX;
        }

        if (rocket.activeSelf == true)
        {
            if (transform.localEulerAngles.x >= -100 && transform.localEulerAngles.x <= -90)
            {
                rocketRb.constraints = RigidbodyConstraints.FreezeRotation;
            }

            // Smoothly tilts a transform towards a target rotation.
            float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

            Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
        }

        fuelText.text = fuel.ToString();
    }

    void useRocket()
    {
        if (hitGround == false)
        {
            if (fuel > 0)
            {
                rocket.SetActive(true);
                fuel = fuel -= 1;
                originalConstraints = ballRb.constraints;
                ballRb.freezeRotation = true;
                ballRb.constraints = RigidbodyConstraints.FreezePositionX;
                //ballRb.AddForce(0, 0, -1, ForceMode.Impulse);
                ballRb.AddForce(ballRb.transform.forward * -1, ForceMode.Impulse);
            }
            else
            {
                rocket.SetActive(false);
            }
        }
        else
        {
            rocket.SetActive(false);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Floor")
        {
            hitGround = true;
        }
    }
}
