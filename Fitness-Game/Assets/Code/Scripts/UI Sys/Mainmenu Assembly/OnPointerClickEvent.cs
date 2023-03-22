using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class OnPointerClickEvent : MonoBehaviour , IPointerClickHandler
{
    public UnityEvent OnClickEvent;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        OnClickEvent.Invoke();
    }
}
