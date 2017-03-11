using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public string mainMenu;
    public bool isPaused;
    public GameObject pauseMenuCanvas;
    Player playerScript;
    CameraController camScript;


	void Start ()
    {
        camScript = FindObjectOfType<CameraController>();
        playerScript = FindObjectOfType<Player>();
        isPaused = false;
	}


	void Update ()
    {
		if (isPaused)
        {
            playerScript.enabled = false;
            camScript.enabled = false;
            pauseMenuCanvas.SetActive(true);
            Time.timeScale = 0f;           
        }
        else
        {
            pauseMenuCanvas.SetActive(false);
            Time.timeScale = 1f;
            playerScript.enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            Debug.Log("esc pressed");
        }
	}


    public void Resume()
    {
        isPaused = false;
        Debug.Log("resume pressed");
        playerScript.enabled = true;
        camScript.enabled = true;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
