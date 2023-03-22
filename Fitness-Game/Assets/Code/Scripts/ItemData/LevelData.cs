using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu]
public class LevelData : ScriptableObject
{

	public LevelInfo[] LevelInfo;

}
[Serializable]
public struct LevelInfo
{
	public string _excerciseName;
	public string _message;
	public float _time;
	public int _shiverIndex;
	public bool _timeCheck, _countCheck,Shiver;
	
	

}