using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField]
    private EnemyEntity _enemyPrefab;
    [SerializeField]
    private EnemyHpView _enemyHpViewPrefab;
    [SerializeField]
    private Transform[] _wayPoints;
    [SerializeField]
    private Transform _spawnPoint;

    private List<EnemyEntity> _enemyes = new List<EnemyEntity>(); 

    public Canvas _canvas;

    private int _waveSize;
    private int _enemyCount;

    private int _enemyInterval;
    private float _timer;

    private bool _isInitilized;

    public void StartGame(int waveSize, int interval)
    {
        _waveSize = waveSize;
        _enemyInterval = interval;
        _isInitilized = true;
        _enemyCount = 0;
    }

    public void FinishGame()
    {
        _isInitilized = false;
        for (int i = 0; i < _enemyes.Count; i++)
        {
            _enemyes[i].DestroySelf();
        }
    }

    private void Update()
    {
        if (!_isInitilized)
        {
            return;
        }

        if (_enemyCount == _waveSize)
        {
            return;
        }

        _timer += Time.deltaTime;
        if (_timer > _enemyInterval)
        {
            SpawnEnemy();
            _timer = 0;
        }
    }

    private void SpawnEnemy()
    {
        _enemyCount++;
        var hp = Instantiate(_enemyHpViewPrefab, Vector3.zero, Quaternion.identity) as EnemyHpView;
        hp.transform.SetParent(_canvas.transform);

        var enemy = Instantiate(_enemyPrefab, _spawnPoint.position, Quaternion.identity) as EnemyEntity;
        enemy.GetComponent<EnemyMovement>().SetPath(_wayPoints);
        enemy.Destroyed += OnEnemyDestroyed;
        _enemyes.Add(enemy);

        hp.SetTarget(enemy);
    }

    private void OnEnemyDestroyed(EnemyEntity entity)
    {
        entity.Destroyed -= OnEnemyDestroyed;
        _enemyes.Remove(entity);
    }
}

