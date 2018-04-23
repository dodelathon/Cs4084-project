using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private GameObject scoreTextRef;

    //variables that are used to control the spawning
    private float Timer;
    private float healthTimer;
    public float timeAdjust;
    public float HealthTimeAdjust;

    public bool spawnZ;
    public bool spawnH;

    //count arrays that allow us to limit the amount of zombies on the field
    private GameObject[] zombCount;
    private GameObject[] healthCount;

    //Player score keeping
    Text scoreText;
    private int score;

    // Use this for initialization
    void Start()
    { 
        score = 0;
        scoreTextRef = GameObject.Find("ScoreDisplay");
        scoreText = scoreTextRef.GetComponent<Text>();
        updateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        spawnManager();
    }

    void spawnManager()
    {
        zombCount = GameObject.FindGameObjectsWithTag("Zombie");
        healthCount = GameObject.FindGameObjectsWithTag("Health");
        int spawn = 0, HSpawn = 0;
        if (zombCount.Length <= 20 && spawnZ)
        {
            Timer -= Time.deltaTime;
            if (Timer <= 0.0f)
            {
                Timer = timeAdjust;
                spawn = Random.Range(1, 5);
                gameObject.GetComponent<Spawner>().zombieSpawner(spawn);
            }
        }
        if (healthCount.Length < 2 && spawnH)
        {
            healthTimer -= Time.deltaTime;
            if (healthTimer <= 0.0)
            {
                healthTimer = HealthTimeAdjust;
                if (healthCount.Length == 1)
                {
                    GameObject healthSpawn = gameObject.GetComponent<Spawner>().GetSpawns('H', 0);
                    if (healthCount[0].transform.position == healthSpawn.transform.position)
                    {
                        gameObject.GetComponent<Spawner>().healthSpawner(2);
                    }
                    else
                    {
                        gameObject.GetComponent<Spawner>().healthSpawner(1);
                    }
                }
                else
                {
                    HSpawn = Random.Range(1, 3);
                    gameObject.GetComponent<Spawner>().healthSpawner(HSpawn);
                }
            }
        }
    }
    
    //Updates the score and then call the update display method
    public void updateScore(int scoreUpdater)
    {
        score += scoreUpdater;
        updateDisplay();
    }

    public int getScore()
    {
        return score;
    }

    //Update the in game display. 
    void updateDisplay()
    {
        scoreText.text = "Score: " + score;
    }
}
