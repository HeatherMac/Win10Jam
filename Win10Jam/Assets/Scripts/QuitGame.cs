using UnityEngine;
using System.Collections;

public class QuitGame : MonoBehaviour {

    void OnMouseDown()
    {
        Quit();
    }

    void Quit()
    {
        Application.Quit();
    }
}
