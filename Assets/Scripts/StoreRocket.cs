using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreRocket : MonoBehaviour {

    public GameObject rocketRock;
	public void ShowRocket()
    {
        if (rocketRock.activeSelf == false)
        {
            rocketRock.SetActive(true);
        }
        else
        {
            rocketRock.SetActive(false);
        }
    }
}
