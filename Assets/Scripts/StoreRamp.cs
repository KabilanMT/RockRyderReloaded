using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreRamp : MonoBehaviour {

    public GameObject rampUpgrade;
    public void ShowRamp()
    {
        if (rampUpgrade.activeSelf == false)
        {
            rampUpgrade.SetActive(true);
        }
        else
        {
            rampUpgrade.SetActive(false);
        }
    }
}
