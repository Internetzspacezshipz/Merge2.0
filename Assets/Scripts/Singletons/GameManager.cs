using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int sceneNumber;
    private Canvas canvas;
    [SerializeField]
    private Canvas canvasObject;
    public int currentCheckpoint = 0;


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
        
        SceneManager.LoadScene(levelNumber, LoadSceneMode.Single);
    }

    public void FailUI()
    {
        Instantiate(canvasObject);
        canvas = FindObjectOfType<Canvas>();

        Time.timeScale = 0;
        canvas.enabled = true;

    }

    public void LoadCheckpoint()
    {
        RestartGame();
        CheckpointSystem.instance.SpawnAtCheckpoint();
    }

}