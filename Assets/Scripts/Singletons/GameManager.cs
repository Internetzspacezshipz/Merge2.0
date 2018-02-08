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

    private Soul soul;
    private Body body;


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


        yield return new WaitForSeconds(2);


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


}