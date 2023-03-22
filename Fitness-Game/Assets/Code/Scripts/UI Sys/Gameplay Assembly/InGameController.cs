
using System;
using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InGameController : MonoBehaviour
{
    #region Instance
 
    private static InGameController _instance;

    public static InGameController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InGameController>();
            }

            return _instance;
        }
    }
 
    #endregion


    public GameObject CountLabel;
    public GameObject ObjectiveLabel;
    public TextMeshProUGUI MessageText;
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI _countText;


    private float _timer;
    private float _totalTimer;


    private bool Counttime,CountIndex;


    private void OnEnable()
    {
        GameController.gamePaused += pauseClicked;
        GameController.gameResumed += resumeClicked;
        GameController.gameStarted += startedClicked;
        GameController.gameEnded += endedClicked;
    }

    private void OnDisable()
    {
        
        GameController.gamePaused -= pauseClicked;
        GameController.gameResumed -= resumeClicked;
        GameController.gameStarted -= startedClicked;
        GameController.gameEnded -= endedClicked;
    }
    
    private void Awake()
    {
        _instance = this;
    }
    public void Start()
    {
        _timer = 0;

        SetLevel();
    }
    
    public void pauseClicked()
    {
    }
    public void resumeClicked()
    {
    }

  

    public void startedClicked()
    {
       
    }
    public void endedClicked()
    {
        CountLabel.SetActive(false);
        ExerciseCharacterController.instance.Execise("Idle");

    }

    private void Update()
    {
        if (GameController.gameStatus == GameStatus.INGAME && Counttime)
        {
            _timer += Time.deltaTime;
            TimerText.text = $"{Mathf.Floor(_timer / 60).ToString("00")}:{Mathf.FloorToInt(_timer % 60).ToString("00")}";
        }
    }

    public void Message(string message)
    {
        MessageText.text = message;
    }

    public void SetLevel()
    {
        if (ApplicationController.SelectedGameMode == 0)
        {
            CountLabel.SetActive(true);
            ObjectiveLabel.SetActive(true);

        }
        else
        {
            CountLabel.SetActive(false);
            ObjectiveLabel.SetActive(true);
        }
    }

    public void StartTimer(string message)
    {
        TimerText.text = "00:00";
        _timer = 0;
        TimerText.gameObject.SetActive(true);
        _countText.gameObject.SetActive(false);
        Message(message);
    }
    public void StartCount(string message)
    {
        _countText.text = "0";
        TimerText.gameObject.SetActive(false);
        _countText.gameObject.SetActive(true);
        Message(message);
    }


    public void ChooseTimer(bool t)
    {
        Counttime = t;
        CountIndex = !t;
        
    }
}
