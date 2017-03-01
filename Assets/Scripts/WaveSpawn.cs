using UnityEngine;
using System.Collections;

public class WaveSpawn : MonoBehaviour
{
    public int WaveSize;

    public GameObject EnemyPrefab;
     
    public float EnemyInterval;

    public Transform spawnPoint;

    public float startTime;

    public Transform[] WayPoints;

    public GameObject HP;

    int enemyCount = 0;

    public GameObject canvas;

    private float timer;

    private void Update()
    {
        if (enemyCount == WaveSize)
        {
            return;
        }

        timer += Time.deltaTime;
        if (timer > EnemyInterval)
        {
            SpawnEnemy();
            timer = 0;
        }
    }

    private void SpawnEnemy()
    {
        enemyCount++;
        var enemy = Instantiate(EnemyPrefab, spawnPoint.position, Quaternion.identity) as GameObject;
        enemy.GetComponent<MoveToWavePoints>().waypoints = WayPoints;
        var hp = Instantiate(HP, Vector3.zero, Quaternion.identity) as GameObject;
        hp.transform.SetParent(canvas.transform);
        hp.GetComponent<HpBar>().enemy = enemy;
        enemy.GetComponent<MoveToWavePoints>().hp = hp;

    }
}
