using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

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

    public int winzoneCount = 0;

    public Soul soul;
    public Body body;

	public bool detachCamera = false;

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
        GameManager.instance.detachCamera = false;
        soul = FindObjectOfType<Soul>();
        body = FindObjectOfType<Body>();

        soul.isDead = false;
        body.isDead = false;

        Time.timeScale = 1;

        winzoneCount = 0;

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

        GameManager.instance.enabled = false;
    }

    public void FailUI()
    {
        StartCoroutine(DeathTimeline());
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


    public void OnWin(PlayerControl playerController)
	{		
		playerController.OnWin ();
        playerController._SR.enabled = false;
		playerController.isDead = true;
    }


    IEnumerator DeathTimeline()
    {


        soul.isDead = true;
        body.isDead = true;

        yield return new WaitForSeconds(0.1f);


        soul.Die();
        body.Die();

        yield return new WaitForSeconds(1.5f);

        AudioSource[] audioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in audioSources)
        {
            audioS.Stop();
        }

        RestartGame();
    }
}