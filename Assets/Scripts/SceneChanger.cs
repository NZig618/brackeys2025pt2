using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] public float fadeDuration;

    [SerializeField] string nextLevel = "Credits";

    public SceneFade sceneFade;

    public GameObject pauseCanvas;

    public GameObject winCanvas;

    public GameObject deathCanvas;

    private IEnumerator Start()
    {
        yield return sceneFade.FadeInCoroutine(fadeDuration);
    }

    private IEnumerator LoadSceneCoroutine(string sceneToLoad)
    {
        yield return sceneFade.FadeOutCoroutine(fadeDuration);
        yield return SceneManager.LoadSceneAsync(sceneToLoad);
    }

    public void ChangeScene(string sceneToLoad)
    {
        StartCoroutine(LoadSceneCoroutine(sceneToLoad));
    }

    private void StopGame()
    {
        Time.timeScale = 0;
    }

    private void ContinueGame()
    {
        Time.timeScale = 1;
    }

    public void Pause()
    {
        StopGame();
        pauseCanvas.SetActive(true);
    }

    public void Unpause()
    {
        pauseCanvas.SetActive(false);
        ContinueGame();
    }

    public void LevelComplete()
    {
        winCanvas.SetActive(true);
    }

    public void NextLevel()
    {
        ChangeScene(nextLevel);
    }

    public void GameOver()
    {
        deathCanvas.SetActive(true);
    }

    public void Restart()
    {
        ChangeScene(SceneManager.GetActiveScene().name);
    }
}
