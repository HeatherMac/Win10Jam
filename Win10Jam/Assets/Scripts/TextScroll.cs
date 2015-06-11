using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextScroll : MonoBehaviour {

    Text TextBox;

    int currentPos = 0;
    public float Delay = 0.05f;
    string Text = "";
    string[] additionalLines;

    public GameObject buttons;

    void WriteText(string p_Text)
    {
        TextBox.text = "";
        currentPos = 0;
        Text = p_Text;
        StartCoroutine(ScrollText());
    }


    IEnumerator ScrollText()
    {
        
        while (currentPos < Text.Length)
        {
            TextBox.text += Text[currentPos++];
            yield return new WaitForSeconds(Delay);
        }


        ScrollTextComplete();


    }

    void ScrollTextComplete()
    {
        buttons.SetActive(true);
    }

	// Use this for initialization
	void Start () {
        buttons.SetActive(false);
       
	}

    void OnEnable()
    {
        buttons.SetActive(false);
        TextBox = transform.GetComponent<Text>();

        WriteText(TextBox.text);

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
