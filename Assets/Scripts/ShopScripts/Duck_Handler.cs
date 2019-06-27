using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck_Handler : MonoBehaviour {
    public GameObject shopkeeper;
    Shopkeeper_Script textHandler;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnMouseDown()
    {
        textHandler = (Shopkeeper_Script)shopkeeper.GetComponent(typeof(Shopkeeper_Script));
        textHandler.quack();
    }
}
