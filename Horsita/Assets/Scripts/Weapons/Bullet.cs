using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    Collider col;
    [SerializeField]
    GameObject explosionPrefab;
    [SerializeField]
    bool isPlayerBullet; //bad, but whatever
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float ttl = 4f;

    float damage;
   
    public void Shoot(float force, float dmg)
    {
        damage = dmg;
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
        Destroy(gameObject, ttl);
    }

    private void Update()
    {
        transform.forward = rb.linearVelocity.normalized;
    }

    //collision stuff
    private void OnCollisionEnter(Collision collision)
    {
        if (isPlayerBullet)
        {
            //hit enemies!
            Enemy hit = collision.gameObject.GetComponent<Enemy>();
            if (hit != null)
            {
                hit.TakeDamage(damage);
            }
        }
        else
        {
            //if (hit != null)
            //{
            SussitaManager.instance.TakeDamage(damage);
            //}
        }
            Explode();
    }

    protected virtual void Explode()
    {
        col.enabled = false;
        explosionPrefab.SetActive(true);
        //spawn vfx and destroy self
        Invoke(nameof(DestroySelf), .5f); //should be timed for mid-explosion
    }

    protected virtual void DestroySelf()
    {
        Destroy(gameObject);
    }
    
    //destroy self stuff
}
