
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    #region Instance
 
    private static GameController _instance;

    public static GameController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
            }

            return _instance;
        }
    }
 
    #endregion

  
    private GameOverController _gameOverController;

    private GameWinController _gameWinController;
    
    private LoadingController _loadingController;
    
    public delegate void GameStatusHandler();

    public static event GameStatusHandler gamePaused;

    public static event GameStatusHandler gameResumed;

    public static event GameStatusHandler gameStarted;

    public static event GameStatusHandler gameEnded;

    public static event GameStatusHandler gameRestarted;



    public static GameStatus _gameStatus = GameStatus.INGAME;

    public static GameStatus gameStatus
    {
        get
        {
            return _gameStatus;
        }
        set
        {
            _gameStatus = value;
        }
    }
    
    private void Awake()
    {
        _instance = this;
      
  
          GameStarting(0f);
    }

    
    
    void Start()
    {
        _gameOverController=GameOverController.instance;
        _gameWinController=GameWinController.instance;
        _loadingController=LoadingController.instance;
     
      
    }
    

    public void displayGameOver(float waitTime)
    {
        Invoke("GameOver",waitTime);
    }

    private void GameOver()
    {
        gameStatus = GameStatus.GAMEOVER;
        _gameOverController.display();
        gameEnded?.Invoke();
    }

    public void displayGameWin(float waitTime)
    {
        Invoke("GameWin",waitTime);
    }

    private void GameWin()
    {
        gameStatus = GameStatus.GAMEOVER;
        _gameWinController.display();
        gameEnded?.Invoke();
        
        if(DataController.instance)
        {DataController.instance.SetUnlockLevel(ApplicationController.SelectedLevel);}
    }

    public IEnumerator GameCount(GameObject cutscene, float time)
    {
        yield return new WaitForSeconds(time);
        cutscene.SetActive(false);
        GameStarting(2.30f);
    }
    public void GameStarting(float time)
    {
        gameStatus = GameStatus.STARTING;
        Invoke("InGame",time);
    }

    public void InGame()
    {
        
        gameStatus = GameStatus.INGAME;
		
        if (gameStatus == GameStatus.PAUSED)
        {
            gameResumed?.Invoke();

        }
        else
        {
            gameStarted?.Invoke();
        }

    }

    public void GameResumed()
    {
        if (gameStatus == GameStatus.PAUSED)
        {
            gameStatus = GameStatus.INGAME;
            gameResumed?.Invoke();
        }
        
    }
    
    public void GamePaused()
    {
        gameStatus = GameStatus.PAUSED;
        gamePaused?.Invoke();

    }

    public  void GameRestart()
    {
        gameRestarted?.Invoke();
        _loadingController.display(Scenes.Gameplay);

    }

    public void Home()
    {
        _loadingController.display(Scenes.Mainmenu);

    }

    public void Next()
    {
        
        ApplicationController.SelectedLevel += 1;
        
        if (ApplicationController.SelectedLevel < 10)
        {
            ApplicationController.LastSelectedLevel = ApplicationController.SelectedLevel;
            _loadingController.display(Scenes.Gameplay);
        }

        if (ApplicationController.SelectedLevel >= 10)
        {
            _loadingController.display(Scenes.Mainmenu);

        }

    }

    public void EnemiesCounter()
    {
        

    }
}

