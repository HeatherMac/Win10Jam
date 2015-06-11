using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData : MonoBehaviour {

    private static GameData _GData;

    public static int PickupsCollected = 0;
    public static List<string> LevelChoiceList = new List<string>();

    public static int CharacterChoice = 1;

    public static string NextCutSceneToLoad = "null";

    public static string PlayerName;

    public static string LevelRoute;

    public static string CharacterSector;

    public static int CoinsCollected;

    public static int ItemsCollected;


    public static GameData GData
    {
        get 
        {
            if (_GData == null)
            {
                _GData = GameObject.FindObjectOfType<GameData>();

                DontDestroyOnLoad(_GData.gameObject);
            }
            return _GData;
        }
    }

	// Use this for initialization
	void Awake () 
    {
        if (_GData == null)
        {
            _GData = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if(this != _GData)
            {
                Destroy(this.gameObject);
            }
        }


	}
}
