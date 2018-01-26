using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private int sceneNumber;
    private Canvas canvas;
    [SerializeField]
    private Canvas failUI;
    [SerializeField]
    private Canvas pauseUI;
    private Canvas pauseUIObject;
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

    void OnEnable()
    {
        //Tell our 'OnLevelFinishedLoading' function to start listening for a scene change as soon as this script is enabled.
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }

    void OnDisable()
    {
        //Tell our 'OnLevelFinishedLoading' function to stop listening for a scene change as soon as this script is disabled. Remember to always have an unsubscription for every delegate you subscribe to!
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        Time.timeScale = 1;

        sceneNumber = scene.buildIndex;
    }

    public void RestartGame()
    {
        Debug.Log("RestartingGame");
        Time.timeScale = 1;

        sceneNumber = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneNumber);
    }

    public void LoadLevel(string levelName)
    {
        Time.timeScale = 1;
        
        SceneManager.LoadScene(levelName, LoadSceneMode.Single);
    }

    public void FailUI()
    {
        Instantiate(failUI);
        canvas = FindObjectOfType<Canvas>();

        Time.timeScale = 0;
        canvas.enabled = true;

        AudioSource[] audioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in audioSources)
        {
            audioS.Stop();
        }
    }

    public void LoadCheckpoint()
    {
        RestartGame();
        CheckpointSystem.instance.SpawnAtCheckpoint();
    }

    public void Quit()
    {
        Application.Quit();
    }

}