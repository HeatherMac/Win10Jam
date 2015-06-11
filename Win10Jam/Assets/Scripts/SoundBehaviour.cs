using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]

public class SoundBehaviour : MonoBehaviour
{

    public enum sources
    {
        Music,
        Bounce,
        Coin,
        Jump,
        Rocket,
        Teleporter,
        Walk

    }
    public AudioClip CurrentlyPlaying;

   
    public void PlaySong(AudioClip track)
    {
        CurrentlyPlaying = track;
        audioSource[(int)sources.Music].clip = CurrentlyPlaying;
        audioSource[(int)sources.Music].Play();

    }
    
    
    private static SoundBehaviour instance = null;
    public static SoundBehaviour Instance
    {
        get { return instance; }
    }

    AudioSource[] audioSource;
    public AudioClip Bounce;
    public AudioClip Coin;   
    public AudioClip Jump;  
    public AudioClip Rocket;
    public AudioClip Teleporter;
    public AudioClip Walking;

    public void CoinPickupSound()
    {
        audioSource[(int)sources.Coin].clip = Coin;
        audioSource[(int)sources.Coin].Play();

    }
    public void JumpSound()
    {
        audioSource[(int)sources.Jump].clip = Jump;
        audioSource[(int)sources.Jump].Play();
    }
    public void TeleporterSound()
    {
        audioSource[(int)sources.Teleporter].clip = Teleporter;
        audioSource[(int)sources.Teleporter].Play();
    }
    public void WalkSound()
    {
        audioSource[(int)sources.Walk].clip = Walking;
        audioSource[(int)sources.Walk].Play();
    }
    public void BounceSound()
    {
        audioSource[(int)sources.Bounce].clip = Bounce;
        audioSource[(int)sources.Bounce].Play();

    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        audioSource = GetComponents<AudioSource>();
    }


    public AudioClip[] Tracks;


    void Start()
    {   
        DontDestroyOnLoad(this.gameObject);  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!audioSource[(int)sources.Music].isPlaying && Application.loadedLevelName != "MainMenuScene" && Application.loadedLevelName != "LevelTreeFinal")
        {
            Debug.Log(Application.loadedLevelName);
            PlaySong(Tracks[Random.Range(0, Tracks.Length - 1)]);
            Debug.Log("change track");
        }
        else if (Application.loadedLevelName == "LevelTreeFinal")
        {
            Mute(true);
        }
    }

   

     public void Mute(bool mute)
    {
        foreach (AudioSource audio in audioSource)
        {
            audio.mute = mute;
        }
    }
}
