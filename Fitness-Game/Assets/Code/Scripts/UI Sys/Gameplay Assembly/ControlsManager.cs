//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//
//public class ControlsManager : MonoBehaviour
//{
//    public GameObject[] SurvivalControlsShow;
//    public GameObject[] SurvivalControlsHide;
//    public GameObject[] SniperControlsShow;
//    public GameObject[] SniperControlsHide;
//    public GameObject[] FullControlsShow;
//    public GameObject[] FullControlsHide;
//    public GameObject ReloadButton;
//    public GameObject ZoomButton;
//
//    public GameObject Gameplay;
//    private void OnEnable()
//    {
//        GameController.gameStarted += CheckControls;
//    }
//    
//    private void OnDisable()
//    {
//        GameController.gameStarted -= CheckControls;
//    }
//
//    void CheckControls()
//    {
//        if (ApplicationController._GameMode == GameMode.compaign)
//        {
//            FullGameControls();
//        }
//
//        if (ApplicationController._GameMode == GameMode.sniper)
//        {
//            SniperGameControls();
//        }
//
//        if (ApplicationController._GameMode == GameMode.survival)
//        {
//            SurvivalGameControls();
//        }
//
//        if (ApplicationController._GameMode == GameMode.zombie)
//        {
//            FullGameControls();
//        }
//        Gameplay.SetActive(true);
//    }
//
//    void FullGameControls()
//    {
//        for (int i = 0; i < FullControlsShow.Length; i++)
//        {
//            FullControlsShow[i].SetActive(true);
//        }
//
//        for (int i = 0; i < FullControlsHide.Length; i++)
//        {
//            FullControlsHide[i].SetActive(false);
//        }
//        
//        if (ApplicationController._GameMode == GameMode.zombie)
//        {
//            ReloadButton.SetActive(false);    
//            ZoomButton.SetActive(false);
//        }
//        
//    }
//
//    void SniperGameControls()
//    {
//        for (int i = 0; i < SniperControlsShow.Length; i++)
//        {
//            SniperControlsShow[i].SetActive(true);
//        }
//
//        for (int i = 0; i < SniperControlsHide.Length; i++)
//        {
//            SniperControlsHide[i].SetActive(false);
//        }
//    }
//
//    void SurvivalGameControls()
//    {
//        for (int i = 0; i < SurvivalControlsShow.Length; i++)
//        {
//            SurvivalControlsShow[i].SetActive(true);
//        }
//
//        for (int i = 0; i < SurvivalControlsHide.Length; i++)
//        {
//            SurvivalControlsHide[i].SetActive(false);
//        }
//    }
//}