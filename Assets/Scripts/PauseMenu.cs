using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {
    public GameObject pauseMenu;
    public GameObject joistyx;

    public static bool GameIsPaused = false;
    // Use this for initialization
    void Start ()
    {
        Resume();
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void Resume()
    {
        pauseMenu.SetActive(false);
       // joistyx.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
       // joistyx.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
