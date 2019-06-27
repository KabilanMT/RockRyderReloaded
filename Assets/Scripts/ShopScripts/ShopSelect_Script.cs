using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSelect_Script : MonoBehaviour {
    private int counter;
    private bool onetime;
    public bool preshop;
	
    void Start()
    {
        counter = 0;
        onetime = false;
        preshop = true;
    }
    void Update()
    {
        if (!preshop)
        {
            if (!onetime)
            {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    AddCount();
                    onetime = true;
                }
                if (Input.GetAxis("Horizontal") > 0)
                {
                    SubCount();
                    onetime = true;
                }
            }
            else if (onetime)
            {
                if (Input.GetAxis("Horizontal") == 0)
                {
                    onetime = false;
                }
            }
        }

        if (counter > 5)
        {
            counter = 0;
        }
        else if (counter < 0)
        {
            counter = 5;
        }
    }
    public void AddCount()
    {
        counter += 1;
    }

    public void SubCount()
    {
        counter -= 1;
    }

    public int GetCount()
    {
        return counter;
    }
}
