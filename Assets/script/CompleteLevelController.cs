using UnityEngine;
using UnityEngine.SceneManagement;

public class CompleteLevelController : MonoBehaviour
{
    private const string sceneName = "CompleteLevel";
    private static string nextLevelName = "Intro";
    private bool isLoading = false;

    public static void LoadScene(string levelName)
    {
        nextLevelName = levelName;
        SceneManager.LoadScene(sceneName);
    }

    public void StartLevel()
    {
        if (isLoading) return;
        isLoading = true;

        SceneManager.LoadScene(nextLevelName);
    }
}
