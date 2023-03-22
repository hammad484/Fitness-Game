using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplaySoundController : MonoBehaviour
{
    #region Instance

    private static GameplaySoundController _instance;

    public static GameplaySoundController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameplaySoundController>();
            }

            return _instance;
        }
    }

    #endregion


    private void OnEnable()
    {
        DataController.sfxVolumeChanged += sfxVolumeChanged;
        DataController.musicVolumeChanged += musicVolumeChanged;
        GameController.gamePaused += gamePaused;
        GameController.gameResumed += gameResumed;
        GameController.gameRestarted += gameRestarted;
    }

    private void OnDisable()
    {
        DataController.sfxVolumeChanged -= sfxVolumeChanged;
        DataController.musicVolumeChanged -= musicVolumeChanged;
        
        GameController.gamePaused -= gamePaused;
        GameController.gameResumed -= gameResumed;
        GameController.gameRestarted -= gameRestarted;
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        CreatePool();


        if (musicSounds.Length > 0)
        {
            audioMusic.loop = true;
            audioMusic.volume = 0.6f;
            audioMusic.clip = musicSounds[Random.Range(0, musicSounds.Length)];
            audioMusic.Play();
        }
        
        CreateChatter();
        
        if (DataController.instance)
        {
            sfxVolumeChanged(DataController.instance.sfxVolume);
            musicVolumeChanged(DataController.instance.musicVolume);
        }
    }

    public void CreateChatter()
    {
        GameObject gameObject = new GameObject();
        gameObject.transform.SetParent(transform);
        gameObject.name = "Chatter Voice";
        gameObject.AddComponent<AudioSource>();
        gameObject.GetComponent<AudioSource>().volume = 0.15f;
        gameObject.GetComponent<AudioSource>().outputAudioMixerGroup= audioMusic.outputAudioMixerGroup  ;

        chatterMusic = gameObject.GetComponent<AudioSource>();
        PlayChatter();
    }

    public void PlayChatter()
    {
        
        if (chatterSounds.Length > 0)
        {
            chatterMusic.clip = chatterSounds[chatterIndex];
            float volume = Random.Range(0.15f, 0.3f);
            chatterMusic.volume =volume * DataController.instance.sfxVolume;
            chatterMusic.Play();
            Invoke("NextChatter", chatterSounds[chatterIndex].length + Random.Range(2f,4f));
            chatterIndex++;

            if (chatterIndex >= chatterSounds.Length)
            {
                chatterIndex = 0;
            }
            
        }
    }

    void NextChatter()
    {
        PlayChatter();
    }

    public void CreatePool()
    {
        GameObject gameObject = new GameObject();
        gameObject.name = "AudioPool";
        audioList = new Dictionary<AudioLibrary, GameAudioPool>();
        foreach (GameAudioPool audioPool in pool)
        {
            audioPool.length = audioPool.clips.Length;
            audioPool.sources = new AudioSource[audioPool.length];
            for (int j = 0; j < audioPool.length; j++)
            {
                AudioClip audioClip = audioPool.clips[j];
                GameObject gameObject2 = new GameObject();
                gameObject2.name = audioClip.name;
                gameObject2.transform.parent = gameObject.transform;
                gameObject2.AddComponent<AudioSource>();
                gameObject2.GetComponent<AudioSource>().clip = audioClip;
                audioPool.sources[j] = gameObject2.GetComponent<AudioSource>();
            }

            audioList[audioPool.type] = audioPool;
        }
    }

    public void playFromPool(AudioLibrary audioType)
    {
        audioList[audioType].play();
    }

    public void sfxVolumeChanged(float newVolume)
    {
        sfxVolume = newVolume;
        foreach (KeyValuePair<AudioLibrary, GameAudioPool> keyValuePair in audioList)
        {
            keyValuePair.Value.setVolume(newVolume);
        }

        foreach (AudioSource obj in sfx_Audio)
        {
            obj.volume = newVolume;
        }

        chatterMusic.volume = newVolume;
    }

    public void musicVolumeChanged(float newVolume)
    {
        musicVolume = newVolume;
        //if(chatterMusic)
        audioMusic.volume = newVolume;
    }

    public void gamePaused()
    {
        //  fadeOutAll();
    }

    public void gameResumed()
    {
        //  fadeInAll();
    }

    public void gameRestarted()
    {
        //  fadeInMusicVolume();
    }


    private float sfxVolume;

    private float musicVolume;

    private int chatterIndex;
    
    
    public AudioSource audioMusic,chatterMusic;

    public AudioClip[] musicSounds;

    public AudioClip[] chatterSounds;
    
    public List<AudioSource> sfx_Audio;

    private Dictionary<AudioLibrary, GameAudioPool> audioList;

    public GameAudioPool[] pool;
    
    
    // Sound Issue 
    
    void OnApplicationFocus()
    {
        AudioSettings.Reset(AudioSettings.GetConfiguration());
        Invoke("OnFocus",1f);
    }

    public void OnFocus()
    {
        if (musicSounds.Length > 0)
        {
            audioMusic.loop = true;
            audioMusic.volume = 0.6f;
            audioMusic.clip = musicSounds[Random.Range(0, musicSounds.Length)];
            audioMusic.Play();
        }
    }
  
    

}