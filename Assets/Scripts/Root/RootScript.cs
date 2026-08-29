using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RootScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return SceneManager.LoadSceneAsync(
            "PersistentScene",
            LoadSceneMode.Additive
        );

        SceneLoader.Instance.SetCurrentScene(RootSceneName.RootScene);
        
        // SceneLoader.Instance.Load(RootSceneName.CSharpLearningScene);
        SceneLoader.Instance.Load(RootSceneName.UnityBasicScene);
        // SceneLoader.Instance.Load(RootSceneName.UnityIntermediateScene);
        // SceneLoader.Instance.Load(RootSceneName.UnityAdvancedScene);
    }
}
