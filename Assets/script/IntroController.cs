using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
    public string firstLevelName;
    private bool isLoading = false;

    public void StartLevel()
    {
        if (isLoading) return;
        isLoading = true;

        SceneManager.LoadScene(firstLevelName);
    }
}
