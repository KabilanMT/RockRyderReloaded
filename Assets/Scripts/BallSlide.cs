using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSlide : MonoBehaviour
{
    public GameObject ryder;
    SphereCollider RyderCollider;
    Rigidbody RyderBody;
    public bool hitGround;
    bool slide;
    public int slideTier;
    float steaksEaten;

    // Use this for initialization
    void Start()
    {
        RyderCollider = ryder.GetComponent<SphereCollider>();
        RyderBody = ryder.GetComponent<Rigidbody>();
        hitGround = false;
        slide = true;
        slideTier = PlayerPrefs.GetInt("SteakEaten");
    }

    // Update is called once per frame
    void Update()
    {
        if (hitGround == true)
        {
            if (slide == true)
            {
                RyderBody.angularDrag += 0.5f;
            }

            if (RyderBody.velocity.z > 0)
            {
                RyderBody.constraints = RigidbodyConstraints.FreezePosition;
                RyderBody.constraints = RigidbodyConstraints.FreezeRotation;
                RyderBody.velocity = new Vector3(0, 0, 0);
                hitGround = false;
                GetComponent<ConstantForce>().force = new Vector3(0, 0, 0);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "Floor")
        {
            hitGround = true;

            switch (slideTier)
            {
                case 1:
                    GetComponent<ConstantForce>().force = new Vector3(0, 0, 5.0f);
                    break;
                case 2:
                    GetComponent<ConstantForce>().force = new Vector3(0, 0, 4.75f);
                    break;
                case 3:
                    GetComponent<ConstantForce>().force = new Vector3(0, 0, 4.5f);
                    break;
                case 4:
                    GetComponent<ConstantForce>().force = new Vector3(0, 0, 4.25f);
                    break;
                case 5:
                    GetComponent<ConstantForce>().force = new Vector3(0, 0, 4.0f);
                    break;
                case 6:
                    GetComponent<ConstantForce>().force = new Vector3(0, 0, 3.75f);
                    break;
                case 7:
                    GetComponent<ConstantForce>().force = new Vector3(0, 0, 3.5f);
                    break;
                case 8:
                    GetComponent<ConstantForce>().force = new Vector3(0, 0, 3.25f);
                    break;
                case 9:
                    GetComponent<ConstantForce>().force = new Vector3(0, 0, 3.0f);
                    break;
                case 10:
                    GetComponent<ConstantForce>().force = new Vector3(0, 0, 2.5f);
                    break;
                default:
                    GetComponent<ConstantForce>().force = new Vector3(0, 0, 5.0f);
                    break;
            }

        }
    }
}
