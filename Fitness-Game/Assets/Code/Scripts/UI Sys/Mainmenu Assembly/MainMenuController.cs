using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    #region Instance

    private static MainMenuController _instance;

    public static MainMenuController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MainMenuController>();
            }

            return _instance;
        }
    }

    #endregion
    [SerializeField] private GameObject characterSelection;
    [SerializeField] private GameObject character;
    
    
    public Canvas[] panels;
    public Stack<Canvas> panelsStack = new Stack<Canvas>();
    private int currentpanelIndex = -1;

    public GameObject DontDestroyPrefab;
    InventoryController _InventoryController;
    private LoadingController _loadingController;

    private void Awake()
    {
        _instance = this;
//        if (!SceneMngmtController.instance)
//        {
//            Instantiate(DontDestroyPrefab);
//        }

        if (ApplicationController.SelectedGameMode == 1)
        {

            ApplicationController.SelectedGameMode = 0;
            ApplicationController._Gameplay = Gameplay.Practice;
        }
    }

    void Start()
    {
        _InventoryController = InventoryController.instance;
        _loadingController = LoadingController.instance;

        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].enabled = false;
        }

        AddPanelToStackAndLoad(0);
    }

 

    public void AddPanelToStackAndLoad(int panelIndex)
    {
        if (panelsStack.Contains(panels[0]))
        {
            panelsStack.Peek().enabled = false;
        }

      
        panelsStack.Push(panels[panelIndex]);
        panelsStack.Peek().enabled = true;
        currentpanelIndex = panelIndex;


        if (panelIndex == 2)
        {
            characterSelection.SetActive(true);
            character.SetActive(false);
        }
        else
        {
            characterSelection.SetActive(false);
            character.SetActive(true);
        }
    }


    public void RemoveLastPanelFormStack()
    {
     
        
        panelsStack.Peek().enabled = false;
        panelsStack?.Pop();
        panelsStack.Peek().enabled = true;
        
     
    }

    public void SwitchCharacters()
    {
        characterSelection.SetActive(false);
            character.SetActive(true);
    }


}