using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyHandler : MonoBehaviour {
    public float money = 0F;
    public int applesEaten = 0;
    public int steaksEaten = 0;
    public int breadEaten = 0;
    public bool rocketObtained = false;
    public bool gliderObtained = false;

    public float appleCost = 100F;
    public float steakCost = 100F;
    public float breadCost = 100F;
    public float gliderCost = 5000F;
    public float rocketCost = 1000F;

    public float expo = 1.001F;

    public int appleMax = 10;
    public int steakMax = 10;
    public int breadMax = 10;

    public void init(int amount, int apples, int steaks, int bread, bool rocket)
    {
        money = amount;
        applesEaten = apples;
        steaksEaten = steaks;
        breadEaten = bread;
        rocketObtained = rocket;
    }
    public void addMoney(float amount)
    {
        money += amount;
        PlayerPrefs.SetFloat("Money", money);
    }
    public void subMoney(float amount)
    {
        money -= amount;
        PlayerPrefs.SetFloat("Money", money);
    }
    public float getMoney()
    {
        return(money);
    }
    public void setMoney(float amount)
    {
        money = amount;
    }
    public void addApplesEaten()
    {
        applesEaten += 1;
        PlayerPrefs.SetInt("ApplesEaten", applesEaten);
    }
    public int getApplesEaten()
    {
        return(applesEaten);
    }
    public void addSteaksEaten()
    {
        steaksEaten += 1;
        PlayerPrefs.SetInt("SteakEaten", steaksEaten);
    }
    public int getSteaksEaten()
    {
        return (steaksEaten);
    }
    public void addBreadEaten()
    {
        breadEaten += 1;
        PlayerPrefs.SetInt("BreadEaten", breadEaten);
    }
    public void setApplesEaten(int amount)
    {
        applesEaten = amount;
    }
    public void setSteaksEaten(int amount)
    {
        steaksEaten = amount;
    }
    public void setBreadEaten(int amount)
    {
        breadEaten = amount;
    }
    public int getBreadEaten()
    {
        return (breadEaten);
    }
    public void buyRocket()
    {
        rocketObtained = true;
        PlayerPrefs.SetInt("RocketBought", 1);
    }
    public void buyGlider()
    {
        gliderObtained = true;
        PlayerPrefs.SetInt("GliderBought", 1);
    }
    public bool getRocketObtained()
    {
        return (rocketObtained);
    }
    public float getAppleCost()
    {
        return (appleCost);
    }
    public float getBreadCost()
    {
        return (breadCost);
    }
    public float getSteakCost()
    {
        return (steakCost);
    }
    public float getRocketCost()
    {
        return (rocketCost);
    }
    public float getGliderCost()
    {
        return (gliderCost);
    }
    public void updateAppleCost()
    {
        appleCost = Mathf.Round(Mathf.Pow(appleCost, expo));
        PlayerPrefs.SetFloat("AppleCost", appleCost);
    }
    public void updateBreadCost()
    {
        breadCost = Mathf.Round(Mathf.Pow(breadCost, expo));
        PlayerPrefs.SetFloat("BreadCost", breadCost);
    }
    public void updateSteakCost()
    {
        steakCost = Mathf.Round(Mathf.Pow(steakCost, expo));
        PlayerPrefs.SetFloat("SteakCost", steakCost);
    }
    public void setAppleCost(float amount)
    {
        appleCost = amount;
    }
    public void setSteakCost(float amount)
    {
        steakCost = amount;
    }
    public void setBreadCost(float amount)
    {
        breadCost = amount;
    }
    public int getAppleMax()
    {
        return (appleMax);
    }
    public int getBreadMax()
    {
        return (breadMax);
    }
    public int getSteakMax()
    {
        return (steakMax);
    }
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
