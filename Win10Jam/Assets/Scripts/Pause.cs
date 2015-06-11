using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

    public bool GamePaused = false;

    public GameObject[] PauseMenu;

	// Use this for initialization
	void Start () 
    {
        foreach (GameObject go in PauseMenu)
        {
            go.SetActive(false);
        }
        
	}
	

    public void PauseGame()
    {
        GamePaused = !GamePaused;

        if (GamePaused)
        {
            Time.timeScale = 0;
            foreach (GameObject go in PauseMenu)
            {
                go.SetActive(true);
            }
        }
        else
        {
            Time.timeScale = 1;
            foreach (GameObject go in PauseMenu)
            {
                go.SetActive(false);
            }
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
