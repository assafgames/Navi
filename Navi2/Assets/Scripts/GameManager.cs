using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    //private UImanager uiManager;

    protected GameManager() { } // guarantee this will be always a singleton only - can't use the constructor!

    void Awake()
    {
        //uiManager = GameObject.FindWithTag("UImanager").GetComponent<UImanager>();
    }

    public void LevelSuccess(int levelNumber)
    {
        print("LevelSuccess:"+levelNumber);
    }
}
