using UnityEngine;
using System.Collections;

public class PutOutFire : MonoBehaviour
{
    public GameObject steam;

    private int tapsToKill = 5;

	// Use this for initialization
	void Start ()
    {

        steam.transform.position = transform.position;	
    
	}
	
	// Update is called once per frame
	void Update () {

        steam.transform.position = transform.position;	
	}
	



    void OnMouseDown()
    {

        GameData.FiresExtinguished++;
        
        tapsToKill--;

        steam.GetComponent<ParticleSystem>().Play();

        if (tapsToKill == 0)
            Destroy(gameObject);
    }
}
