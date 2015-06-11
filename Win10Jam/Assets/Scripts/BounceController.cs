using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class BounceController : MonoBehaviour {


    public float Bounciness;
    SpriteRenderer SR;
    BoxCollider2D Collider;
    PhysicsMaterial2D Mat;

    public bool ChangeColour;
	// Use this for initialization
	void Start () {

        Collider = GetComponent<BoxCollider2D>();

        Mat = new PhysicsMaterial2D("Bounce");

        Mat.bounciness = Bounciness;
        Mat.friction = 0.4f;

        Collider.sharedMaterial = Mat;

        SR = GetComponent<SpriteRenderer>();

        float colour = 0.2f;

        if (ChangeColour)
        {

            colour *= Bounciness;

            colour = 1 - colour;

            SR.color = new Color(1.0f, colour, colour);
        }

        Collider.enabled = false;

        Collider.enabled = true;
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            SoundBehaviour.Instance.BounceSound();

        }

    }
}
