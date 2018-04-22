using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Holds the prefabs for Zombies and healthboxes
    public GameObject zombieModel;
    public GameObject healthModel;

    //arrays that hold all available spawns on a given map
    private GameObject[] ZombSpawns;
    private GameObject[] healthSpawns;

    // Use this for initialization
    void Start ()
    {
        //locates all the spawns on a map with the appropriate tags
        ZombSpawns = GameObject.FindGameObjectsWithTag("ZombieSpawn");
        healthSpawns = GameObject.FindGameObjectsWithTag("HealthSpawn");
    }


    public void zombieSpawner(int choice)
    {
        if (choice == 1)
        {
            var zombie = Instantiate(zombieModel, ZombSpawns[0].transform.position, new Quaternion(0, 0, 0, 0));
        }
        else if (choice == 2)
        {
            var zombie = Instantiate(zombieModel, ZombSpawns[1].transform.position, new Quaternion(0, 0, 0, 0));
        }
        else if (choice == 3)
        {
            var zombie = Instantiate(zombieModel, ZombSpawns[2].transform.position, new Quaternion(0, 0, 0, 0));
        }
        else
        {
            var zombie = Instantiate(zombieModel, ZombSpawns[3].transform.position, new Quaternion(0, 0, 0, 0));
        }
    }

    public void healthSpawner(int spawn)
    {
        if (spawn == 1)
        {
            var healthBox = Instantiate(healthModel, healthSpawns[0].transform.position, new Quaternion(0, 0, 0, 0));
        }
        else
        {
            var healthBox = Instantiate(healthModel, healthSpawns[1].transform.position, new Quaternion(0, 0, 0, 0));
        }

    }

    public GameObject GetSpawns(char choice, int index)
    {
        bool found = false;
        if (choice == 'z' || choice == 'Z')
        {
            for (int i = 0; i < ZombSpawns.Length && found == false; i++)
            {
                if (index == i)
                {
                    found = true;
                    return ZombSpawns[i];
                }
            }
            //return null;
        }
        else if (choice == 'h' || choice == 'H')
        {
            for (int i = 0; i < healthSpawns.Length && found == false; i++)
            {
                if (index == i)
                {
                    found = true;
                    return healthSpawns[i];
                }
            }
            //return null;
        }
        return null;
    }
}
