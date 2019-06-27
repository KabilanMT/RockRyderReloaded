using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnItem : MonoBehaviour {

    System.Random ran;
    public GameObject boostPowerupPrefab;
    public GameObject fuelPowerupPrefab;
    public GameObject obstaclePrefab;
    public Transform ryder;
    private List<GameObject> availableItems;
    private int availableItemLength = 0;
    private float obstacleCheckRadius = 5f;
    private int numberOfItems = 0;
    private float spawnDelay = 3f;
    private float timeSinceLastSpawn = 0f;

    // Use this for initialization
    void Start () {
        ran = new System.Random();
        availableItems = new List<GameObject>();
        if (boostPowerupPrefab != null)
        {
            availableItems.Add(boostPowerupPrefab);
        }
        if (fuelPowerupPrefab != null)
        {
            availableItems.Add(fuelPowerupPrefab);
        }
        if (obstaclePrefab != null)
        {
            availableItems.Add(obstaclePrefab);
        }
    }

	// Update is called once per frame
	void Update () {
        int randomPosition = ran.Next(0, 4);
        print(randomPosition);
        int randomItem = ran.Next(0, availableItems.Count);
        if (timeSinceLastSpawn >= spawnDelay)
        {
            timeSinceLastSpawn = 0;

            Rigidbody newItem;
            bool validPosition = true;
            Vector3 posNew = Vector3.zero;
            posNew = Camera.main.ViewportToWorldPoint(posNew);
            posNew.x = ryder.position.x;
            posNew.z = posNew.z - 25;
            if (!(availableItems[randomItem].name.Contains("Obstacle")))
            {
                if (randomPosition % 2 == 0)
                {
                    posNew.y += ran.Next(1, 4);
                }
                else
                {
                    posNew.y -= ran.Next(1, 4);
                }
                if (posNew.y <= -2)
                {
                    posNew.y += ran.Next(5, 8);
                }
            }
            else
            {
                if (randomPosition % 3 == 0)
                {
                    //No change
                }
                else if (randomPosition % 2 == 0)
                {
                    posNew.y -= ran.Next(1, 4);
                }
                else
                {
                    posNew.y -= ran.Next(1, 4);
                }
                if (posNew.y <= -2)
                {
                    posNew.y += ran.Next(5, 8);
                }
            }
            //Item spawn location is true until proven otherwise
            Collider[] colliders = Physics.OverlapSphere(posNew, obstacleCheckRadius);
            foreach (Collider col in colliders)
            {
                // If this collider is tagged "Powerup" or "Obstacle"
                if (col.tag.Contains("Powerup") || col.tag.Contains("Obstacle"))
                {
                    // Then this position is not a valid spawn position
                    validPosition = false;
                }
            }

            if (validPosition)
            {
                // Spawn the obstacle here
                newItem = Instantiate(availableItems[randomItem].GetComponent<Rigidbody>(), posNew, availableItems[randomItem].transform.rotation);
                newItem.gameObject.SetActive(true);
            }
        }
        else
        {
            timeSinceLastSpawn += 0.03f;
        }
    }
}
