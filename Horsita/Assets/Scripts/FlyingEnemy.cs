using UnityEngine;

public class FlyingEnemy : Enemy
{
    protected bool isShooting = false;
    protected float stopTimer = 0f;
    protected float shootingRange = 0f;
    [SerializeField] AudioClip fireShoot;
    [SerializeField] AudioClip waspDeath;
    [SerializeField] AudioClip waspAlive;
    private AudioSource audioSource; // Reference to the AudioSource component

    public GameObject fireBallPrefab;
    public Transform fireBallStartPosition;

    private Transform _targetArea;
    [SerializeField] protected float shootInterval = 3f;
    [SerializeField] private Animator _animator;
    

    protected override void Start()
    {
        base.Start();
        // animator = GetComponent<Animator>();
        InvokeRepeating(nameof(StartShooting), 0f, shootInterval);
        //_targetArea = GameObject.FindGameObjectWithTag("Player").transform;
        _targetArea = SussitaManager.Instance.gameObject.transform;
        audioSource = GetComponent<AudioSource>(); // Get the AudioSource component
        MovementBehavior();
    }

    protected override void Update()
    {
        base.Update();
        _animator.speed = 1+ speed + SussitaManager.Instance.GetCurrentSpeed();
    }

    public override void TakeDamage(float damageAmount)
    {
        base.TakeDamage(damageAmount);
        _animator.SetBool("Hit", true);
    }

    //protected void OnDisable()
    //{
    //    //base.OnDisable();
    //    //GameManager.instance.playerLiraAmount += 10; // Add 10 lira coins for each death
    //    //StopShooting();
    //}

    //protected override void Update()
    //{
    //    base.Update();
    //    MovementBehavior();
    //}

    protected override void SetNewDestination()
    {
        float randomX = UnityEngine.Random.Range(-100, 150);
        float randomY = UnityEngine.Random.Range(60, 100);
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
        if (audioSource != null && fireShoot != null)
        {
            audioSource.PlayOneShot(fireShoot);
        }
        // GameObject fireBallInstance = Instantiate(fireBallPrefab, fireBallStartPosition.position, Quaternion.identity);
        // ireBallInstance.GetComponent<FireballTravel>().Initialize(this);
    }

    protected virtual void StopShooting()
    {
        isShooting = false;
        // animator = GetComponent<Animator>();
        /*
        if (animator != null)
        {
            animator.SetBool("isShooting", false);
        }
        */
        ResumeMoving();
    }

    //protected override void OnTriggerStay(Collider other)
    //{
    //    base.OnTriggerStay(other);
    //    if (other.CompareTag("Player"))
    //    {
    //        if (AttackTimer > Mathf.Pow(0.9f, attackSpeed))
    //        {
    //            other.GetComponentInParent<SussitaManager>().TakeDamage(Damage);
    //            AttackTimer = 0;
    //        }
    //    }
    //}
    
    public void FireBallHitSussita(GameObject fireBallInstance)
    {
        if (fireBallInstance != null && fireBallInstance.CompareTag("Fireball"))
        {
            Destroy(fireBallInstance);
        }
    }
    
    
    public void SetFireBall(GameObject fireBall)
    {
        fireBallPrefab = fireBall;
    }
    
    public void SetTargetArea(Transform target)
    {
        _targetArea = target;
    }
    
    private void AdjustRotation()
    {
        if (transform.position.x <= -550)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (transform.position.x >= -250)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
    }
}