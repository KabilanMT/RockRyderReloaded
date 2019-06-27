using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour {
    private int counter;
    private bool onetime;
    

    void Start()
    {
        counter = 0;
        onetime = false;
    }
    void Update()
    {
        if (!onetime)
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                SubCount();
                onetime = true;
            }
            if (Input.GetAxis("Horizontal") > 0)
            {
                AddCount();
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

        if (counter > 2)
        {
            counter = 0;
        }
        else if (counter < 0)
        {
            counter = 2;
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
