﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneMngmtController : MonoBehaviour
{
    #region Instance
 
    private static SceneMngmtController _instance;

    public static SceneMngmtController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SceneMngmtController>();
            }

            return _instance;
        }
    }
 
    #endregion
     
 
    
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        _instance = this;
        
        
    }

    
    public void LoadScene(Scenes i)
    {
//        print(i);
        SceneManager.LoadScene((int) i);
     //   SceneManager.LoadScene(i.ToString());
    }
    public void LoadEnv(int i)
    {
//        print(i);
        SceneManager.LoadScene(i,LoadSceneMode.Additive);
    }
}


