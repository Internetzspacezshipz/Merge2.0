using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    private Canvas canvas;

    [SerializeField]
    private Button mainMenuButton;

    void Start()
    {
        Button checkBtn = mainMenuButton.GetComponent<Button>();
        checkBtn.onClick.AddListener(MainMenu);
    }


    private void MainMenu()
    {
        GameManager.instance.LoadLevel("MainMenu");
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