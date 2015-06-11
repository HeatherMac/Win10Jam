using UnityEngine;
using System.Collections;

public class Singleton : MonoBehaviour {

    public static Singleton _Singleton;


    public static Singleton SG
    {
        get
        {
            if (_Singleton == null)
            {
                _Singleton = GameObject.FindObjectOfType<Singleton>();

                DontDestroyOnLoad(_Singleton.gameObject);
            }
            return _Singleton;
        }
    }

    // Use this for initialization
    void Awake()
    {
        if (_Singleton == null)
        {
            _Singleton = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            if (this != _Singleton)
            {
                Destroy(this.gameObject);
            }
        }


    }
}
