using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Destroy : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "FastZombie(Clone)")
        {
            Destroy(gameObject);
        }
        else if(collision.gameObject.name == "Walls")
        {
            Destroy(gameObject);
        }
    }
}
