using UnityEngine;
using System.Collections;

public class MoveTowards : MonoBehaviour
{
    public float speed = 1.0f;  
    public Vector3 distance;
    public bool finished = false;

    private Vector3 point;

	// Use this for initialization
	void Start () 
    {
        point = transform.position + distance;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        if (!finished)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, point, step);
        }

        if (Vector3.Distance(transform.position, point) < 0.01f)
            finished = true;
	}
}
