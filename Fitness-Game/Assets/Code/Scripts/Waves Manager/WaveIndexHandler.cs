using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveIndexHandler : MonoBehaviour
{
    public delegate void EnemyDieDelegate();
    public static event EnemyDieDelegate _EnemyDieDelegate;

    public void OnEnable()
    {
        Invoke(nameof(diable),2f);
    }

    public void diable()
    {
        GetComponent<WaveIndexHandler>().enabled = false;
        gameObject.SetActive(false);
    }

    public void OnDisable()
    {
        _EnemyDieDelegate?.Invoke();
    }
}
