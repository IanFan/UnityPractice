using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance { get; private set; }

    private string lastScene;
    private string currentScene;

    private void Awake()
    {
        Instance = this;
    }

    // 完整切換 Scene
    public void Load<T>(T nextScene) where T : Enum
    {
        StartCoroutine(SwitchScene(nextScene.ToString()));
    }

    private IEnumerator SwitchScene(string nextScene)
    {
        // 1. Additive 載入新 Scene
        yield return LoadAdditive(nextScene);

        // 2. 設成 Active Scene
        SetActiveScene(nextScene);

        // 3. 移除舊 Scene
        if (!string.IsNullOrEmpty(currentScene))
        {
            yield return UnloadScene(currentScene);
        }

        // 4. 記住 Scene
        if (currentScene != null)
        {
            SetLastScene(currentScene);
        }
        SetCurrentScene(nextScene);
    }

    // 設定目前 Scene
    public void SetCurrentScene<T>(T scene) where T : Enum
    {
        SetCurrentScene(scene.ToString());
    }

    private void SetCurrentScene(string scene)
    {
        currentScene = scene;
    }

    private void SetLastScene(string scene)
    {
        lastScene = scene;
    }

    // Additive 載入 Scene
    public IEnumerator LoadAdditive<T>(T scene) where T : Enum
    {
        yield return LoadAdditive(scene.ToString());
    }

    private IEnumerator LoadAdditive(string scene)
    {
        yield return SceneManager.LoadSceneAsync(
            scene,
            LoadSceneMode.Additive
        );
    }

    // 移除 Scene
    public IEnumerator UnloadScene<T>(T scene) where T : Enum
    {
        yield return UnloadScene(scene.ToString());
    }

    private IEnumerator UnloadScene(string scene)
    {
        yield return SceneManager.UnloadSceneAsync(scene);
    }

    // 設定 Active Scene
    public void SetActiveScene<T>(T scene) where T : Enum
    {
        SetActiveScene(scene.ToString());
    }

    private void SetActiveScene(string scene)
    {
        Scene targetScene = SceneManager.GetSceneByName(scene);

        SceneManager.SetActiveScene(targetScene);
    }
}