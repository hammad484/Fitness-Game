using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentHandler : MonoBehaviour
{
 #region Instance
 
    private static EnviromentHandler _instance;

    public static EnviromentHandler instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<EnviromentHandler>();
            }

            return _instance;
        }
    }
 
    #endregion


    private void Awake()
    {
        _instance = this;
          SceneMngmtController.instance.LoadEnv(ApplicationController.LastSelectedEnvScene);
    }

   
}
