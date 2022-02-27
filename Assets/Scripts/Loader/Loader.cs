using UnityEngine;
using UnityEngine.SceneManagement;


public enum OtherScene
{
    Menu,
}
public static class Loader
{
    private const string LevelPrefix = "Level_";
    public static void GameStart()
    {
        Debug.Log("GameStart");
        SceneManager.sceneLoaded += SceneLoaded;
#if UNITY_EDITOR
        if (SceneManager.sceneCount > 1)
        {
            Scene testScene = SceneManager.GetSceneAt(1);
            SceneLoaded(testScene, LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadSceneAsync(LevelPrefix + SLS.Data.Level.Value, LoadSceneMode.Additive);
        }
#endif
        //LoadScene(SLS.Data.Level.Value);
    }
    private static void SceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        Debug.Log("SceneLoaded: " + scene.name);
        SceneManager.SetActiveScene(scene);
    }
    public static void LoadLevel(int level)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(LevelPrefix + level, LoadSceneMode.Additive);
        //SLS.Data.Level.Value = level;
    }
    public static void LoadOtherScene(OtherScene otherScene)
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
        SceneManager.LoadSceneAsync(otherScene.ToString(), LoadSceneMode.Additive);
    }
    public static void LoadCurrentLevel()
    {
        if (SLS.Data.Level.Value > MainScript.Instance.LevelCount)
        {
            SLS.Data.Level.Value = 1;
        }
        LoadLevel(SLS.Data.Level.Value);
    }
}
