using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    public static ScreenResolution Instance;
    // Start is called before the first frame update
 
    private void Awake()
    { 
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;

        Application.targetFrameRate = 60;
		
        if (SystemInfo.systemMemorySize <= 1024)
        {
            int x = (int)(Screen.width * 0.5);
            int y = (int)(Screen.height * 0.5);
            Screen.SetResolution(x,y,true);
        }
        // if (SystemInfo.systemMemorySize <= 2048)
        // {
        //     int x = (int)(Screen.width * 0.35);
        //     int y = (int)(Screen.height * 0.35);
        //     Screen.SetResolution(x,y,true);
        // }
        if (SystemInfo.systemMemorySize > 1024 && SystemInfo.systemMemorySize <= 2048)
        {
            int x = (int)(Screen.width * 0.7);
            int y = (int)(Screen.height * 0.7);
            Screen.SetResolution(x,y,true);
            // PlayerPrefs.HasKey("AdmobAdsFirst");
        }
        

    }
}
