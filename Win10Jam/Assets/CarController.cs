using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

    SpriteRenderer SR;
    BoxCollider2D BC;

    Sprite Car;
    public Sprite BrockCar;
    public Color32 BCColour;


	// Use this for initialization
	void Start () {

        SR = GetComponent<SpriteRenderer>();
        BC = GetComponent<BoxCollider2D>();

        Car = SR.sprite;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D Col)
    {
        Debug.Log("@Collided");
        if (Col.gameObject.name == "IceBoulder")
        {
            Kill();
        }
    }

    void Kill()
    {
        BC.enabled = false;
        SR.sprite = BrockCar;
        SR.color = BCColour;

        //Lose a life?
        //Add fire
    }
}
