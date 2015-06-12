using UnityEngine;
using System.Collections;

public class LightningSpawner : MonoBehaviour
{
    public GameObject[] LightningSprites;
    public GameObject mainCamera;
    public GameObject flash;

    private float camMinX;
    private float camMaxX;
    private float camY;
    

	// Use this for initialization
	void Start ()
    {
        float height = 2f * mainCamera.GetComponent<Camera>().orthographicSize;
        float width = height * mainCamera.GetComponent<Camera>().aspect;

        camY = mainCamera.transform.position.y;
        camMinX = mainCamera.transform.position.x - width / 2;
        camMaxX = mainCamera.transform.position.x + width / 2;

        StartCoroutine(Timer());
    }
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    IEnumerator Timer()
    {
        float wait = Random.Range(1f, 5f);

        yield return new WaitForSeconds(wait);

        SpawnLightning();

        StartCoroutine(Timer());
    }

    IEnumerator DestroyLightning(GameObject go)
    {
        yield return new WaitForSeconds(0.1f);

        flash.SetActive(false);
    }

    void SpawnLightning()
    {
        int index = Random.Range(0, LightningSprites.Length);
        float x = Random.Range(camMinX, camMaxX);



        GameObject go = (GameObject)Instantiate(LightningSprites[index], new Vector3(x, camY), Quaternion.identity);

        flash.SetActive(true);

        StartCoroutine(DestroyLightning(go));
    }
}
