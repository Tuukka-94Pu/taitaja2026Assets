using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioClip[] sounds;
    public string[] soundNames;

    public AudioClip[] music;
    public string[] musicNames;

    public AudioSource sfxSource;
    public AudioSource musicSource;

    private Dictionary<string, AudioClip> allDaAudio;
    private Dictionary<string, AudioClip> allDaMusic;

    public Slider sfxSlider;
    public Slider musicSlider;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if(instance != this)
        {
            Destroy(gameObject);
            return;
        }

        musicSource.loop = true;
    }

    void Start()
    {
        allDaAudio = new Dictionary<string, AudioClip>();
        allDaMusic = new Dictionary<string, AudioClip>();

        var i = 0;
        foreach (var sound in sounds)
        {
            allDaAudio.Add(soundNames[i],sound);
            i++;
        }
        i = 0;
        foreach(var music in music)
        {
            allDaMusic.Add(musicNames[i],music);
            i++;
        }

        playMusic("basicMus");

    }

    // Update is called once per frame
    void Update()
    {
       if(sfxSlider != null) sfxSource.volume = sfxSlider.value;
       if(musicSlider != null) musicSource.volume = musicSlider.value;
    }
    public void playSound(string soundName)
    {
        if (allDaAudio.ContainsKey(soundName))
        {
            sfxSource.PlayOneShot(allDaAudio[soundName]);
        }
    }

    public void stopSound()
    {
        sfxSource.Stop(); 
    }

    public void playMusic(string musicName)
    {
        if (allDaMusic.ContainsKey(musicName))
        {
            musicSource.PlayOneShot(allDaMusic[musicName]);
        }
    }
}
