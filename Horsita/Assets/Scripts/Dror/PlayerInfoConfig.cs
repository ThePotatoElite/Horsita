using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfig", menuName = "ScriptableObject/PlayerData|Stats")] // You can now Create new Road file under "ScriptableObject"

public class PlayerInfoConfig : ScriptableObject
{
    [Header("Data Fields")]
    public int MaxHealth = 1;
    public int MinLiquid = 0;
    public float CurrentHealth;
    public float CurrentLiquid;

    public void TakeDamage(GuageBars healthBar, float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) Die();
        healthBar.SetHealth(CurrentHealth);
        Debug.Log($"Player taking : {damage} | HP : {CurrentHealth}");
    }

    //public void SusitaInPuddle(GuageBars liquidBar, float litter)
    //{
    //    UpdateDragAndLiquid(litter);
    //    liquidBar.SetLiquid(CurrentLiquid);
    //}

    public void Die()
    {
        //Game over scene etc...
        Debug.Log("Player Died - Loading Game Over Scene");
    }
    private void UpdateDragAndLiquid(float litter)
    {
        CurrentLiquid += litter;
        if (CurrentLiquid == 0)
        {
            SussitaManager.Instance.AntiDrag = 1f;
        }
        else if (CurrentLiquid <= 25)
        {
            SussitaManager.Instance.AntiDrag = 0.75f;
            SussitaManager.Instance.ChangeVelocity(0.25f);
        }
        else if (CurrentLiquid <= 50)
        {
            SussitaManager.Instance.AntiDrag = 0.50f;
            SussitaManager.Instance.ChangeVelocity(0.50f);
        }
        else if (CurrentLiquid <= 75)
        {
            SussitaManager.Instance.AntiDrag = 0.25f;
            SussitaManager.Instance.ChangeVelocity(0.75f);
        }
        else
        {
            // if (_currentLiquid <= 100) When the liquid bar full 
            SussitaManager.Instance.AntiDrag = 0.01f;
            SussitaManager.Instance.ChangeVelocity(0.99f);
        }
    }
}
