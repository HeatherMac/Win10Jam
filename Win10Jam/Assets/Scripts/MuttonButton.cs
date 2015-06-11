using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MuttonButton : MonoBehaviour {

    bool muted = false;
    public Sprite mute;
    public Sprite unmute;
    public GameObject SoundButtons;

	// Use this for initialization
	void Start () {
     
        DontDestroyOnLoad(this);
        //this.GetComponentInChildren<GUITexture>().texture = mute;
        this.GetComponentInChildren<Image>().sprite = mute;

        this.GetComponent<Canvas>().worldCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Click()
    {
        muted = !muted;
        SoundBehaviour.Instance.Mute(muted);
        if (muted)
        {
            SoundButtons.GetComponent<Image>().sprite = unmute;
            //this.GetComponentInChildren<GUITexture>().texture = unmute;
        }
        else
        {
            //this.GetComponentInChildren<GUITexture>().texture = mute;
            SoundButtons.GetComponent<Image>().sprite = mute;
        }
    }
}
