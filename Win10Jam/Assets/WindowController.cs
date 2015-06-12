using UnityEngine;
using System.Collections;

public class WindowController : MonoBehaviour {


    bool CanShatter = false;
    static float chance = 0.01f;
    CrackController crackController;
	// Use this for initialization
	void Start () {
        crackController = GetComponentInChildren<CrackController>();
        //this fucking shit
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    void FixedUpdate()
    {
        if(chance > Random.value&&CanShatter)
        {
            crackController.Crack();           
        }
    }
    void OnMouseDown()
    {
        Debug.Log("click");
        crackController.fix();
    }
  void OnTriggerEnter2D(Collider2D col)
    {
        
        if(col.gameObject.name == "SmashableArea")
        {
            CanShatter = true;
        }

    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name == "SmashableArea")
        {
            CanShatter = false;

        }
    }
}
