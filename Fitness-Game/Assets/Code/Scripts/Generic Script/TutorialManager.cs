using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
 #region Instance
 
    private static TutorialManager _instance;

    public static TutorialManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<TutorialManager>();
            }

            return _instance;
        }
    }
 
    #endregion


    private void Awake()
    {
        _instance = this;
  
    }

    public void Tutorial(int n)
    {
        ApplicationController.SelectedGameMode = 1;
        ApplicationController._Gameplay = Gameplay.Tutorial;
        ApplicationController.TutorialIndex= n;
        MenuController.instance.PlayBtnClick();
    }
    
}


