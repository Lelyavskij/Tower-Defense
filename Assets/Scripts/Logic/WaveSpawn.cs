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

    public Canvas _canvas;

    private int _waveSize;
    private int _enemyCount;

    private int _enemyInterval;
    private float _timer;

    private void Start()
    {
        _waveSize = 5;
        _enemyInterval = 2;
    }

    private void Update()
    {
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
        hp.SetTarget(enemy);
    }
}

