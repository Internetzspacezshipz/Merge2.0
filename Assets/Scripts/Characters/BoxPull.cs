﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPull : MonoBehaviour
{
    CharacterController controller;


    private void Awake()
    {
        controller = GetComponentInParent<CharacterController>();
    }







}