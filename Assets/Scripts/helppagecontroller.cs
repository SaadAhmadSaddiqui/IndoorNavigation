﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class helppagecontroller : MonoBehaviour
{
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("madeby");
    }
    // Update is called once per frame
    void Update()
    {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("IndoorNav");
            }
        
    }
}
