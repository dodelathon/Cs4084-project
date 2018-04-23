using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {


    public int health;
    public Slider healthSlider;
    private GameObject gameController;
    private GameObject keeper;

    // Use this for initialization
    void Start ()
    {
        gameController =  GameObject.Find("GameController");
        keeper = GameObject.Find("ScoreKeeper");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(health <= 0)
        {
            ScoreContainer.container.addScore(gameController.GetComponent<GameController>().getScore());
            Destroy(gameObject);
            Handheld.Vibrate();
            SceneManager.LoadScene("LeaderBoard");
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "attackBlock(Clone)")
        {
            health -= 5;
            updateSlider();
        }
    }

    public void addHealth(int amount)
    {
        if(health == 100)
        {
            amount = 0;
        }
        else
        {
            if(health + amount > 100)
            {
                amount = (health + amount) - 100;
                health += amount;
                ScoreContainer.container.addGatheredH(amount);
            }
            else
            {
                health += amount;
                ScoreContainer.container.addGatheredH(amount);
            }
            updateSlider();
        }
    }

    void updateSlider()
    {
        healthSlider.value = health;
    }
}

