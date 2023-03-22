
using DG.Tweening;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class ModeSelectController : MonoBehaviour
{
    #region Instance
 
    private static ModeSelectController _instance;

    public static ModeSelectController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ModeSelectController>();
            }

            return _instance;
        }
    }
 
    #endregion

 
     LoadingController _loadingController;


    private void Awake()
    {
  
        _instance = this;
  
    }


    private void Start()
    {
        _loadingController = LoadingController.instance;
        
            
    }
 
    public void PlayBtnClick()
    {
        _loadLevel();
    }

    public void _loadLevel()
    {
        _loadingController.display(Scenes.Gameplay);
    }
    
    public void EnvOnBtnClick(int n)
    {
        ApplicationController.LastSelectedEnvScene= n;
        if(ApplicationController._Gameplay== Gameplay.Practice)
        ApplicationController.SelectedGameMode= 0;
    }
    public void EnvIndex(int n)
    {
        DataController.lastSelectedEnv= n;
    }
}


