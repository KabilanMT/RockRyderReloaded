using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEndMenu : MonoBehaviour {

    public GameObject gameEndMenu;
    public Transform ryder;
    public Text score;
    public Text finalScore;
    public Text moneyEarned;
    public GameObject levelUnlocked;
    public Button replayButton;
    public Button menuButton;
    public int unlockDistance;
    public int currentLevel;
    private Vector3 lastPosition = Vector3.zero;
    private readonly int lastLevel = 3;
    private bool gameEnded = false;
    public static int dist = 0;
	// Use this for initialization
	void Start () {
        gameEndMenu.SetActive(false);
        InvokeRepeating("checkPosition", 5.0f, 1.0f);
        dist = unlockDistance;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void checkPosition()
    {
        if (lastPosition.x == ryder.position.x && lastPosition.y == ryder.position.y && lastPosition.z == ryder.position.z && gameEnded == false)
        {
            gameEnded = true;
            gameEndMenu.SetActive(true);
            string scoreStr = score.text.ToString();
            string moneyStr = "";
            if (currentLevel == 1)
            {
                moneyStr = (Mathf.Ceil((int.Parse(scoreStr) / 10) * 0.85f)).ToString();
            }
            else if (currentLevel == 2)
            {
                moneyStr = (Mathf.Ceil((int.Parse(scoreStr) / 10) * 1.33f)).ToString();
            }
            else if (currentLevel == 3)
            {
                moneyStr = (Mathf.Ceil((int.Parse(scoreStr) / 10) * 1.44f)).ToString();
            }
            finalScore.text = "Final Score: " + scoreStr;
            moneyEarned.text = "Money Earned: " + moneyStr;
            updateInfo(moneyStr, scoreStr);
            if(int.Parse(scoreStr) >= unlockDistance)
            {
                if (currentLevel != lastLevel)
                {
                    levelUnlocked.GetComponent<Text>().text = ("Level " + (currentLevel+1) + " Unlocked!");
                    if(currentLevel == 1)
                    {
                        PlayerPrefs.SetInt("snow", 1);

                    }else if(currentLevel == 2)
                    {
                        if (PlayerPrefs.GetInt("paper") == 0)
                        {
                            PlayerPrefs.SetInt("paper", 1);
                            SceneManager.LoadScene("MiddleCut", LoadSceneMode.Single);
                        }
                    }
                }
                else
                {
                    gameEndMenu.SetActive(false);
                    SceneManager.LoadScene("EndCut", LoadSceneMode.Single);
                    //levelUnlocked.GetComponent<Text>().text = ("All Levels Completed!");
                }
            }
            else
            {
                levelUnlocked.SetActive(false);
            }
        }
        lastPosition = ryder.position;
    }

    void updateInfo(string moneyStr, string scoreStr)
    {
        RocketScript.fuel = 100;
        BallScript.numberOfBoosts = 3;
        BallScript.launched = false;
        Glider.gliderDeployed = false;
        Physics.gravity = new Vector3(0, -9.81F, 0);

        float currentMoney = PlayerPrefs.GetFloat("Money");
        currentMoney += (int.Parse(moneyStr));
        PlayerPrefs.SetFloat("Money", currentMoney);

        int newScore = int.Parse(scoreStr);
        string highScoreString = PlayerPrefs.GetString("Highscore" + currentLevel);
        string[] currentHighScoresStr = highScoreString.Split(',');
        currentHighScoresStr = currentHighScoresStr.Reverse().Skip(1).Reverse().ToArray();
        int[] currentHighScores = new int[currentHighScoresStr.Length];
        currentHighScores = Array.ConvertAll(currentHighScoresStr, int.Parse);
        Array.Sort(currentHighScores);
        int playerScore = int.Parse(scoreStr);
        if(playerScore > currentHighScores[0])
        {
            currentHighScores[0] = playerScore;
            Array.Sort(currentHighScores);
            currentHighScores = currentHighScores.Reverse().ToArray();
            string formattedHighScores = "";
            for (int i = 0; i < currentHighScores.Length; i++)
            {
                formattedHighScores = formattedHighScores + (currentHighScores[i] + ",");
            }
            PlayerPrefs.SetString("Highscore" + currentLevel, formattedHighScores);
        }
        Debug.Log(PlayerPrefs.GetString("Highscore" + currentLevel));
    }
}
