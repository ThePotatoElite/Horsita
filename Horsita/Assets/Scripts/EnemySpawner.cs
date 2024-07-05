using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject flyingEnemyPrefab;
    [SerializeField] GameObject fireBallPrefab;
    [SerializeField] float flyingEnemyInterval = 3f;
    [SerializeField] float timeBetweenWaves = 9f;
    private Transform _targetArea;

    void Start()
    {
        _targetArea = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(flyingEnemyInterval);
        int waveSize = 1;
        while (true)
        {
            for (int i = 0; i < waveSize; i++)
            {
                SpawnFlyingEnemy();
            }
            yield return new WaitForSeconds(timeBetweenWaves);
            waveSize += 1;
        }
    }

    public void SpawnFlyingEnemy()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-9.8f, 1f), Random.Range(5f, 6.7f), Random.Range(-9.8f, 1f));
        GameObject newFlyingEnemy = Instantiate(flyingEnemyPrefab, spawnPosition, Quaternion.identity);

        FlyingEnemy flyingEnemyScript = newFlyingEnemy.GetComponent<FlyingEnemy>();
        if (flyingEnemyScript != null)
        {
            flyingEnemyScript.SetFireBall(fireBallPrefab);
            flyingEnemyScript.SetTargetArea(_targetArea);
        }
    }
}