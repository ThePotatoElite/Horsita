using UnityEngine;

public class FlyingEnemy : Enemy
{
    protected bool isShooting = false;
    protected float stopTimer = 0f;

    // public GameObject fireBallPrefab;
    // public Transform fireBallStartPosition;

    private Transform _targetArea;
    [SerializeField] protected float shootInterval = 3f;

    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(StartShooting), 0f, shootInterval);
        //_targetArea = GameObject.FindGameObjectWithTag("Player").transform;
        _targetArea = SussitaManager.instance.gameObject.transform;

        MovementBehavior();
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        GameManager.instance.playerLiraAmount += 10; // Add 10 lira coins for each death
        StopShooting();
    }
    
    //protected override void Update()
    //{
    //    base.Update();
    //    MovementBehavior();
    //}

    protected override void SetNewDestination()
    {
        float randomX = UnityEngine.Random.Range(-150, 150);
        float randomY = UnityEngine.Random.Range(0, 100);
        wayPoint = new Vector3(randomX, randomY, 0);
    }

    protected override void MovementBehavior()
    {
        if (!isShooting)
        {
            MoveAroundTargetArea();
        }
    }

    void MoveAroundTargetArea()
    {
        transform.position = Vector3.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if (stopTimer >= shootInterval)
        {
            SetNewDestination();
            stopTimer = 0f;
        }
        else
        {
            stopTimer += Time.deltaTime;
        }
    }

    void StopMoving()
    {
        stopTimer = 3f;
        speed = 0f;
    }

    void ResumeMoving()
    {
        speed = 100f;
        SetNewDestination();
    }

    protected virtual void StartShooting()
    {
        isShooting = true;

        Debug.Log("Fire");
        // animator.SetBool("isShooting", true);
        StopMoving();
        Invoke(nameof(StopShooting), shootInterval);
        // GameObject fireBallInstance = Instantiate(fireBallPrefab, fireBallStartPosition.position, Quaternion.identity);
        // fireBallInstance.GetComponent<FireballTravel>().Initialize(this);
    }

    protected virtual void StopShooting()
    {
        isShooting = false;
        /*
        if (animator != null)
        {
            animator.SetBool("isShooting", false);
        }
        */
        ResumeMoving();
    }

    protected override void OnTriggerStay(Collider other)
    {
        base.OnTriggerStay(other);
        if (other.CompareTag("Player"))
        {
            if (AttackTimer > Mathf.Pow(0.9f, attackSpeed))
            {
                other.GetComponentInParent<SussitaManager>().TakeDamage(Damage);
                AttackTimer = 0;
            }
        }
    }
    /*
    public void SetFireBall(GameObject fireBall)
    {
        fireBallPrefab = fireBall;
    }
    */
    public void SetTargetArea(Transform target)
    {
        _targetArea = target;
    }
}