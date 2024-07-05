using UnityEngine;

public class FireballTravel : MonoBehaviour
{
    private Rigidbody rb;
    private GameObject target;
    private FlyingEnemy enemy;

    [SerializeField] public float bulletSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector3 moveDirection = (target.transform.position - transform.position).normalized * bulletSpeed;
        rb.linearVelocity = new Vector3(moveDirection.x, moveDirection.y, moveDirection.z);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
        {
            Destroy(this.gameObject, 2);
        }
    }

    public void Initialize(FlyingEnemy enemy)
    {
        this.enemy = enemy;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SussitaManager.instance.TakeDamage(1f);
            // enemy.FireBallHitSussita(gameObject);
        }
    }
}