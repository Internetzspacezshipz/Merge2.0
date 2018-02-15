using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectUI : MonoBehaviour
{
    [SerializeField]
    private Button Level1;
    [SerializeField]
    private Button Level2;
    [SerializeField]
    private Button Level3;
    [SerializeField]
    private Button Level4;



    private void Start()
    {
        Button l1Btn = Level1.GetComponent<Button>();
        l1Btn.onClick.AddListener(Load1);

        Button l2Btn = Level2.GetComponent<Button>();
        l2Btn.onClick.AddListener(Load2);

        Button l3Btn = Level3.GetComponent<Button>();
        l3Btn.onClick.AddListener(Load3);

        Button l4Btn = Level4.GetComponent<Button>();
        l4Btn.onClick.AddListener(Load4);
    }

    private void Load1()
    {
        GameManager.instance.LoadLevel("LevelDesign_Pedro");
    }

    private void Load2()
    {
        GameManager.instance.LoadLevel("Level_3");
    }

    private void Load3()
    {
        GameManager.instance.LoadLevel("Level_4");
    }

    private void Load4()
    {
        GameManager.instance.LoadLevel("Level Design_2");
    }
}