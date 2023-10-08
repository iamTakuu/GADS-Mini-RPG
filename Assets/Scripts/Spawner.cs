using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] private Battery _batteryPrefab;
    //[SerializeField] private float _spawnInterval = 0.5f;
    
    //private float _timer;
    
   /* private void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= _spawnInterval)
        {
            _timer = 0;
            SpawnBattery();
        }
    }*/
    
    public void SpawnBattery(Battery battery)
    {
        var newBattery = Instantiate(battery, transform.position, Quaternion.identity);
        newBattery.transform.SetParent(transform);
    }
}
