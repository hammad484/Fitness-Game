using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Profile : MonoBehaviour
{
 #region Instance
 
    private static Profile _instance;

    public static Profile instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Profile>();
            }

            return _instance;
        }
    }
 
    #endregion



    [SerializeField] private Image SelectedCharacter;
    [SerializeField] private Sprite BoyIcon, GirlIcon;
    [SerializeField] private TextMeshProUGUI _nameText,_nameTextProfile,_ageTextProfile;
    
    
    [SerializeField] private Image Boy, Girl;
    [SerializeField] private TMP_InputField Name, Age;
    [SerializeField] private Sprite NormalState,SelectedState;

    private int CharacterIndex;


    [SerializeField] private Image Progression;
    [SerializeField] private Text ProgressionPercent;
    
    private LevelDataManager levelDataManager;
    private DataController _dataController;

    private float totalprogression;
    private float currentprogression;
    
    private void Awake()
    {
        _instance = this;

        if (ApplicationController.LastSelectedCharacter == 0)
        {
            BoySelected();
        }
        else
        {
            GirlSelected();
        }

        if (PlayerPrefs.GetString("Profile") == "Done")
        {
            _nameTextProfile.text = _nameText.text = ApplicationController.Name;
            _ageTextProfile.text = ApplicationController.Age;
        }
        
           
    }

    public void Start()
    {
        levelDataManager = LevelDataManager.instance;
        _dataController = DataController.instance;
        UnlockingLevel();
        calculateProgression(); 
    }

    public void calculateProgression()
    {
        totalprogression = levelDataManager.Levels.Length + levelDataManager.Tutorials.Length;

            currentprogression =(lastSelectedLevel+lastTutoriallevel) / totalprogression;
            ProgressionPercent.text = $"{Mathf.RoundToInt(currentprogression*100f)}%";
            Progression.fillAmount = currentprogression;
      
    }

        int lastSelectedLevel,lastTutoriallevel;
    public void UnlockingLevel()
    {
        ApplicationController.SelectedGameMode= 0;

        for (int i = 0; i <= levelDataManager.Levels.Length; i++)
        {
            if (_dataController.GetUnlockLevel(i))
            {
                lastSelectedLevel = i;
            }
        }
     //   print(lastSelectedLevel);
        ApplicationController.SelectedGameMode= 1;

        for (int i = 0; i <= levelDataManager.Tutorials.Length; i++)
        {
            if (_dataController.GetUnlockLevel(i))
            {
                lastTutoriallevel = i;
            }
        }
//        print(lastTutoriallevel);
    }

    public void BoySelected()
    {
        Boy.sprite = SelectedState;
        Girl.sprite = NormalState;
        SelectedCharacter.sprite = BoyIcon;
        CharacterIndex = 0;
    }
    public void GirlSelected()
    {
        Boy.sprite = NormalState;
        Girl.sprite = SelectedState;
        SelectedCharacter.sprite = GirlIcon;
        CharacterIndex = 1;
    }


    public void SaveData()
    {
        ApplicationController.LastSelectedCharacter = CharacterIndex;
        Name.gameObject.SetActive(false);
        Age.gameObject.SetActive(false);
        GetComponent<Canvas>().enabled = false;
        InventoryController.instance.DisplayCharacter(CharacterIndex);
    }


    public void SubmitName(string arg0)
    {
        _nameText.text = arg0;
        _nameTextProfile.text = arg0;
        ApplicationController.Name = arg0;
    }
    
    public void SubmitAge(string arg0)
    {
        _ageTextProfile.text = arg0;
        ApplicationController.Age = arg0;

    }

    public void SetProgression()
    {
//        Progression.fillAmount = 
    }
}
