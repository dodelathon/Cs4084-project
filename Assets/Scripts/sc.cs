﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        if (ScoreContainer.container.Load() == false)
        {
            ScoreContainer.container.Load();
        }
    }
}
