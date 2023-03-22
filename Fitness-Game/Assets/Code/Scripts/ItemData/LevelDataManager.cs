using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
 #region Instance
 
    private static LevelDataManager _instance;

    public static LevelDataManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelDataManager>();
            }

            return _instance;
        }
    }
 
    #endregion



    public LevelData[] Levels;
    
    public LevelData[] Tutorials;
    
    private void Awake()
    {
        _instance = this;
  
    }

}
