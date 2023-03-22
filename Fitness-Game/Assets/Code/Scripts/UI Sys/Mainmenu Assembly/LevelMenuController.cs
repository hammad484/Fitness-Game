
using System;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelMenuController : MonoBehaviour
{
    #region Instance

    private static LevelMenuController _instance;

    public static LevelMenuController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<LevelMenuController>();
            }

            return _instance;
        }
    }

    #endregion
    public GameObject InAppLevels,InappLevelsButton;

    public Button[] levelButtons;
    public GameObject[] lockButtons,CurrentSelectedLevelButtons;
    public GameObject[] lockButtonsText;
    public ScrollRect scrollRect;

    [SerializeField] private GameObject[] EnvButtons;
        [SerializeField]private TextMeshProUGUI SelectedEnv;
    
    public int customMode,customLevelUnlock;
    int i,lastSelectedLevel;
    int levelButtonsLength;

    public bool HideText;

    private DataController _dataController;
    private InventoryController _inventoryController;
    private LoadingController _loadingController;

    private void Awake()
    {
        _instance = this;

    }

    private void Start()
    {
        _inventoryController = InventoryController.instance;
        _dataController = DataController.instance;
        _loadingController = LoadingController.instance;
        ApplicationController.SelectedInventoryItem = ApplicationController.TempInventoryItem;
        
    }

    public void ExecuteLevel()
    {
        OnClickSelectEnv(ApplicationController.LastSelectedEnvScene);

        if (PlayerPrefs.GetString("_UnlockAllGame") == "Unlocked" || PlayerPrefs.GetString("_UnlockAlllevels") == "Unlocked" )
        {
            InAppLevels.SetActive(false);
            InappLevelsButton.SetActive(false);
        }
        else
        {
            InAppLevels.SetActive(true);
            InappLevelsButton.SetActive(true);
        }
    }

    public void OnClickSelectLevel(int index)
    {
        ApplicationController.SelectedLevel = index;

 

    }

    
    
    public void Play()
    {
        OnClickSelectLevel(ApplicationController.SelectedLevel);
    }

    public void InventoryOpen()
    {
        _inventoryController.Display();
    }

    public void UnlockingLevel()
    {
        levelButtonsLength = levelButtons.Length;

        if (levelButtons.Length <= 0) return;

        for (i = 0; i < levelButtonsLength; i++)
        {
            if (_dataController.GetUnlockLevel(i))
            {
                levelButtons[i].interactable = true;
                lockButtons[i].SetActive(false);
                lockButtonsText[i].SetActive(true);
                lastSelectedLevel = i;
            }
            else
            {
                levelButtons[i].interactable = false;
                lockButtons[i].SetActive(true);
                if(HideText)
                lockButtonsText[i].SetActive(false);
            }
        }

        ApplicationController.LastSelectedLevel = lastSelectedLevel;
        ApplicationController.SelectedLevel = ApplicationController.LastSelectedLevel;
      
        levelButtons[ApplicationController.LastSelectedLevel].GetComponent<Selectable>().Select();
        
        for (i = 0; i < CurrentSelectedLevelButtons.Length; i++)
        {
            CurrentSelectedLevelButtons[i].SetActive(false);
        }
        
        CurrentSelectedLevelButtons[ApplicationController.LastSelectedLevel].SetActive(true);
        lockButtonsText[ApplicationController.LastSelectedLevel].SetActive(true);

       // setSlider();
      
    }

    public float tempSlidervalue;
    
   
    public void setSlider()
    {
    
        tempSlidervalue=(lastSelectedLevel) /10f;
        scrollRect.horizontalNormalizedPosition = tempSlidervalue;
    }

    /////////////////Env
    
    public void OnClickSelectEnv(int index)
    {
        ApplicationController.LastSelectedEnvScene = index;
        if (index == 3)
        {
            SelectedEnv.text = $"JAPAN CITY";
        }
        else
        {
            SelectedEnv.text = $"CHINA TOWN";

        }

        UnlockingLevel();
    }

   
    #region LevelSelectionAnimation

    /// <summary>
    /// Custom Script for animating Level Selection Background and Level Buttons
    /// </summary>

   // public Animator LevelSelectionBGAnimator;
    public Animator ScrollBarAnimator;
    public Animator LevelSelectionPlayAnimator;

    [ContextMenu("AnimateMe")]
    public void AnimateLevelSelection()
    {
        StartCoroutine(AnimatewithDelay());
        //ScrollBarAnimator.gameObject.SetActive(false);
       // LevelSelectionPlayAnimator.gameObject.SetActive(false);

    }

    IEnumerator AnimatewithDelay()
    {
     //   LevelSelectionBGAnimator.enabled = true;
      //  LevelSelectionBGAnimator.Play(0);
        yield return new WaitForSecondsRealtime(0.5f);
      //  ScrollBarAnimator.gameObject.SetActive(true);
      //  LevelSelectionPlayAnimator.gameObject.SetActive(true);
       // ScrollBarAnimator.enabled = true;
       // LevelSelectionPlayAnimator.enabled = true;
      //  ScrollBarAnimator.Play(0);
      //  LevelSelectionPlayAnimator.Play(0);
    }


    #endregion

    [ContextMenu("Unlock Level")]
    public void CustomLevelUnlocking()
    {
        ApplicationController.SelectedGameMode = customMode;

        for (int j = 0; j < customLevelUnlock; j++)
        {
            DataController.instance.SetUnlockLevel(j);
        }
    }

    public void UnlockAllLevels()
    {
        ApplicationController.SelectedGameMode = 0;
        for (i = 0; i < levelButtons.Length; i++)
        {
            DataController.instance.SetUnlockLevel(i);
        }

        ApplicationController.SelectedGameMode = 1;
        for (i = 0; i < levelButtons.Length; i++)
        {
            DataController.instance.SetUnlockLevel(i);
        }

        ApplicationController.SelectedGameMode = 3;
        for (i = 0; i < levelButtons.Length; i++)
        {
            DataController.instance.SetUnlockLevel(i);
        }

        
        ApplicationController.SelectedGameMode = 0;

        ExecuteLevel();
        
        
        InAppLevels.SetActive(false);
        InappLevelsButton.SetActive(false);
        PlayerPrefs.SetString("_UnlockAlllevels","Unlocked");

    }

}
