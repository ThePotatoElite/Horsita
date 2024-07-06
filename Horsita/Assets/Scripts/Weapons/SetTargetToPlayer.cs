using UnityEngine;

public class SetTargetToPlayer : MonoBehaviour
{
    [SerializeField]
    Weapon weapon;

    private void Start()
    {
        weapon.SetTarget(SussitaManager.Instance.gameObject);
        Destroy(this); //JUST THIS COMPONENT! not the object itself
    }
}
