using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour {


    public int health;
   // public GameObject Player = GameObject.FindGameObjectWithTag("Player");

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
            Handheld.Vibrate();
            SceneManager.LoadScene("Menu");
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "attackBlock(Clone)")
        {
            health -= 5;
        }
    }
}
