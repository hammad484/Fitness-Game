using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateStage : MonoBehaviour
{
    
 #region Instance
 
    private static RotateStage _instance;

    public static RotateStage instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<RotateStage>();
            }

            return _instance;
        }
    }
 
    #endregion

    [SerializeField] private Transform CharacterSelection;
    [SerializeField] private float value ; 
    [SerializeField] private float m_Duration ;
    public AnimationCurve m_Curve;
    private void Awake()
    {
        _instance = this;
    }

    private Coroutine m_timescaleInterpolation = null;

    public void InterpolateEffect(float end )
    {
        if (m_timescaleInterpolation != null)
            StopCoroutine(m_timescaleInterpolation);

        m_timescaleInterpolation = StartCoroutine(InterpolateTimescaleRoutine(end, m_Duration, m_Curve));
    }

    private IEnumerator InterpolateTimescaleRoutine(float end, float duration, AnimationCurve curve )
    {
        float i = 0.0f;
        float current = CharacterSelection.localEulerAngles.y;
   
        float ts = current;

        while (i < 1.0f)
        {
            i += Time.unscaledDeltaTime * 1.0f / duration;
            ts = Mathf.Lerp(current, end, i);//curve.Evaluate(i));
   
            CharacterSelection.eulerAngles = new Vector3(0,ts,0);
            yield return null;
        }
    }
}
