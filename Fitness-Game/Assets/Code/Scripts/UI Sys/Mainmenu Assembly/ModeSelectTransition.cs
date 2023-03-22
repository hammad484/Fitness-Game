using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ModeSelectTransition : MonoBehaviour
{
    public Button[] ModeButtons;
    public Animator[] ModeRenderButtons;
    [SerializeField] private float value;
    [SerializeField] private float Duration;
    public void OnButtonClick(int index)
    {
        ModeButtons[index].transform.DOScale(value, Duration);
        if (ModeRenderButtons.Length > 0)
            ModeRenderButtons[index].enabled = true;

        for (int i = 0; i < ModeButtons.Length; i++)
        {
            if (i != index)
            {
                ModeButtons[i].transform.DOScale(1f, Duration);
                if (ModeRenderButtons.Length > 0)
                    ModeRenderButtons[i].enabled = false;
            }
        }
    }

    
}
