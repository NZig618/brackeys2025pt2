using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip levelMusic;
    public List<string> menuScenes;

    private void Awake()
    {
        menuScenes.Add("MainMenu");
        menuScenes.Add("LevelSelect");
        menuScenes.Add("Credits");
        menuScenes.Add("ControlMenu");

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            UpdateAudio();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        UpdateAudio();
    }

    private void UpdateAudio()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (menuScenes.Contains(scene.name))
        {
            // current scene is a menu
            PlayMusic(menuMusic);
        }
        else
        {
            // current scene is a level
            PlayMusic(levelMusic);
        }

    }

    private void PlayMusic(AudioClip clip)
    {
        // if the correct music is already playing skip this
        if (!(audioSource.clip == clip && audioSource.isPlaying))
        {
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
}
