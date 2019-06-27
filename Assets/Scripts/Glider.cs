using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glider : MonoBehaviour
{
    public GameObject glider;
    public GameObject ryder;
    Rigidbody rb;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    Vector3 regGravity;
    bool hitGround = false;
    float initVelY;
    float initVelZ;
    public static bool gliderDeployed = false;

    // Use this for initialization
    void Start()
    {
        rb = ryder.GetComponent<Rigidbody>();
        regGravity = Physics.gravity;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitGround == false)
        {
            if (BallScript.launched == true)
            {
                if (Input.GetKeyDown(KeyCode.G) || Input.GetKeyDown(KeyCode.Joystick1Button1))
                {
                    if (PlayerPrefs.GetInt("GliderBought") == 1)
                    {
                        gliderDeployed = true;
                        if (glider.activeSelf == false)
                        {
                            initVelY = rb.velocity.y;
                            initVelZ = rb.velocity.z;
                            glider.SetActive(true);
                        }
                    }
                }
            }
        }
        if (glider.activeSelf == true)
        {
            if (transform.localEulerAngles.x >= 270 && transform.localEulerAngles.x <= 300)
            {
                //rb.constraints = RigidbodyConstraints.FreezeRotation;
            }
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            // Smoothly tilts a transform towards a target rotation.
            float tiltAroundX = Input.GetAxis("Vertical") * tiltAngle;

            Quaternion target = Quaternion.Euler(tiltAroundX, 0, 0);

            // Dampen towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);



            if (transform.localEulerAngles.x > 355 || transform.localEulerAngles.x < 6)
            {
                GetComponent<ConstantForce>().force = new Vector3(0, 0.25f, -0.3f);
            }
            else if (transform.localEulerAngles.x >= 6 && transform.localEulerAngles.x < 55)
            {
                GetComponent<ConstantForce>().force = new Vector3(0, 0.5f, 0.2f);
            }
            else if (transform.localEulerAngles.x >= 55 && transform.localEulerAngles.x < 61)
            {
                GetComponent<ConstantForce>().force = new Vector3(0, -2.0f, 0.3f);
            }
            else if (transform.localEulerAngles.x <= 355 && transform.localEulerAngles.x > 310)
            {
                GetComponent<ConstantForce>().force = new Vector3(0, -0.5f, -0.4f);
            }
            else if (transform.localEulerAngles.x <= 310 && transform.localEulerAngles.x > 299)
            {
                GetComponent<ConstantForce>().force = new Vector3(0, -2.0f, -0.3f);
            }
            else
            {
                GetComponent<ConstantForce>().force = new Vector3(0, 0, 0);
            }

            GetComponent<ConstantForce>().force = new Vector3(0, 0, 0);
            Debug.Log(GetComponent<ConstantForce>().force);

            //else if (transform.localEulerAngles.x >= 0 && transform.localEulerAngles.x <= 45)
            //{

            //}

            //if (Physics.gravity != regGravity)
            //{
            //    if (Input.GetAxis("Vertical") < 0)
            //    {
            //        Physics.gravity = new Vector3(0, -3.0F, 0);
            //    }
            //    else if (Input.GetAxis("Vertical") > 0)
            //    {
            //        Physics.gravity = new Vector3(0, -1.0F, 0);
            //    }
            //    else
            //    {
            //        Physics.gravity = new Vector3(0, -2.5F, 0);
            //    }
            //}
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Floor")
        {
            hitGround = true;
            glider.SetActive(false);
        }
    }
}
