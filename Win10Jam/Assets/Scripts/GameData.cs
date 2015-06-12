using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameData : MonoBehaviour {

    private static GameData _GData;

    public static int WindowsLost = 0;
    public static int WindowsSaved = 400;
    public static int TotalCracks = 0;
    public static int CracksRepaired = 0;
    public static int CarsSaved = 2;
    public static int CarsLost = 0;
    public static int FiresExtinguished = 0;
    public static int BridgesSaved = 1;


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
