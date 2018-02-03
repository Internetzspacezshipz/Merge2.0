using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private string playButtonLevel = "Level Design";

    [SerializeField]
    private Canvas controlsMenu;

    [SerializeField]
    private Button nextLevelButton;
    [SerializeField]
    private string NextLevel = "Level Design_2";
    
    [SerializeField]
    private Button quitButton;


    void Start()
    {
        Button startBtn = playButton.GetComponent<Button>();
        startBtn.onClick.AddListener(Load);

        Button quitBtn = quitButton.GetComponent<Button>();
        quitBtn.onClick.AddListener(Quit);

        Button nextlvlBtn = nextLevelButton.GetComponent<Button>();
        nextlvlBtn.onClick.AddListener(LoadNextLevel);


        controlsMenu.enabled = false;
    }

    void Load()
    {
        GameManager.instance.LoadLevel(playButtonLevel);
    }

    void LoadNextLevel()
    {
        GameManager.instance.LoadLevel(NextLevel);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
