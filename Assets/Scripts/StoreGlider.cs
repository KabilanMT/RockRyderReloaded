using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreGlider : MonoBehaviour {

    public GameObject gliderRock;
    public void ShowGlider()
    {
        if (gliderRock.activeSelf == false)
        {
            gliderRock.SetActive(true);
        }
        else
        {
            gliderRock.SetActive(false);
        }
    }
}
