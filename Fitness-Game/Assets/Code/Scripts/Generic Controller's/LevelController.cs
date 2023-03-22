
using System;
using System.Collections;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] GameObject Boy, Girl;
    [SerializeField] private Transform Indoor, Outdoor,LivingRoom;
    [SerializeField] private GameObject IndoorPP, OutdoorPP;
    [SerializeField] private SmoothOrbitCam CameraSystem;
    
    
    [SerializeField] private float _yindoorRotation, _youtdoorRotation,_ylivingRoomRotation;
    [SerializeField] private float _camindoorRotation, _camoutdoorRotation,_camlivingRoomRotation;
    
    private GameObject currentCharacter;
    public ExerciseCharacterController ExerciseCharacterController;
    
    private LevelManager _levelManager;
    private LevelDataManager levelDataManager;
    private InGameController inGameController;
    private AnimationEvent animationEvent;
    
    [HideInInspector] public LevelData currentlevelData;
    [HideInInspector] public int currentExcerciseIndex;
    public static LevelController instance;
    
    private void Awake()
    {
        instance = this;

    }
    private void Start()
    {
        _levelManager=  LevelManager.instance;
        inGameController=InGameController.instance;
        levelDataManager = LevelDataManager.instance;
        currentlevelData = levelDataManager.Levels[ApplicationController.SelectedLevel];
        
        SetPlayerPosition();
       
      
    }
    
    private void SetPlayerPosition()
    {
        if (ApplicationController.LastSelectedCharacter == 0)
        {
            currentCharacter = Instantiate(Boy);
        }
        else
        {
            currentCharacter = Instantiate(Girl);
        }

        if (ApplicationController._GameEnv == GameMode.Indoor)
        {
            
            currentCharacter.transform.parent = Indoor;
            IndoorPP.SetActive(true);
            CameraSystem.transform.localEulerAngles = new Vector3(0,_camindoorRotation,0);
            Invoke("RotateIndoor",.2f);
        }

        if (ApplicationController._GameEnv == GameMode.Outdoor)
        {
            currentCharacter.transform.parent = Outdoor;
            OutdoorPP.SetActive(true);
            CameraSystem.transform.localEulerAngles = new Vector3(0,_camoutdoorRotation,0);
            Invoke("RotateOutdoor",.2f);
        }

        if (ApplicationController._GameEnv == GameMode.LivingRoom)
        {
            currentCharacter.transform.parent = LivingRoom;
            CameraSystem.transform.localEulerAngles = new Vector3(0,_camlivingRoomRotation,0);
            Invoke("RotateLivingRoom",.2f);
        }

        currentCharacter.transform.localPosition = Vector3.zero;
        currentCharacter.transform.eulerAngles=  Vector3.zero;

        CameraSystem.enabled = true;
        CameraSystem.target = currentCharacter.transform;

        ExerciseCharacterController = currentCharacter.GetComponent<ExerciseCharacterController>();
        animationEvent=currentCharacter.GetComponent<AnimationEvent>();
        StartExcercise();

    }

    public void StartExcercise()
    {
        if (ApplicationController.SelectedGameMode == 0)
        {
            StartCoroutine(PerformExcercise());
        }
        else
        {        
            ExerciseCharacterController.Execise(levelDataManager.Tutorials[ApplicationController.TutorialIndex].LevelInfo[0]._excerciseName);
            inGameController.Message(levelDataManager.Tutorials[ApplicationController.TutorialIndex].LevelInfo[0]._message);
            DataController.instance.SetUnlockLevel(ApplicationController.TutorialIndex);
            Excercise excercise = (Excercise) Enum.Parse(typeof(Excercise), 
                levelDataManager.Tutorials[ApplicationController.TutorialIndex].LevelInfo[0]._excerciseName);
            ApplicationController.instance.ExcerciseTrigger(excercise);
            
        }
    }
    
    IEnumerator PerformExcercise() {
 
        for(int i = 0; i < currentlevelData.LevelInfo.Length; i++) {
            //Run the next iteration of the loop.
            ExecutingExcercise(i);
            
            WaitForSeconds wait = new WaitForSeconds(currentlevelData.LevelInfo[i]._time);
            
            if (i == currentlevelData.LevelInfo.Length-1)
            {
                GameController.instance.displayGameWin(currentlevelData.LevelInfo[i]._time);
            }
            
            yield return wait; //Pause the loop.
        }
    }


    public void ExecutingExcercise(int i )
    {
        ExerciseCharacterController.Execise(currentlevelData.LevelInfo[i]._excerciseName);
        currentExcerciseIndex = i;
        
        Excercise excercise = (Excercise) Enum.Parse(typeof(Excercise), currentlevelData.LevelInfo[i]._excerciseName);
        ApplicationController.instance.ExcerciseTrigger(excercise);
        
        if (currentlevelData.LevelInfo[i]._countCheck)
        {
            animationEvent.countValue = 0;
            inGameController.StartCount(currentlevelData.LevelInfo[i]._message);
        }
        if (currentlevelData.LevelInfo[i]._timeCheck)
        {
            inGameController.StartTimer(currentlevelData.LevelInfo[i]._message);
        }
    }

    public void PerformShivering()
    {
        ExerciseCharacterController.Execise($"Shiver{ApplicationController.currentExcercise}");
        Excercise excercise = (Excercise) Enum.Parse(typeof(Excercise), $"Shiver{ApplicationController.currentExcercise}");
        ApplicationController.instance.ExcerciseTrigger(excercise);
        ExerciseCharacterController.EnableIK();
    }

    void RotateIndoor()
    {
        Indoor.eulerAngles = new Vector3(0,_yindoorRotation,0);;
    }
    void RotateOutdoor()
    {
        Outdoor.eulerAngles = new Vector3(0,_youtdoorRotation,0);;
    }
    void RotateLivingRoom()
    {
        LivingRoom.eulerAngles = new Vector3(0,_ylivingRoomRotation,0);;
    }
}
