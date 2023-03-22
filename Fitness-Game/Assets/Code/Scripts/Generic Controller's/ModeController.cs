
using UnityEngine;

public class ModeController : MonoBehaviour
{
    public LevelManager[] LevelManagers;
    public GameObject Enemy;
     LevelManager _currentLevelManager;
     public static ModeController instance;
     private void Awake()
     {
         instance = this;

     }
    // Start is called before the first frame update
    void Start()
    {
//        print(ApplicationController.SelectedGameMode + " = Game Mode");
        _currentLevelManager =    LevelManagers[ApplicationController.SelectedGameMode];
        
        if (_currentLevelManager)
        {
            _currentLevelManager.enabled = true;
        }
        else
        {
            Debug.Log("Nothing..............");
        }
    }

}
