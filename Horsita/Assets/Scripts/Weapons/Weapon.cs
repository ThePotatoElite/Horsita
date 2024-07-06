using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Weapon : MonoBehaviour
{
    [SerializeField]
    protected WeaponData weaponData;
    [SerializeField]
    protected BulletData bulletData;

    [SerializeField]
    protected GameObject target; //acquire target or assume/waitfor?
    [SerializeField]
    protected Transform barrelPoint;
    [SerializeField]
    protected Transform barrelRotator;

    protected bool isShooting;
    void Start()
    {
        isShooting = true;
        StartCoroutine(nameof(ShootCoroutine));
    }

   
    protected virtual void Update()
    {
        if(target)
        {
            Vector3 desiredForward = (target.transform.position - barrelRotator.position).normalized;
            float dot = Vector3.Dot(desiredForward, barrelRotator.forward);

            barrelRotator.Rotate(Vector3.right * (dot) * Time.deltaTime * weaponData.turnSpeed);

        }
        //maybe wait for target to be in range?
    }

    protected virtual IEnumerator ShootCoroutine()
    {
        while (isShooting) //temp
        {
            yield return new WaitForSeconds(1 / weaponData.fireRate);
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        Bullet bullet = Instantiate(weaponData.bulletPrefab, barrelPoint.position, barrelPoint.rotation).GetComponent<Bullet>();
        bullet.Shoot(bulletData.flyForce);
        //StartCooldown();
    }

    public virtual void SetTarget(GameObject newTgt)
    {
        target = newTgt;
    }
    //protected virtual void StartCooldown()
    //{

    //}
}
