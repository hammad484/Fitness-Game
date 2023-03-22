
using System.Collections.Generic;
using UnityEngine;

public class ApplicationController : MonoBehaviour

{
    #region Instance
 
    private static ApplicationController _instance;
   // public static RewardTriggers _RewardTriggerValue;

    public static ApplicationController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ApplicationController>();
            }

            return _instance;
        }
    }
 
    #endregion
    
    private void Awake()
    {
        _instance = this;
  
    }

    public static int SelectedLevel;

    public static int SelectedGameMode
    {
        
        get { return DataController.lastSelectedGameMode; }
        set { DataController.lastSelectedGameMode = value ; }
    }
    
    

    public static int LastSelectedLevel
    {
        
        get { return DataController.lastSelectedLevel; }
        set { DataController.lastSelectedLevel = value; }
    }
    
    public static int LastSelectedCharacter
    {
        
        get { return DataController.lastSelectedCharacter; }
        set { DataController.lastSelectedCharacter = value; }
    }
    
    public static string Age
    {
        
        get { return DataController.Age; }
        set { DataController.Age = value; }
    }
    
    public static string Name
    {
        
        get { return DataController.Name; }
        set { DataController.Name = value; }
    }
    
    
    public static int LastSelectedEnvScene
    {
        
        get { return DataController.lastSelectedEnvScene; }
        set { DataController.lastSelectedEnvScene = value; }
    }
    public static int TutorialIndex
    {
        
        get { return DataController.SelectedTutorial; }
        set { DataController.SelectedTutorial = value; }
    }
    public static int SelectedInventoryItem
    {
        
        get { return DataController.lastSelectedInventoryItem; }
        set { DataController.lastSelectedInventoryItem = value ; }
    }
    
    public static int SelectedWeaponIndex
    {
        
        get { return DataController.lastSelectedWeaponIndex; }
        set { DataController.lastSelectedWeaponIndex = value ; }
    }


    public static int TempInventoryItem
    {
        
        get { return DataController.lastTempSelectedInventoryItem; }
        set { DataController.lastTempSelectedInventoryItem = value ; }
    }
    public static GameMode _GameEnv
    {
        get { return  (GameMode)DataController.lastSelectedEnv ; } 
        set { _GameEnv = value ; }
    }

    public static Gameplay _Gameplay;
  

    public static Excercise currentExcercise;

    public void ExcerciseTrigger(Excercise excercise)
    {
        currentExcercise = excercise;
    }






}
 