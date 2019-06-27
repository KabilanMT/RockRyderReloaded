using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelHandler : MonoBehaviour {

    public GameObject title;
    public GameObject score1;
    public GameObject score2;
    public GameObject score3;
    public GameObject score4;
    public GameObject score5;

    TextMesh txtTitle;
    TextMesh txt1;
    TextMesh txt2;
    TextMesh txt3;
    TextMesh txt4;
    TextMesh txt5;

	// Use this for initialization
	void Start () {
	}

    public void setGrassScore()
    {
        txtTitle = title.GetComponent<TextMesh>();
        txtTitle.text = "Highscore - Grassland:";
        txt1 = score1.GetComponent<TextMesh>();
        txt2 = score2.GetComponent<TextMesh>();
        txt3 = score3.GetComponent<TextMesh>();
        txt4 = score4.GetComponent<TextMesh>();
        txt5 = score5.GetComponent<TextMesh>();

        string scores = PlayerPrefs.GetString("Highscore1");
        string[] scoresplit = scores.Split(',');

        txt1.text = scoresplit[0];
        txt2.text = scoresplit[1];
        txt3.text = scoresplit[2];
        txt4.text = scoresplit[3];
        txt5.text = scoresplit[4];
    }
	
    public void setSnowScore()
    {
        txtTitle = title.GetComponent<TextMesh>();
        txtTitle.text = "Highscore - Snow:";
        txt1 = score1.GetComponent<TextMesh>();
        txt2 = score2.GetComponent<TextMesh>();
        txt3 = score3.GetComponent<TextMesh>();
        txt4 = score4.GetComponent<TextMesh>();
        txt5 = score5.GetComponent<TextMesh>();

        string scores = PlayerPrefs.GetString("Highscore2");
        string[] scoresplit = scores.Split(',');

        txt1.text = scoresplit[0];
        txt2.text = scoresplit[1];
        txt3.text = scoresplit[2];
        txt4.text = scoresplit[3];
        txt5.text = scoresplit[4];
    }
    
    public void setPaperScore()
    {
        txtTitle = title.GetComponent<TextMesh>();
        txtTitle.text = "Highscore - Paper:";
        txt1 = score1.GetComponent<TextMesh>();
        txt2 = score2.GetComponent<TextMesh>();
        txt3 = score3.GetComponent<TextMesh>();
        txt4 = score4.GetComponent<TextMesh>();
        txt5 = score5.GetComponent<TextMesh>();

        string scores = PlayerPrefs.GetString("Highscore3");
        string[] scoresplit = scores.Split(',');

        txt1.text = scoresplit[0];
        txt2.text = scoresplit[1];
        txt3.text = scoresplit[2];
        txt4.text = scoresplit[3];
        txt5.text = scoresplit[4];
    }

    public void setNotUnlocked()
    {
        txtTitle = title.GetComponent<TextMesh>();
        txtTitle.text = "Level not Unlocked yet";
        txt1 = score1.GetComponent<TextMesh>();
        txt2 = score2.GetComponent<TextMesh>();
        txt3 = score3.GetComponent<TextMesh>();
        txt4 = score4.GetComponent<TextMesh>();
        txt5 = score5.GetComponent<TextMesh>();

        txt1.text = "";
        txt2.text = "";
        txt3.text = "";
        txt4.text = "";
        txt5.text = "";
    }
}
