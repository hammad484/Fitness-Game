using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryController : MonoBehaviour
{
    #region Instance

    private static InventoryController _instance;

    public static InventoryController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InventoryController>();
            }

            return _instance;
        }
    }

    #endregion

    [SerializeField] private GameObject Boy, Girl;
    [SerializeField] private GameObject NextBtn, PrevBtn;
    
    private MainMenuController _mainMenuController;
    private DataController _dataController;
    private LoadingController _loadingController;


    private void Awake()
    {
        _instance = this;
    }


    private void Start()
    {
        _mainMenuController = MainMenuController.instance;
        _dataController = DataController.instance;
        _loadingController = LoadingController.instance;
        DisplayCharacter(ApplicationController.LastSelectedCharacter);
     

    }


    public void DisplayCharacter(int i)
    {
        if (i == 0)
        {
            Boy.SetActive(true);
            Girl.SetActive(false);

        }
        else
        {
            Girl.SetActive(true);
            Boy.SetActive(false);
        }
    }


    public void Previous()
    {
        ApplicationController.LastSelectedCharacter = 0;
        RotateStage.instance.InterpolateEffect(-180);
        PrevBtn.SetActive(false);
        NextBtn.SetActive(true);
    }

    public void Next()
    {
        ApplicationController.LastSelectedCharacter = 1;
        RotateStage.instance.InterpolateEffect(0);
        PrevBtn.SetActive(true);
        NextBtn.SetActive(false);
    }

    public void Display()
    {
        if (ApplicationController.LastSelectedCharacter == 0)
        {
            Previous();
        }
        else
        {
            Next();
        }
    }
   

    public void Play()
    {
        _mainMenuController.RemoveLastPanelFormStack();
        
        if (ApplicationController.LastSelectedCharacter == 0)
        {
           Profile.instance.BoySelected();
        }
        else
        {
            Profile.instance.GirlSelected();
        }
        
        DisplayCharacter(ApplicationController.LastSelectedCharacter);
        _mainMenuController.SwitchCharacters();
    }
    public void Back()
    {
        _mainMenuController.RemoveLastPanelFormStack();
        
        DisplayCharacter(ApplicationController.LastSelectedCharacter);
        _mainMenuController.SwitchCharacters();
    }

}

