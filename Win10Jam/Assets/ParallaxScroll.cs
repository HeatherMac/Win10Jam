using UnityEngine;
using System.Collections;

public class ParallaxScroll : MonoBehaviour {

    public float Speed = 1.0f;
    public float cutoff = -200f;
    float currentSpeed;

    float offset = 0;

    float YLoc;

    public GameObject LayerA;
    public GameObject LayerB;

    GameObject CurrentLayer;
    GameObject OffScreenLayer;

    public bool PauseScroll = false;

	// Use this for initialization
	void Start () {

        currentSpeed = Speed;

        CurrentLayer = LayerA;
        OffScreenLayer = LayerB;

        cutoff = (CurrentLayer.transform.position.x - 210.0f);
        YLoc = CurrentLayer.transform.position.y;

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        CurrentLayer.transform.position = new Vector3(CurrentLayer.transform.position.x - currentSpeed, YLoc, CurrentLayer.transform.position.z);
        OffScreenLayer.transform.position = new Vector3(OffScreenLayer.transform.position.x - currentSpeed, YLoc, OffScreenLayer.transform.position.z);

        if (CurrentLayer.transform.position.x < cutoff)
        {
            CurrentLayer.transform.position = new Vector3(CurrentLayer.transform.position.x + 400.0f, YLoc, CurrentLayer.transform.position.z);

            GameObject temp = CurrentLayer;
            CurrentLayer = OffScreenLayer;
            OffScreenLayer = temp;

        }



        if (PauseScroll)
        {
            currentSpeed = Mathf.Lerp(currentSpeed, 0, 0.1f);
        }
        else
        {
            currentSpeed = Mathf.Lerp(currentSpeed, Speed, 0.1f);
        }
	}

    public void Pause()
    {
        PauseScroll = !PauseScroll;
    }
}
