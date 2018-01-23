using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FailMenuController : MonoBehaviour
{
    [SerializeField]
    private Button checkpointButton;
    [SerializeField]
    private Button mainMenuButton;
    [SerializeField]
    private Button restartButton;

    void Start()
    {
        Button checkBtn = checkpointButton.GetComponent<Button>();
        checkBtn.onClick.AddListener(CheckLoad);

        Button mainMenuBtn = mainMenuButton.GetComponent<Button>();
        mainMenuBtn.onClick.AddListener(MenuLoad);

        Button restartBtn = mainMenuButton.GetComponent<Button>();
        restartBtn.onClick.AddListener(Restart);
    }

    private void CheckLoad()
    {
        throw new NotImplementedException();
    }

    private void MenuLoad()
    {
        GameManager.instance.LoadLevel(0);
    }

    private void Restart()
    {
        GameManager.instance.RestartGame();
    }

}