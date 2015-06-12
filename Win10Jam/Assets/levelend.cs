using UnityEngine;
using System.Collections;

public class levelend : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
   public void end()
    {
        Application.LoadLevel("EndingScene");

    }
}
