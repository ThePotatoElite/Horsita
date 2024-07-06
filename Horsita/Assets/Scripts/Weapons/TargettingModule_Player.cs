using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TargettingModule_Player : MonoBehaviour
{
    [SerializeField]
    List<Weapon> playerWeapons;

    [SerializeField]
    float targettingRefreshRate;

    List<Enemy> enemies => Enemy.LivingEnemies;

    IEnumerator RefreshTargetting()
    {
        while(true)
        {
            yield return new WaitForSeconds(1 / targettingRefreshRate);
            if (enemies.Count == 0)
                continue;
            if (enemies.Count == 1) //simple case, no math needed
            {
                SetAllWeaponsToTarget(enemies[0].gameObject);
                continue;
            }

            Enemy tgt = null;
            float shortestDistance = float.PositiveInfinity;

            foreach (var enemy in enemies)
            {
                float delta = Vector3.Distance(enemy.transform.position, SussitaManager.Instance.transform.position);
                if (delta < shortestDistance)
                {
                    tgt = enemy;
                    shortestDistance = delta;
                }
            }

            SetAllWeaponsToTarget(tgt.gameObject);
        }
    }

    void SetAllWeaponsToTarget(GameObject tgt)
    {
        foreach (var weapon in playerWeapons)
        {
            weapon.SetTarget(tgt);
        }
    }
}
