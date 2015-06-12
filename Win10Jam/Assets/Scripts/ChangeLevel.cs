using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

    public bool Mouse = false;
    public bool Text = false;
    public string LevelText = "null";

    string LevelToLoad = "null";
	// Use this for initialization
	void Start () {

        LevelToLoad = GameData.NextCutSceneToLoad;
        if (LevelText == "null")
        {
            LevelText = LevelToLoad;
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D Col)
    {     
        //any other necessary level ending code
        //SoundBehaviour.Instance.TeleporterSound();
        if (Col.name == "Player")
        {
            if (Text)
            {
                if (LevelText != "null")
                {
                    Debug.Log("loading level");
                    Application.LoadLevel(LevelText);
                }
                else
                {
                    Debug.Log("No Level Data");
                }
            }
            else
            {
                if (LevelToLoad != "null")
                {
                    Debug.Log("loading level");
                    Application.LoadLevel(LevelToLoad);
                }
                else
                {
                    Debug.Log("No Level Data");
                }
            }
        }
    }

    void OnMouseDown()
    {
        if (Mouse)
        {
            if (LevelText != "null")
            {
                Debug.Log("loading level");
                Application.LoadLevel(LevelText);
            }
            else
            {
                Debug.Log("No Level Data");
            }
        }
    }
}
