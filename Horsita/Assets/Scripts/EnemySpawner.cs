using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    //[SerializeField] Vector2 spawnZone_TopLeft;
    //[SerializeField] Vector2 spawnZone_BottomRight;
    [SerializeField] Vector2 spawnZone_z_Range;
    [SerializeField] Transform[] spawnPoints;

    [SerializeField] GameObject flyingEnemyPrefab;
    // [SerializeField] GameObject fireBallPrefab;
    [SerializeField] float flyingEnemyInterval = 3f; // FlyingEnemy Spawn Delay
    // [SerializeField] float timeBetweenWaves = 9f;
    private Transform _targetArea;
    private bool isSpawning = false;

    void Start()
    {
        //_targetArea = GameObject.FindGameObjectWithTag("Player").transform;
        _targetArea = SussitaManager.instance.gameObject.transform;
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
        //Vector3 spawnPosition = new Vector3(Random.Range(-650f, 700f), Random.Range(540f, 850f), -90f);
        //Vector3 spawnPosition = new Vector3(Random.Range(spawnZone_TopLeft.x, spawnZone_BottomRight.x), Random.Range(spawnZone_BottomRight.y, spawnZone_TopLeft.y), Random.Range(spawnZone_z_Range.x, spawnZone_z_Range.y));
        Vector3 spawnPosition = spawnPoints[Random.Range(0,spawnPoints.Length)].position;
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