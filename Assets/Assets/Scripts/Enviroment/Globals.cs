﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    //Singleton
    public static Globals instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(this);
    }

    public bool doorOpen = false;

    public int score;
}