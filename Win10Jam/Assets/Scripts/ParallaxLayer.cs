using UnityEngine;
using System.Collections;


public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;
    public bool staticY;
    float YClamp;

    void Start()
    {
        if (staticY)
        {
            YClamp = transform.position.y;
        }
    }

    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;

        transform.localPosition = newPos;
    }

    void Update()
    {
        if (staticY)
        {
            transform.position = new Vector3(transform.position.x, YClamp, transform.position.z);
        }
    }

}
