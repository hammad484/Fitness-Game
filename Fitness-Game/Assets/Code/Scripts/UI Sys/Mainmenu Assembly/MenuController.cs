
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    #region Instance

    private static MenuController _instance;

    public static MenuController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<MenuController>();
            }

            return _instance;
        }
    }

    #endregion

    private MainMenuController _mainMenuController;
    private InventoryController _inventoryController;
    private ModeSelectController _modeSelectController;
    
    
    public TextMeshProUGUI UnlockAllGameAd;
    public TextMeshProUGUI UnlockAllGameInventoryAd;
    public TextMeshProUGUI RemoveAdAd;
    
    public int maxRemoveAd;
    public int maxUnlockAllGameAd;
    
    public GameObject RemoveAdBtn;
    public GameObject UnlockAllGame;
    public GameObject UnlockAllGameInventoryBtn;
    public GameObject Character;
   // public bool InAppPanel;
    
    public GameObject InAppUnlockAllGamePanel,InAppUnlockAllGameButton;

    
    public Canvas Profile;

    LoadingController _loadingController;



    public void ClosePanel()
    {
        Character.SetActive(true);
    }
    private void Awake()
    {
        _instance = this;
    }


    private void Start()
    {
        _mainMenuController = MainMenuController.instance;
        _inventoryController = InventoryController.instance;
        _modeSelectController = ModeSelectController.instance;
        _loadingController = LoadingController.instance;

        
        if (PlayerPrefs.GetString("_UnlockAllGame") == "Unlocked")
        {
            UnlockAllGame.SetActive(false);
            UnlockAllGameInventoryBtn.SetActive(false); 
            RemoveAdBtn.SetActive(false);
            UnlockAllGameAd.gameObject.SetActive(false);
            UnlockAllGameInventoryAd.gameObject.SetActive(false);
            InAppUnlockAllGamePanel.SetActive(false);
            InAppUnlockAllGameButton.SetActive(false);
        }
        else
        {
           // UnlockAllGameAd.text = DataController.instance.getPref(RewardTriggers.UnlockAllGame.ToString()) + "/" + maxUnlockAllGameAd; 
           // UnlockAllGameInventoryAd.text = DataController.instance.getPref(RewardTriggers.UnlockAllGame.ToString()) + "/" + maxUnlockAllGameAd; 
//            InAppUnlockAllGamePanel.SetActive(true);
        }
        
        
        if (PlayerPrefs.GetString("DoNotShowAds") == "Unlocked")
        {
            RemoveAdBtn.SetActive(false);
            RemoveAdAd.gameObject.SetActive(false);
        }
        else
        {
          //  RemoveAdAd.text = DataController.instance.getPref(RewardTriggers.RemoveAd.ToString()) + "/" + maxRemoveAd; 
        }
       
        
        if (PlayerPrefs.GetString("DoNotShowAds") == "Unlocked")
        {
            RemoveAdBtn.SetActive(false);
            RemoveAdAd.gameObject.SetActive(false);
        }
        else
        {
            //  RemoveAdAd.text = DataController.instance.getPref(RewardTriggers.RemoveAd.ToString()) + "/" + maxRemoveAd; 
        }
        
        
        if (PlayerPrefs.GetString("Profile") == "Done")
        {
            Profile.enabled=false;
        }
        else
        {
            Profile.enabled=true;
            PlayerPrefs.SetString("Profile", "Done");
        }
    }

    public void PlayBtnClick()
    {
        _mainMenuController.AddPanelToStackAndLoad(1);
    }

    public void SettingBtnClick()
    {
        _mainMenuController.AddPanelToStackAndLoad(3);
    }

    public void CharacterBtnClick()
    {
        _mainMenuController.AddPanelToStackAndLoad(2);
        _inventoryController.Display();
    }

    public void ExceriseBtnClick()
    {
        _mainMenuController.AddPanelToStackAndLoad(8);
    }
    
    public void TutorialBtnClick()
    {
        _mainMenuController.AddPanelToStackAndLoad(9);
    }
    
    public void BackBtnClick()
    {
        _mainMenuController.AddPanelToStackAndLoad(4);
    }

}