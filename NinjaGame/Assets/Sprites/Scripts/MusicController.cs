using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip levelMusic;
    public static MusicController instance = null;
    AudioSource source;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        PlayMenuMusic();
        if(GameInfoController.GetMusicVolume() == 0)
        {
            source.volume = 0.25f;
        }
        else
        {
            source.volume = GameInfoController.GetMusicVolume();
        }
        
        
        //mainMusic.volume = PlayerPrefsController.GetMasterVolume();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    static public void PlayMenuMusic()
    {
        if(instance != null)
        {
            if(instance.source != null && instance.source.clip != instance.menuMusic)
            {
                instance.source.Stop();
                instance.source.clip = instance.menuMusic;
                instance.source.Play();
            }
        }
    }
    static public void PlayGameMusic()
    {
        if (instance != null)
        {
            if (instance.source != null && instance.source.clip != instance.levelMusic)
            {
                instance.source.Stop();
                instance.source.clip = instance.levelMusic;
                instance.source.Play();
            }
        }
    }
    static public void ChangeMusicVolume(float value)
    {
        instance.source.volume = value;
    }
    static public float GetMusicVolume()
    {
        return instance.source.volume;
    }
    static public void StopMusic()
    {
        if (instance.source != null)
        {
            instance.source.Stop();
        }
    }

}
