using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{


    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _spawnInterval;

    [SerializeField] private int _minX;
    [SerializeField] private int _maxX;

    [SerializeField] private int _minY;
    [SerializeField] private int _maxY;

    [SerializeField] private float _height;


    private float _currentSpawnTimer;
    private int max = 20;
    private int counter = 0;


    private void Update()
    {
        _currentSpawnTimer += Time.deltaTime;
        if(_currentSpawnTimer >= _spawnInterval)
        {
            if(counter < max) { 
                var enemyInstance = Instantiate(_enemyPrefab);
                counter += 1;
                var newPosition = GenerateStartPosition();
                enemyInstance.transform.position = newPosition;
                _currentSpawnTimer = 0;
            }
        }
    }


    private Vector3 GenerateStartPosition()
    {
        var startPos = new Vector3(Random.Range(_minX,_maxX), _height, Random.Range(_minY, _maxY));
        return startPos;
    }
}