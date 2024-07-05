using UnityEngine;

public class WheelFeel : MonoBehaviour
{
    private Rigidbody _sussitaRigidbody;
    public float bumpForce = 10f;

    void Start()
    {
        _sussitaRigidbody = GetComponentInParent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bumper"))
        {
            Vector3 bumpDirection = collision.contacts[0].normal;
            _sussitaRigidbody.AddForce(-bumpDirection * bumpForce, ForceMode.Impulse);
        }
    }
}