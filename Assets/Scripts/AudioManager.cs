using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

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
        }
        else
        {
            Destroy(gameObject);
        }

        UpdateAudio();
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
            // if menu music is not playing when it should be
            PlayMusic(menuMusic);
        }
        else
        {
            // if level music is not playing when it should be 
            PlayMusic(levelMusic);
        }

    }

    private void PlayMusic(AudioClip clip)
    {
        if (!(audioSource.clip == clip && audioSource.isPlaying))
        {
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

}
