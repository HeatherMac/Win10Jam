using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject[] PauseObjects;
    public bool PauseMenu = false;

    private bool paused = false;

	// Use this for initialization
	void Start ()
    {
        if (PauseMenu)
            DontDestroyOnLoad(transform.gameObject);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !paused)
        {
            foreach (GameObject go in PauseObjects)
                go.SetActive(true);

            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
            Resume();
	}    

    public void Play()
    {
        Application.LoadLevel("TomScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void QuitToMenu()
    {
        Application.LoadLevel("MainMenu");
    }

    public void Resume()
    {
        foreach (GameObject go in PauseObjects)
            go.SetActive(false);

        Time.timeScale = 1;
    }
}
