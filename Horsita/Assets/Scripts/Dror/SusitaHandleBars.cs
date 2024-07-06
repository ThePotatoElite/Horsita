using UnityEngine;
using System.Collections;

public class SusitaHandleBars : MonoBehaviour
{
    [SerializeField] PlayerInfoConfig playerConfig;
    [SerializeField] Collider playerCollider;
    GuageBars guageBars;
    private bool _inLiquid = false;
    private Coroutine dryCoroutine;

    void Start()
    {
        //guageBars = GetComponent<GuageBars>();
        playerConfig.CurrentHealth = playerConfig.MaxHealth;
        //playerConfig.CurrentLiquid = playerConfig.MinLiquid;
        //guageBars.SetHealth(playerConfig.MaxHealth); // Initializing health bar
        //guageBars.SetLiquid(playerConfig.MinLiquid); // Initializing liquid bar
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other == playerCollider)
    //    {
    //        if (other.gameObject.CompareTag("Enemy"))
    //        {
    //            float enemyDamage = 0.15f; // Enemy damage need to be initialized --> Enemy.gameObject.damage
    //            //playerConfig.TakeDamage(guageBars, enemyDamage);
    //            SussitaManager.Instance.TakeDamage(enemyDamage);
    //        }
    //        //else if (other.gameObject.CompareTag("Water"))
    //        //{
    //        //    _inLiquid = true;
    //        //    playerConfig.SusitaInPuddle(guageBars, 0.25f);

    //        //    if (dryCoroutine != null)
    //        //    {
    //        //        StopCoroutine(dryCoroutine);
    //        //        dryCoroutine = null;
    //        //    }
    //        //}
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other == playerCollider)
    //    {
    //        if (other.gameObject.CompareTag("Water"))
    //        {
    //            _inLiquid = false;
    //            if (dryCoroutine == null)
    //            {
    //                dryCoroutine = StartCoroutine(DryUpCoroutine(0.05f, 1f)); // Dry 0.05f units every 1 second
    //            }
    //        }
    //    }
    //}

    //public void WaterButtonForTest() // Collision
    //{
    //    Debug.Log($"Susita Velocity {SussitaManager.Instance.AntiDrag}");
    //    playerConfig.SusitaInPuddle(guageBars, 0.25f);
    //}

    //public void DamageButtonForTest() // Collision
    //{
    //    playerConfig.TakeDamage(guageBars, 0.25f);
    //}

    //private void DryUpSusita(float amount)
    //{
    //    if (playerConfig.CurrentLiquid > 0 && !_inLiquid)
    //    {
    //        playerConfig.CurrentLiquid -= amount;
    //    }
    //}
    //private IEnumerator DryUpCoroutine(float amount, float interval)
    //{
    //    while (!_inLiquid && playerConfig.CurrentLiquid > 0)
    //    {
    //        DryUpSusita(amount);
    //        yield return new WaitForSeconds(interval);
    //    }
    //    dryCoroutine = null; // Reset coroutine when done
    //}
}
