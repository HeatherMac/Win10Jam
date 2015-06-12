using UnityEngine;
using System.Collections;

public class ParallaxScroll : MonoBehaviour {

    public float Speed = 1.0f;
    float currentSpeed;


    float YLoc;

    public GameObject LayerA;
    public GameObject LayerB;

    GameObject CurrentLayer;
    GameObject OffScreenLayer;
    GameObject ParallaxStop;
    GameObject ParallaxStart;

    bool PauseScroll = false;
    public bool Reversed = false;
    public bool Sky = false;

    // Use this for initialization
    void Start() {

        ParallaxStop = GameObject.Find("ParallaxStop");
        ParallaxStart = GameObject.Find("ParallaxStart");

        currentSpeed = Speed;

        CurrentLayer = LayerA;
        OffScreenLayer = LayerB;

        YLoc = CurrentLayer.transform.position.y;

    }

    // Update is called once per frame
    void FixedUpdate() {

        CurrentLayer.transform.position = new Vector3(CurrentLayer.transform.position.x - currentSpeed, YLoc, CurrentLayer.transform.position.z);
        OffScreenLayer.transform.position = new Vector3(OffScreenLayer.transform.position.x - currentSpeed, YLoc, OffScreenLayer.transform.position.z);

        if (Reversed)
        {
            if (CurrentLayer.transform.position.x < (ParallaxStop.transform.position.x + 200))
            {
                CurrentLayer.transform.position = new Vector3(ParallaxStart.transform.position.x + 200, YLoc, CurrentLayer.transform.position.z);

                GameObject temp = CurrentLayer;
                CurrentLayer = OffScreenLayer;
                OffScreenLayer = temp;

            }
        }
        else
        {
            if (CurrentLayer.transform.position.x < ParallaxStop.transform.position.x)
            {
                CurrentLayer.transform.position = new Vector3(ParallaxStart.transform.position.x, YLoc, CurrentLayer.transform.position.z);

                GameObject temp = CurrentLayer;
                CurrentLayer = OffScreenLayer;
                OffScreenLayer = temp;

            }
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
        if (!Sky)
        {
            PauseScroll = !PauseScroll;
        }
    } 
}
