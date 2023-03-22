using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
  
    private InGameController InGameController;
    private LevelController levelController;

    private LevelData currentlevelData;

    // Start is called before the first frame update
    void Start()
    {
        InGameController = InGameController.instance;
        levelController = LevelController.instance;
        currentlevelData = levelController.currentlevelData;
    }

   [HideInInspector] public int countValue;

    public void AddCount(int x)
    {
        int i = levelController.currentExcerciseIndex;


        if (ApplicationController.currentExcercise == (Excercise) x)
        {
            countValue = countValue + 1;
            InGameController._countText.text = countValue.ToString();
            if (currentlevelData.LevelInfo[i].Shiver && countValue==currentlevelData.LevelInfo[i]._shiverIndex)
            {
                levelController.PerformShivering();
            }
        }
    }

    
    public void ExecuteAnimation(int x)
    {

        int i = levelController.currentExcerciseIndex;
       
        
        if (ApplicationController.currentExcercise == (Excercise)x)
        {
           InGameController.ChooseTimer(currentlevelData.LevelInfo[i]._timeCheck);
          levelController.ExerciseCharacterController.EnableIK();
        }

    }
}
