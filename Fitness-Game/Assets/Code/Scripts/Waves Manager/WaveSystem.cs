using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaveSystem : MonoBehaviour
{
 #region Instance
 
    private static WaveSystem _instance;

    public static WaveSystem instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<WaveSystem>();
            }

            return _instance;
        }
    }
 
    #endregion

    public GameObject EnemyA, EnemyB, EnemyC;
    public int maxCountEnemyType;
    public Wave[] Waves;
    public UnityEvent OnComplete;
    public List<GameObject> EnemiesA,EnemiesB,EnemiesC;
    
    private GameObject enemy;
    private int currentWaveIndex,currentEnemyAIndex,currentEnemyBIndex,currentEnemyCIndex,currentEnemyDieIndex;

   

    
    private void OnEnable()
    {
        WaveIndexHandler._EnemyDieDelegate += checkNextWave;
    }

    private void OnDisable()
    {
        WaveIndexHandler._EnemyDieDelegate -= checkNextWave;
    }

    private void Awake()
    {
        _instance = this;
        IntantiateEnemyType();
    }

    private int i,EnemiesLength;
    
    public void SpawnWave()
    {

        if (Waves.Length <= 0 || Waves.Length <= currentWaveIndex)
        {
            OnComplete.Invoke();
            return;
        }

        EnemiesLength = Waves[currentWaveIndex].EnemiesDetails.Length;
        
        if(EnemiesLength<=0)
            return;
        
        for ( i = 0; i < EnemiesLength; i++)
        {
            enemy = setActiveEnemyType();
            enemy.GetComponent<WaveIndexHandler>().enabled=true;
            enemy.SetActive(true);
            enemy.transform.position = Waves[currentWaveIndex].EnemiesDetails[i].Enemypos.transform.position;
            enemy.transform.eulerAngles = Waves[currentWaveIndex].EnemiesDetails[i].Enemypos.transform.eulerAngles;
        }

        currentWaveIndex++;
    }

    public GameObject setActiveEnemyType()
    {
        if (Waves[currentWaveIndex].EnemiesDetails[i]._EnemyType == EnemiesDetail.EnemyType.A)
        {
            currentEnemyAIndex++;
            if (currentEnemyAIndex > maxCountEnemyType)
                currentEnemyAIndex = 1;
                return EnemiesA[currentEnemyAIndex-1];
        }
        else if  (Waves[currentWaveIndex].EnemiesDetails[i]._EnemyType == EnemiesDetail.EnemyType.B)
        {
            currentEnemyBIndex++;
            if (currentEnemyBIndex > maxCountEnemyType)
                currentEnemyBIndex = 1;
            return EnemiesB[currentEnemyBIndex-1];
        }
        else
        {
            currentEnemyCIndex++;
            if (currentEnemyCIndex > maxCountEnemyType)
                currentEnemyCIndex = 1;
            return EnemiesC[currentEnemyCIndex-1];
        }
    }
    
    public void IntantiateEnemyType()
    {
        for (int j = 0; j < maxCountEnemyType; j++)
        {
            enemy=Instantiate(EnemyA);
            enemy.SetActive(false);
            enemy.AddComponent<WaveIndexHandler>();
            EnemiesA.Add(enemy);
            
            enemy=Instantiate(EnemyB);
            enemy.SetActive(false);
            enemy.AddComponent<WaveIndexHandler>();
            EnemiesB.Add(enemy); 
            
            enemy=Instantiate(EnemyC);
            enemy.SetActive(false); 
            enemy.AddComponent<WaveIndexHandler>();
            EnemiesC.Add(enemy);
            
        }
        
        SpawnWave();
    }
    
    public IEnumerator SpawnNextWave()
    {
        Waves[currentWaveIndex-1].OnComplete.Invoke();
    
        yield return new WaitForSeconds(Waves[currentWaveIndex-1].nextwaveTime);
        SpawnWave();
    }

    public void checkNextWave()
    {
        currentEnemyDieIndex++;
       
        if (currentEnemyDieIndex >= Waves[currentWaveIndex - 1].EnemiesDetails.Length)
        {
        
            StartCoroutine(SpawnNextWave());
            currentEnemyDieIndex = 0;
        }
    }


}
[Serializable]
public class Wave
{
    public EnemiesDetail[] EnemiesDetails;
    public int nextwaveTime;
    public UnityEvent OnComplete;
}

[Serializable]
public class EnemiesDetail
{
    public enum EnemyType
    {
        A,
        B,
        C
    }

    public EnemyType _EnemyType;
    public Transform Enemypos;
}