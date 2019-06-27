using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public Transform target; //This will be your citizen
    public float distance;
    public GameObject ryder;
    BallSlide slide;

    // Use this for initialization
    void Start()
    {
        slide = (BallSlide)ryder.GetComponent(typeof(BallSlide));
    }

    // Update is called once per frame
    void Update()
    {
        if (slide.hitGround == true)
        {
            Vector2 offset = new Vector2(BallScript.vspeed / 8, 0);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }
        else
        {
            Vector2 offset = new Vector2(BallScript.vspeed / 4, 0);
            GetComponent<Renderer>().material.mainTextureOffset = offset;
        }
        if (!target)
        {
            // Search for object with Player tag
            GameObject go = GameObject.FindWithTag("Player");
            // Check we found an object with the player tag
            if (go)
                // Set the target to the object we found
                target = go.transform;
        }

        if (target)
        {
            transform.position = new Vector3(target.position.x + 2, 61, target.position.z - distance - 5);
        }
    }



}
