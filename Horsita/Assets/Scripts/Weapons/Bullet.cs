using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    public void Shoot(float force)
    {
        rb.AddForce(transform.forward * force, ForceMode.Impulse);
    }

    //collision stuff

    //destroy self stuff
}
