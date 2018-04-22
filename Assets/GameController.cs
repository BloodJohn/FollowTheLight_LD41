using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public float darkTimeout;
    public LightController light;
    public Sprite[] spriteList;
    public Image[] liveImageList;

    private int lives;
    private float darkTimer = float.MinValue;
    private

    void Awake()
    {
        lives = liveImageList.Length * 2;


        if (light != null)
            light.OnLostLight += OnLostLight;
        else
        {
            Debug.LogErrorFormat("plz, select LightController for GameController {0}", name);
        }


    }

    void Update()
    {
        if (darkTimer >= 0f)
        {
            if (light.isLight)
            {
                darkTimer = float.MinValue;
            }
            else
            {
                darkTimer += Time.deltaTime;

                if (darkTimer > darkTimeout)
                {
                    lives--;
                    darkTimer = 0f;

                    UpdateLives();
                    if (lives == 0)
                    {
                        Debug.LogFormat("GameOver!");
                        lives = -1;
                        RestartGame();
                    }
                }
            }
        }
    }

    private void UpdateLives()
    {
        for (int i = 0; i < liveImageList.Length; i++)
        {
            if (lives >= i * 2 + 2)
            {
                liveImageList[i].gameObject.SetActive(true);
                liveImageList[i].sprite = spriteList[1];
            }
            else if (lives >= i * 2 + 1)
            {
                liveImageList[i].gameObject.SetActive(true);
                liveImageList[i].sprite = spriteList[0];
            }
            else
            {
                liveImageList[i].gameObject.SetActive(false);
            }
        }
    }

    void OnLostLight()
    {
        darkTimer = 0f;
    }

    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
