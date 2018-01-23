using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int sceneNumber;
    private Canvas canvas;
    [SerializeField]
    private Canvas canvasObject;


    private void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
            return;
        }
        Destroy(this);
    }

    private void OnLevelWasLoaded(int level)
    {
        Time.timeScale = 1;

        sceneNumber = level;

        if (sceneNumber != 0 && sceneNumber != 1 && sceneNumber != 2)
        {
            Instantiate(canvasObject);
            canvas = FindObjectOfType<Canvas>();
            canvas.enabled = false;
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;

        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadLevel(int levelNumber)
    {
        Time.timeScale = 1;

        SceneManager.LoadScene(levelNumber);
    }

    public void FailUI()
    {
        Time.timeScale = 0;
        canvas.enabled = true;
    }

    public void UnloadFailUI()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
    }
}