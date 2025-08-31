using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip levelMusic;
    public string[] menuScenes = { "MainMenu", "LevelSelect", "Credits", "ControlMenu" };

    private void Awake()
    {
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

        if (ArrayUtility.Contains(menuScenes, scene.name))
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
