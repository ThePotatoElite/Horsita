using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class Enemy : MonoBehaviour, IDamageable
{
    public static List<Enemy> LivingEnemies = new List<Enemy>();
    
    public float Health { get; set; }
    public float attackSpeed = 1f;
    public Vector3 wayPoint;

    // protected Animator animator;
    protected GameObject Sussita => SussitaManager.Instance.gameObject;
    protected float AttackTimer = 0f;
    protected int Damage = 10;

    [SerializeField] protected float speed = 2f;
    [SerializeField] protected float range = .5f;
    [SerializeField] protected float maxHealth = 3f;
    [SerializeField] protected float maxDistance = 5f;

    protected virtual void Awake()
    {
        if(LivingEnemies == null)
        {
            LivingEnemies = new List<Enemy>();
        }

        LivingEnemies.Add(this);
    }
    
    protected virtual void Start()
    {
        EnemySpawned();
        SetNewDestination();
        //Sussita = GameObject.FindGameObjectWithTag("Player");
        // animator = GetComponent<Animator>();


    }

    protected virtual void SetNewDestination()
    {
        wayPoint = new Vector3(UnityEngine.Random.Range(-maxDistance, maxDistance), 0, UnityEngine.Random.Range(-maxDistance, maxDistance));
    }

    //protected virtual void OnDisable()
    //{
    //    EnemyBehaviour.enemyDead?.Invoke(this);
    //}
    
    //protected virtual void OnEnable()
    //{
    //    EnemySpawned();
    //}
    
    protected virtual void EnemySpawned()
    {
        //EnemyBehaviour.enemySpawned?.Invoke(this);
        Health = maxHealth;
    }
    
    public virtual void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            Die();
        }
    }

    protected virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }
        MovementBehavior();
    }

    protected virtual void FlipEnemy()
    {
        Vector3 direction = Sussita.transform.position - transform.position;
        if (direction.x > 0)
            transform.rotation = Quaternion.Euler(0, 90, 0);
        else
            transform.rotation = Quaternion.Euler(0, -90, 0);
    }

    protected virtual void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (AttackTimer > Mathf.Pow(0.9f, attackSpeed))
            {
                other.GetComponentInParent<SussitaManager>().TakeDamage(Damage);
                AttackTimer = 0;
            }
        }
    }

    protected abstract void MovementBehavior();

    protected virtual void Die()
    {
        GameManager.instance.playerLiraAmount += 10; // Add 10 coins for each defeated enemy
        //gameObject.SetActive(false);
        LivingEnemies.Remove(this);

        Destroy(gameObject);
    }
}