using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text unlockDistanceText;
    public Text scoreText;
    public GameObject ball;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
        int score = Math.Abs((int)ball.transform.position.z - 3);
        scoreText.text = score.ToString();

        if (GameEndMenu.dist - score >= 0)
        {
            unlockDistanceText.text = (GameEndMenu.dist - score).ToString();
        }
	}
}
