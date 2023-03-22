
using System.Collections;
using UnityEngine;

public class SplashLoadingController : MonoBehaviour

{
    #region Instance
 
    private static SplashLoadingController _instance;

    public static SplashLoadingController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SplashLoadingController>();
            }

            return _instance;
        }
    }
 
    #endregion
    
    
    #region Initialization

     SceneMngmtController _sceneMngmtController;

     public GameObject Mainpanel;
     public GameObject loading,loadad;
     public int TimeToLoad;
    #endregion
    
 
    private void Awake()
    {
        _instance = this;
  
    }


    private void Start()
    {
        _sceneMngmtController = SceneMngmtController.instance;
        StartCoroutine(LoadScene());

    }

    public IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1f);
        _sceneMngmtController.LoadScene(Scenes.Mainmenu);
        
  }
}
