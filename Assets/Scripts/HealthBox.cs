using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour {

    // Use this for initialization
    private GameObject player;
    public int addAmount;

	void Start ()
    {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            player.GetComponent<playerHealth>().addHealth(addAmount);
            Destroy(gameObject);
        }
    }
}
