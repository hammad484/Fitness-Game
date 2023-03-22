using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class ExerciseCharacterController : MonoBehaviour
{
    #region Instance

    private static ExerciseCharacterController _instance;

    public static ExerciseCharacterController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ExerciseCharacterController>();
            }

            return _instance;
        }
    }

    #endregion


    [SerializeField] private Animator characterAnimator;

    [SerializeField] private GameObject PunchingBalls;
    [SerializeField] private GameObject PushupBalls;
    [SerializeField] private IkManager ikManager;

    
    
    
    private void Awake()
    {
        _instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        characterAnimator = GetComponent<Animator>();
        characterAnimator.applyRootMotion = true;
        SetupTutorial();
    }


    public void Execise(string excercise)
    {
        ikManager.resetIk();
        characterAnimator.SetTrigger(excercise);
       
    }

    public void SetupTutorial()
    {
        if (ApplicationController.SelectedGameMode == 1)
        {
            if (ApplicationController.TutorialIndex == 0)
            {
                PunchingBalls.SetActive(true);
            }
            if (ApplicationController.TutorialIndex == 1)
            {
                PushupBalls.SetActive(true);
            }
        }
    }

    public void EnableIK()
    {
        if (ApplicationController.currentExcercise ==Excercise.ComboPunch)
        {
            ikManager.setIkPunch();
        }

        else  if (ApplicationController.currentExcercise ==Excercise.Pushups)
        {
            ikManager.setIkPushup();
        }
        else  if (ApplicationController.currentExcercise ==Excercise.ShiverPushups)
        {
            ikManager.setIkPushup();
        }
    }

}


public enum Excercise
{
    ComboPunch,
    Bicycle,
    Pushups,
    QuadPunch,
    Situps,
    ShiverPushups
    
}