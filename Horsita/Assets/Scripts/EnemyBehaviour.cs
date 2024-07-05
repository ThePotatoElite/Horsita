using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyBehaviour : MonoBehaviour
{
        public static Action<Enemy> enemySpawned;
        public static Action<Enemy> enemyDead;
        // Every time the number of enemies change,the EnemyManger calls an event to let everyone know
        public static Action<List<Enemy>> listOfEnemyChanged;
        public static List<Enemy> listOfEnemies;
        
        void Awake()
        {
            if (listOfEnemies == null)
            {
                listOfEnemies = new List<Enemy>();
            }
        }
        void OnEnable()
        {
            enemySpawned += AddEnemyToList;
            enemyDead += RemoveEnemyFromList;
        }
        void OnDisable()
        {
            enemySpawned -= AddEnemyToList;
            enemyDead -= RemoveEnemyFromList;
        }
        public void AddEnemyToList(Enemy enemy)
        {
            listOfEnemies.Add(enemy);
            listOfEnemyChanged?.Invoke(listOfEnemies);
        }
        public void RemoveEnemyFromList(Enemy enemy)
        {
            listOfEnemies.Remove(enemy);
            listOfEnemyChanged?.Invoke(listOfEnemies);
        }
}