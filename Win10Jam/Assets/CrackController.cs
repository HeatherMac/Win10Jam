using UnityEngine;
using System.Collections;

public class CrackController : MonoBehaviour {

    public enum WindowState
    {
        Fixed,
        Crack1,
        Crack2,
        Crack3,
        Broken
    }
    WindowState state;
   public Sprite Crack1;
    public Sprite Crack2;
    public Sprite Crack3;
    public Sprite Crack4;
    public GameObject glassShatter;
    SpriteRenderer spriteRenderer;
        
	// Use this for initialization
	void Start () {
        state = WindowState.Fixed;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        spriteRenderer.enabled = false;
	}
	
	
    public void Crack()
    {
        if(state != WindowState.Broken)
        {
            state++;
            GameData.TotalCracks++;
            updateRenderer();
            if (state == WindowState.Broken)
            {
                GameData.WindowsLost++;
                Instantiate(glassShatter, transform.position, Quaternion.identity);
                Debug.Log("shatttered");

            }
        }
      
    }
    public void fix()
    {
     
        if(state!= WindowState.Fixed &&state != WindowState.Broken)
        {
            state = WindowState.Fixed;
            updateRenderer();
        }
    }
    private void updateRenderer()
    {
        switch (state)
        {
            case WindowState.Fixed:
                spriteRenderer.enabled = false;
                break;
            case WindowState.Crack1:
                spriteRenderer.enabled = true;
                spriteRenderer.sprite = Crack1;
                break;
            case WindowState.Crack2:
                spriteRenderer.enabled = true;
                spriteRenderer.sprite = Crack2;
                break;
            case WindowState.Crack3:
                spriteRenderer.enabled = true;
                spriteRenderer.sprite = Crack3;
                break;
            case WindowState.Broken:
                spriteRenderer.enabled = true;
                spriteRenderer.sprite = Crack4;
                break;
        }
    }

}
