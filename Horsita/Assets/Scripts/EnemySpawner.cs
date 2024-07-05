using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject flyingEnemyPrefab;
    // [SerializeField] GameObject fireBallPrefab;
    [SerializeField] float flyingEnemyInterval = 3f; // FlyingEnemy Spawn Delay
    [SerializeField] float timeBetweenWaves = 9f;
    private Transform _targetArea;
    private bool isSpawning = false;

    void Start()
    {
        _targetArea = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (!isSpawning)
            {
                isSpawning = true;
                SpawnFlyingEnemy();
            }
            yield return new WaitForSeconds(flyingEnemyInterval);
            isSpawning = false;
        }
    }

    public void SpawnFlyingEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-650f, 700f), Random.Range(540f, 850f), -90f);
        GameObject newFlyingEnemy = Instantiate(flyingEnemyPrefab, spawnPosition, Quaternion.identity);
        FlyingEnemy flyingEnemyScript = newFlyingEnemy.GetComponent<FlyingEnemy>();
        if (flyingEnemyScript != null)
        {
            // flyingEnemyScript.SetFireBall(fireBallPrefab);
            flyingEnemyScript.SetTargetArea(_targetArea);
            // flyingEnemyScript.FireBallHitSussita(newFlyingEnemy);
        }
    }
}