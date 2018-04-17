using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    // Use this for initialization
    public GameObject zombieModel;
    public Transform spawn1;
    public Transform spawn2;
    public Transform spawn3;
    public Transform spawn4;
    private float Timer;
    public float timeAdjust;
    private GameObject[] zombCount;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        zombCount = GameObject.FindGameObjectsWithTag("Zombie");
        int spawn = 0;
        Timer -= Time.deltaTime;
        if (zombCount.Length <= 20)
        {
            if (Timer < 0.0f)
            {
                Timer = timeAdjust;
                spawn = Random.Range(1, 4);
                spawner(spawn);
            }
        }
    }

    void spawner(int choice)
    {
        if (choice == 1)
        {
            var zombie = (GameObject)Instantiate(zombieModel, spawn1.position, new Quaternion(0, 0, 0, 0));
        }
        else if (choice == 2)
        {
            var zombie = (GameObject)Instantiate(zombieModel, spawn2.position, new Quaternion(0, 0, 0, 0));
        }
        else if (choice == 3)
        {
            var zombie = (GameObject)Instantiate(zombieModel, spawn3.position, new Quaternion(0, 0, 0, 0));
        }
        else
        {
            var zombie = (GameObject)Instantiate(zombieModel, spawn4.position, new Quaternion(0, 0, 0, 0));
        }
    }
}
