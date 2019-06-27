using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
    public Transform target; //This will be your citizen
    public Transform sign; //This will be your citizen
    public float distance;

    // Use this for initialization
    void Start () {

	}

	// Update is called once per frame
	void Update () {
        if (!target)
        {
            // Search for object with Player tag
            GameObject go = GameObject.FindWithTag("Player");

            // Check we found an object with the player tag
            if (go)
                // Set the target to the object we found
                target = go.transform;
        }


        if (target && Time.timeScale == 1.0f)
            transform.position = new Vector3(target.position.x - 14, target.position.y, target.position.z - distance - 7);
        //Camera.main.transform.rotation = Quaternion.Euler(x, y, z);
        else
        {
            transform.position = new Vector3(sign.transform.position.x - 2, sign.transform.position.y, sign.transform.position.z - distance);
        }
    }

}
