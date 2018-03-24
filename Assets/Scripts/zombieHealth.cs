using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieHealth : MonoBehaviour {

    public int health;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            health -= 5;
        }
    }
}
