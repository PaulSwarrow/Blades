using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private BaseGameController[] controllers;
    // Start is called before the first frame update
    
    
    private void Awake()
    {
        controllers = GetComponents<BaseGameController>();

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
