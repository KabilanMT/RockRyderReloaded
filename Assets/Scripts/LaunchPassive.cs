using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchPassive : MonoBehaviour {

    public static float launchForce = -20;

    // Use this for initialization
    void Start () {
        float applesEaten = PlayerPrefs.GetInt("ApplesEaten");
        launchForce *= ((applesEaten / 10) + 1);
	}

	// Update is called once per frame
	void Update () {
	}
}
