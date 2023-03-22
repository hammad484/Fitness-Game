using System;
using System.Collections;
using System.Collections.Generic;
using RootMotion.FinalIK;
using UnityEngine;

public class IkManager : MonoBehaviour
{
 #region Instance
 
    private static IkManager _instance;

    public static IkManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<IkManager>();
            }

            return _instance;
        }
    }
 
    #endregion

 
    public FullBodyBipedIK fullBodyBipedIk;

    public WeightIK[] WeightIk;




   private void Awake()
    {
        _instance = this;
  
    }

   public void setIkPunch()
    {
        fullBodyBipedIk.enabled = true;
        resetIk();
        fullBodyBipedIk.solver.leftFootEffector.target = WeightIk[0].LTarget;
        fullBodyBipedIk.solver.leftFootEffector.positionWeight = WeightIk[0].LPositionWeight;
        fullBodyBipedIk.solver.rightFootEffector.target = WeightIk[0].RTarget;
        fullBodyBipedIk.solver.rightFootEffector.positionWeight = WeightIk[0].RPositionWeight;
        fullBodyBipedIk.solver.rightFootEffector.rotationWeight = WeightIk[0].RRotationWeight;
    }
   public void setIkPushup()
    {
        
        fullBodyBipedIk.enabled = true;
        resetIk();
        fullBodyBipedIk.solver.leftHandEffector.target = WeightIk[1].LTarget;
        fullBodyBipedIk.solver.leftHandEffector.positionWeight = WeightIk[1].LPositionWeight;
        fullBodyBipedIk.solver.leftHandEffector.rotationWeight = WeightIk[1].LRotationWeight;
        fullBodyBipedIk.solver.rightHandEffector.target = WeightIk[1].RTarget;
        fullBodyBipedIk.solver.rightHandEffector.positionWeight = WeightIk[1].RPositionWeight;
        fullBodyBipedIk.solver.rightHandEffector.rotationWeight = WeightIk[1].RRotationWeight;
     
    }


   public void resetIk()
   {
       fullBodyBipedIk.solver.leftHandEffector.positionWeight = 
       fullBodyBipedIk.solver.leftHandEffector.rotationWeight = 
       fullBodyBipedIk.solver.rightHandEffector.positionWeight = 
       fullBodyBipedIk.solver.rightHandEffector.rotationWeight = 
       fullBodyBipedIk.solver.leftFootEffector.positionWeight = 
       fullBodyBipedIk.solver.leftFootEffector.rotationWeight = 
       fullBodyBipedIk.solver.rightFootEffector.positionWeight = 
       fullBodyBipedIk.solver.rightFootEffector.rotationWeight = 0;
   }
  
}

[Serializable]
public struct WeightIK
{
    public string Name; 
    public Transform LTarget, RTarget;
    public float LPositionWeight,LRotationWeight, RPositionWeight,RRotationWeight;
}