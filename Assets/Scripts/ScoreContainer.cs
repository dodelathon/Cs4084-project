using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreContainer : MonoBehaviour
{
    public static ScoreContainer container;

    List<int> scores = new List<int>();

    // Use this for initialization
    void Awake ()
    {
        if(container == null)
        {
            container = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(container != this)
        {
            Destroy(gameObject);
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
