using UnityEngine;
using System.Collections;

public class ParallaxScroll : MonoBehaviour {

    public float Speed = 1.0f;
    public float cutoff = -200f;

    float offset = 0;

    public GameObject LayerA;
    public GameObject LayerB;

    GameObject CurrentLayer;
    GameObject OffScreenLayer;

	// Use this for initialization
	void Start () {

        

        CurrentLayer = LayerA;
        OffScreenLayer = LayerB;

        cutoff = (CurrentLayer.transform.position.x - 210.0f);

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        CurrentLayer.transform.position = new Vector3(CurrentLayer.transform.position.x - Speed, CurrentLayer.transform.position.y, CurrentLayer.transform.position.z);
        OffScreenLayer.transform.position = new Vector3(OffScreenLayer.transform.position.x - Speed, OffScreenLayer.transform.position.y, OffScreenLayer.transform.position.z);

        if (CurrentLayer.transform.position.x < cutoff)
        {
            CurrentLayer.transform.position = new Vector3(CurrentLayer.transform.position.x + 400.0f, CurrentLayer.transform.position.y, CurrentLayer.transform.position.z);

            GameObject temp = CurrentLayer;
            CurrentLayer = OffScreenLayer;
            OffScreenLayer = temp;

        }

	}
}
