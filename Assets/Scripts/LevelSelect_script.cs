using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect_script : MonoBehaviour
{
    public static int counter;
    public static bool onetime;
    public static bool jump;
    public GameObject cameraFollower;
    public GameObject cameraFollowerObject;
    MainCameraHandler camera;

    void Start()
    {
        counter = 0;
        onetime = false;
        jump = false;
    }
    void Update()
    {
        if (jump)
        {
            Debug.Log(counter);
            if (!onetime)
            {
                if (Input.GetAxis("Vertical") < 0)
                {
                    AddCount();
                    onetime = true;
                }
                if (Input.GetAxis("Vertical") > 0)
                {
                    SubCount();
                    onetime = true;
                }
            }
            else if (onetime)
            {
                if (Input.GetAxis("Vertical") == 0)
                {
                    onetime = false;
                }
            }
        }

        if (PlayerPrefs.GetInt("paper") == 0 && PlayerPrefs.GetInt("snow") == 0)
        {
            counter = 0;
        }
        else if (PlayerPrefs.GetInt("paper") == 0 && PlayerPrefs.GetInt("snow") == 1)
        {
            if (counter > 1)
            {
                counter = 0;
            }
            else if (counter < 0)
            {
                counter = 1;
            }
        }
        else if (PlayerPrefs.GetInt("paper") == 1 && PlayerPrefs.GetInt("snow") == 1)
        {
            if (counter > 2)
            {
                counter = 0;
            }
            else if (counter < 0)
            {
                counter = 2;
            }
        }

    }
    public static void AddCount()
    {
        counter += 1;
    }

    public static void SubCount()
    {
        counter -= 1;
    }

    public static int GetCount()
    {
        return counter;
    }
}
