using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
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
  private bool _isGameActive = true;
  
  private float spawnerNoiseValue;
  private float batteryNoiseValue;
  [SerializeField][Range(0.1f,2f)]private float spawnerNoiseScale = 0.8f;
  [SerializeField][Range(0.5f,2f)]private float batteryNoiseScale = 0.8f;
  private int selectedSpawn = 0;
  private int numberOfSpawns = 3;
  private int selectedBattery = 0;
  private int numberOfBatteries = 2;
  
  private void Update()
  {
    if (!_isGameActive) return;
    
    spawnerNoiseValue = Mathf.PerlinNoise(Time.time * spawnerNoiseScale, 0);
    batteryNoiseValue = Mathf.PerlinNoise(Time.time * batteryNoiseScale, 0);
    _timer += Time.deltaTime;
    if (_timer >= _spawnInterval)
    {
      selectedSpawn = Mathf.FloorToInt(spawnerNoiseValue * numberOfSpawns);
      selectedSpawn = Mathf.Clamp(selectedSpawn, 0, numberOfSpawns - 1);
      
      selectedBattery = Mathf.FloorToInt(batteryNoiseValue * numberOfBatteries);
      selectedBattery = Mathf.Clamp(selectedBattery, 0, numberOfBatteries - 1);
      _timer = 0;
      SpawnBattery();
    }
  }

  private void SpawnBattery()
  {

    switch (selectedSpawn)
    {
      case 0:
        spawnEvent0?.Invoke(selectedBattery == 0 ? _goodBatteryPrefab : _badBatteryPrefab);
        break;
      case 1:
        spawnEvent1?.Invoke(selectedBattery == 0 ? _goodBatteryPrefab : _badBatteryPrefab);
        break;
      case 2:
        spawnEvent2?.Invoke(selectedBattery == 0 ? _goodBatteryPrefab : _badBatteryPrefab);
        break;
    }
    
  }
  
  public void StartGame() => _isGameActive = true;

  public void StopGame() => _isGameActive = false;
}
