using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowClick : MonoBehaviour {

    public GameObject shopkeeper;
    Shopkeeper_Script textHandler;

    private void Start()
    {
        textHandler = (Shopkeeper_Script)shopkeeper.GetComponent(typeof(Shopkeeper_Script));
    }
    private void OnMouseDown()
    {
        textHandler.set_wife();
    }
}
