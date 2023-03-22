using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetModeLevel : MonoBehaviour
{
   
    public  GameMode gameMode;

    public  int level,Env;
    
     void Awake()
     {
         ApplicationController.LastSelectedEnvScene = Env;
        ApplicationController.SelectedGameMode = (int)gameMode;
        ApplicationController.SelectedLevel = level;
    }
}
