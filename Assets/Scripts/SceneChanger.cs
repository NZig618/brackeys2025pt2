using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    [SerializeField] public float fadeDuration;
    public SceneFade sceneFade;

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
}
