using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveHandler : MonoBehaviour {

    public GameObject money;
    MoneyHandler payment;

    public GameObject glider;
    public GameObject gliderHitbox;

    public GameObject rocket;
    public GameObject rocketHitbox;

    public GameObject levelHandler;
    LevelHandler lvlhandler;

	// Use this for initialization
	void Start () {
       lvlhandler = (LevelHandler)levelHandler.GetComponent(typeof(LevelHandler));
       payment = (MoneyHandler)money.GetComponent(typeof(MoneyHandler));
       if (PlayerPrefs.HasKey("Money"))
       {
           payment.setMoney(PlayerPrefs.GetFloat("Money"));
       }
       else
       {
           PlayerPrefs.SetFloat("Money", 10000);
           payment.setMoney(PlayerPrefs.GetFloat("Money"));
       }

       if (PlayerPrefs.HasKey("ApplesEaten"))
        {
            payment.setApplesEaten(PlayerPrefs.GetInt("ApplesEaten"));
        }
       else
        {
            PlayerPrefs.SetInt("ApplesEaten", 0);
            payment.setApplesEaten(PlayerPrefs.GetInt("ApplesEaten"));
        }

        if (PlayerPrefs.HasKey("BreadEaten"))
        {
            payment.setBreadEaten(PlayerPrefs.GetInt("BreadEaten"));
        }
        else
        {
            PlayerPrefs.SetInt("BreadEaten", 0);
            payment.setBreadEaten(PlayerPrefs.GetInt("BreadEaten"));
        }

        if (PlayerPrefs.HasKey("SteakEaten"))
        {
            payment.setSteaksEaten(PlayerPrefs.GetInt("SteakEaten"));
        }
        else
        {
            PlayerPrefs.SetInt("SteakEaten", 0);
            payment.setSteaksEaten(PlayerPrefs.GetInt("SteakEaten"));
        }

        if (PlayerPrefs.HasKey("AppleCost"))
        {
            payment.setAppleCost(PlayerPrefs.GetFloat("AppleCost"));
        }
        else
        {
            PlayerPrefs.SetFloat("AppleCost", payment.getAppleCost());
            payment.setAppleCost(PlayerPrefs.GetFloat("AppleCost"));
        }

        if (PlayerPrefs.HasKey("BreadCost"))
        {
            payment.setBreadCost(PlayerPrefs.GetFloat("BreadCost"));
        }
        else
        {
            PlayerPrefs.SetFloat("BreadCost", payment.getBreadCost());
            payment.setBreadCost(PlayerPrefs.GetFloat("BreadCost"));
        }

        if (PlayerPrefs.HasKey("SteakCost"))
        {
            payment.setSteakCost(PlayerPrefs.GetFloat("SteakCost"));
        }
        else
        {
            PlayerPrefs.SetFloat("SteakCost", payment.getSteakCost());
            payment.setSteakCost(PlayerPrefs.GetFloat("SteakCost"));
        }

        if (PlayerPrefs.HasKey("RocketBought"))
        {
            if(PlayerPrefs.GetInt("RocketBought") == 1)
            {
                payment.buyRocket();
                Destroy(rocket);
                Destroy(rocketHitbox);
            }
        }
        else
        {
            PlayerPrefs.SetInt("RocketBought", 0);
        }
        if (PlayerPrefs.HasKey("GliderBought"))
        {
            Debug.Log(PlayerPrefs.GetInt("GliderBought"));
            if (PlayerPrefs.GetInt("GliderBought") == 1)
            {
                payment.buyGlider();
                Destroy(glider);
                Destroy(gliderHitbox);
            }
        }
        else
        {
            PlayerPrefs.SetInt("GliderBought", 0);
        }

        if (PlayerPrefs.HasKey("Highscore1"))
        {
            Debug.Log(PlayerPrefs.GetString("Highscore1"));
        }
        else
        {
            PlayerPrefs.SetString("Highscore1", "5, 4, 3, 2, 1,");
        }
        if (PlayerPrefs.HasKey("Highscore2"))
        {
            Debug.Log(PlayerPrefs.GetString("Highscore2"));
        }
        else
        {
            PlayerPrefs.SetString("Highscore2", "5, 4, 3, 2, 1,");
        }
        if (PlayerPrefs.HasKey("Highscore3"))
        {
            Debug.Log(PlayerPrefs.GetString("Highscore3"));
        }
        else
        {
            PlayerPrefs.SetString("Highscore3", "5, 4, 3, 2, 1,");
        }

        if (PlayerPrefs.HasKey("paper"))
        {
            Debug.Log(PlayerPrefs.GetInt("paper"));
        }
        else
        {
            PlayerPrefs.SetInt("paper", 0);
        }
        if (PlayerPrefs.HasKey("snow"))
        {
            Debug.Log("SNOW: " + PlayerPrefs.GetInt("snow"));
        }
        else
        {
            PlayerPrefs.SetInt("snow", 0);
        }





    }

	// Update is called once per frame
	void Update () {

	}
}
