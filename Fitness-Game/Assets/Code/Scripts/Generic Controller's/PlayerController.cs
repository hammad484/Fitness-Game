using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   public GameObject SurvivalTPSPlayer;
   // public GameObject SniperTPSPlayer;
   public GameObject FPSPlayer;


   public static PlayerController instance;

   private void Awake()
   {
      instance = this;
   }

   private void Start()
   {

   }




}
