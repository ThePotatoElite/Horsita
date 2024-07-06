using UnityEngine;

public class MoveFaker_ForRigidbody : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float distanceModifier;

    void FixedUpdate()
    {
        rb.AddForce(Vector3.left * SussitaManager.instance.GetCurrentSpeed() * distanceModifier);
    }
}
