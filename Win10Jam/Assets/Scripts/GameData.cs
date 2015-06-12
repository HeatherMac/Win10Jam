using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData : MonoBehaviour {

    private static GameData _GData;

    public static int WindowsLost = 10;
    public static int WindowsSaved = 20;
    public static int TotalCracks = 10;
    public static int CracksRepaired = 30;
    public static int CarsSaved = 20;
    public static int CarsLost = 10;
    public static int FiresExtinguished = 30;
    public static int BridgesSaved = 10;


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
