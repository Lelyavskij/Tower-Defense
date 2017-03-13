using System;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawn : MonoBehaviour
{
    [SerializeField]
    private EnemyEntity _golemPrefab;
    [SerializeField]
    private EnemyEntity _gydraPrefab;
    [SerializeField]
    private EnemyHpView _enemyHpViewPrefab;
    [SerializeField]
    private Transform[] _wayPoints;
    [SerializeField]
    private Transform _spawnPoint;

    public event Action EnemyCountChanged = delegate { }; 

    private List<EnemyEntity> _enemyes = new List<EnemyEntity>(); 

    public Canvas _canvas;

    private int _waveSize;
    private int _enemyCount;

    private int _enemyInterval;
    private float _timer;

    private bool _isInitilized;

    public int GetEnemyCount
    {
        get { return _enemyes.Count; }
    }

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
        var enemies = FindObjectsOfType<EnemyEntity>();
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].DestroySelf();
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

        EnemyEntity enemy = null;
        var rnd = UnityEngine.Random.Range(0, 2);
        if (rnd == 0)
        {
            enemy = Instantiate(_golemPrefab, _spawnPoint.position, Quaternion.identity) as EnemyEntity;
        }
        else
        {
            enemy = Instantiate(_gydraPrefab, _spawnPoint.position, Quaternion.identity) as EnemyEntity;
        }
        
        enemy.GetComponent<EnemyMovement>().SetPath(_wayPoints);
        _enemyes.Add(enemy);
        EnemyCountChanged();
        enemy.Destroyed += OnEnemyDestroyed;

        hp.SetTarget(enemy);
    }

    private void OnEnemyDestroyed(EnemyEntity entity)
    {
        entity.Destroyed -= OnEnemyDestroyed;
        _enemyes.Remove(entity);
        EnemyCountChanged();
    }
}

