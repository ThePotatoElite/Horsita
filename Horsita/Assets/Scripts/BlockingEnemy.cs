using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockingEnemy : Enemy
{
    protected bool isBlocking = false;
    protected bool isDead = false;

    private Vector3 _targetArea;
    [SerializeField] protected float blockDuration = 1f;
    [SerializeField] protected float walkSpeed = 10f;

    protected override void Start()
    {
        base.Start();
        // animator = GetComponent<Animator>();
        Transform sussitaTransform = GameObject.FindGameObjectWithTag("Player").transform;
        _targetArea = new Vector3(sussitaTransform.position.x, sussitaTransform.position.y / 2, sussitaTransform.position.z);
        MovementBehavior();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        GameManager.instance.playerLiraAmount += 5; // Add 5 lira coins for each death
        StopBlocking();
    }

    protected override void MovementBehavior()
    {
        if (!isDead)
        {
            if (!isBlocking)
            {
                WalkTowardsVehicle();
            }
        }
    }

    void WalkTowardsVehicle()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetArea, walkSpeed * Time.deltaTime);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!isBlocking)
            {
                StartBlocking();
            }
        }
    }

    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        if (other.CompareTag("Player"))
        {
            if (!isBlocking)
            {
                StartBlocking();
            }
        }
    }

    protected virtual void StartBlocking()
    {
        isBlocking = true;
        // animator.SetBool("isBlocking", true);
        Invoke(nameof(StopBlocking), blockDuration);
    }

    protected virtual void StopBlocking()
    {
        isBlocking = false;
        // animator.SetBool("isBlocking", false);
    }

    public override void TakeDamage(float damageAmount)
    {
        if (isBlocking)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.GetComponent<SussitaManager>().TakeDamage(damageAmount);
            }
        }
        else
        {
            base.TakeDamage(damageAmount);
            if (Health <= 0)
            {
                isDead = true;
                // animator.SetBool("isDead", true);
                // Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
                Destroy(gameObject);
            }
        }
    }
    
    public void SetTargetArea(Vector3 target)
    {
        _targetArea = target;
    }
}