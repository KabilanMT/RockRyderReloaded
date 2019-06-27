using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndButtons : MonoBehaviour
{

    public int currentLevel;
    public GameObject gameEndMenu;
    // Use this for initialization
    void Start()
    {

    }

    public void Update()
    {
        if (gameEndMenu.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                menuClick();
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                replayClick();
            }
        }
    }

    public void replayClick()
    {
        SceneManager.LoadScene(currentLevel + 1, LoadSceneMode.Single);
    }

    public void menuClick()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }
}
