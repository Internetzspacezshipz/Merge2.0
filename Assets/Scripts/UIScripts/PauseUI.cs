using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    private Canvas canvas;

    [SerializeField]
    private Button mainMenuButton;
	[SerializeField]
	private Button restartButton;

    void Start()
    {
        Button checkBtn = mainMenuButton.GetComponent<Button>();
        checkBtn.onClick.AddListener (MainMenu);
		Button restartBtn = restartButton.GetComponent<Button> ();
		restartBtn.onClick.AddListener (Restart);

    }


    private void MainMenu()
    {
        GameManager.instance.LoadLevel("MainMenu");
    }


	private void Restart()
	{
		GameManager.instance.RestartGame ();
	}

    private void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            canvas.enabled = true;
        }
    }



    public void UnPause()
    {
        Time.timeScale = 1;
        canvas.enabled = false;
    }
}