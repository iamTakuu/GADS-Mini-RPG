using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;


[Serializable]
public class SpawnEvent : UnityEvent<Battery>{}
public class SpawnManager : MonoBehaviour
{
  public SpawnEvent spawnEvent0;
  public SpawnEvent spawnEvent1;
  public SpawnEvent spawnEvent2;
  [SerializeField] private Battery _goodBatteryPrefab;
  [SerializeField] private Battery _badBatteryPrefab;
  
  [SerializeField] private float _spawnInterval = 0.5f;
  private float _timer;
  
  private void Update()
  {
    _timer += Time.deltaTime;
    if (_timer >= _spawnInterval)
    {
      _timer = 0;
      SpawnBattery();
    }
  }

  private void SpawnBattery()
  {
    var randBattery = Random.Range(0, 2);
    var randSpawn = Random.Range(0, 3);

    switch (randSpawn)
    {
      case 0:
        spawnEvent0?.Invoke(randBattery == 0 ? _goodBatteryPrefab : _badBatteryPrefab);
        break;
      case 1:
        spawnEvent1?.Invoke(randBattery == 0 ? _goodBatteryPrefab : _badBatteryPrefab);
        break;
      case 2:
        spawnEvent2?.Invoke(randBattery == 0 ? _goodBatteryPrefab : _badBatteryPrefab);
        break;
    }
    
  }
}
