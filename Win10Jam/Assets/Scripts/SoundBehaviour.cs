using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]

public class SoundBehaviour : MonoBehaviour
{

    public enum sources
    {
        Music,
        GlassSmash,
        AmbientCity,
        Tap,
        Rain
    }

    public enum TapTypes
    {
        None,
        Fixing,
        Thud,
        BreakingHail
    }

    public AudioClip CurrentlyPlaying;

   
    public void PlayMusic(AudioClip track)
    {
        CurrentlyPlaying = track;
        audioSource[(int)sources.Music].clip = CurrentlyPlaying;
        audioSource[(int)sources.Music].Play();
        audioSource[(int)sources.Music].loop = true;
    }

    public void PlayRain()
    {
        audioSource[(int)sources.Rain].clip = Rain;
        audioSource[(int)sources.Rain].Play();
        audioSource[(int)sources.Rain].loop = true;
    }
    
    private static SoundBehaviour instance = null;
    public static SoundBehaviour Instance
    {
        get { return instance; }
    }


    static AudioSource[] audioSource;

    // audio

     public List<AudioClip> GlassSmashes1;
     public AudioClip AmbientCity1;
    public List<AudioClip> FixingTaps1;
     public AudioClip Rain1;

    static public List<AudioClip> GlassSmashes;
    static public AudioClip AmbientCity;
    static public List<AudioClip> FixingTaps;
    static public AudioClip Rain;
    //

    // random history
    static int  lastTap = -1;
    static int lastSmashed = -1;

    [System.Serializable]
    public struct AudioPair
    {
        public TapTypes key;
        public AudioClip value;
    }

    public static void SoundGlassSmash()
    {

        int i;
        if (lastSmashed == -1)
        {
            i = Random.Range(0, GlassSmashes.Count - 1);
        }
        else
        {
            do
            {
                i = Random.Range(0, GlassSmashes.Count - 1);
            } while (i == lastSmashed);
        }
        lastSmashed = i;
        audioSource[(int)sources.GlassSmash].clip = GlassSmashes[i];
        audioSource[(int)sources.GlassSmash].Play();
    }


    public static void SoundTap()
    {
        TapTypes tapType = TapTypes.Fixing;

        switch (tapType)
        {
            case TapTypes.None:
                break;
            case TapTypes.Fixing:
                int i;
                if(lastTap == -1)
                {
                    i = Random.Range(0, FixingTaps.Count - 1);
                }
                else
                {
                    do
                    {
                        i = Random.Range(0, FixingTaps.Count - 1);
                    } while (i == lastTap);
                }
                lastTap = i;
                audioSource[(int)sources.Tap].clip = FixingTaps[i];
                break;
            case TapTypes.Thud:
                break;
            case TapTypes.BreakingHail:
                break;
            default:
                break;
        }
        audioSource[(int)sources.Tap].Play();
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
        PlayMusic(Tracks[Random.Range(0, Tracks.Length - 1)]);
        

        GlassSmashes = GlassSmashes1;
        AmbientCity = AmbientCity1;
        FixingTaps = FixingTaps1;
        Rain = Rain1;

        PlayRain();
    }


    public AudioClip[] Tracks;


    void Start()
    {   
        DontDestroyOnLoad(this.gameObject);  
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    this.SoundGlassSmash();
        //}
        //else if (Input.GetKeyDown(KeyCode.S))
        //{
        //    this.SoundTap(TapTypes.Fixing);
        //}
    }

   

     public void Mute(bool mute)
    {
        foreach (AudioSource audio in audioSource)
        {
            audio.mute = mute;
        }
    }
}
