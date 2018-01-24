using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField]
    private int playButtonLevel = 1;

    [SerializeField]
    private Button quitButton;


    void Start()
    {
        Button startBtn = playButton.GetComponent<Button>();
        startBtn.onClick.AddListener(Load);

        Button quitBtn = quitButton.GetComponent<Button>();
        quitBtn.onClick.AddListener(Quit);
    }

    void Load()
    {
        GameManager.instance.LoadLevel(playButtonLevel);
    }

    private void Quit()
    {
        Application.Quit();
    }
}
