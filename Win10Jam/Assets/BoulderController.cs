using UnityEngine;
using System.Collections;

public class BoulderController : MonoBehaviour {

    public int Lives = 5;

    public int HitPercentageReduction;

    public GameObject iceParts;

    SpriteRenderer SR;

    CircleCollider2D CC;

    float size;


	// Use this for initialization
	void Start () {

        SR = GetComponent<SpriteRenderer>();
        CC = GetComponent<CircleCollider2D>();
        size = CC.radius;	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.Rotate(new Vector3(0, 0, 1), 1);
	}

    void OnMouseDown()
    {
        Lives -= 1;

        iceParts.transform.position = transform.position;

        if (Lives < 1)
        {
            iceParts.GetComponent<ParticleSystem>().startSize *= 2f;
            Kill();
        }

        iceParts.GetComponent<ParticleSystem>().Play();

        float scale = transform.localScale.x;

        float random = Random.Range(-2, 2);

        scale -= (scale / (10 + random));

        transform.localScale = new Vector3(scale, scale);
    }

    void Kill()
    {
        Destroy(gameObject);
        Debug.Log("falsed");
    }
}
