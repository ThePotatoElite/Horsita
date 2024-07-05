using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [SerializeField] EnemySpawner spawner;
    [SerializeField] List<Enemy> enemies = new List<Enemy>();
    [SerializeField] int currentWave;
    [SerializeField] int waveValue;

    private float _lastSpawnTime;
    private float _roundTimeToSpawn = 10f;

    public enum EnemyTypes
    {
        Flying
    }

    private void Start()
    {
        GenerateEnemyWave(10);
    }

    void GenerateEnemyWave(int waveValue) 
    {
        this.waveValue = waveValue;
        List<Enemy> list = new List<Enemy>();

        if (waveValue > 0)
        {
            this.waveValue--;
            spawner.SpawnFlyingEnemy(); // Assuming we only have flying enemies for now
        }
    }

    void Update()
    {
        if (Time.time > _lastSpawnTime + _roundTimeToSpawn)
        {
            GenerateEnemyWave(waveValue);
            _lastSpawnTime = Time.time;
        }
    }
}