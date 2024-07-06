using UnityEngine;

public class MoveFaker_ForRigidbody : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    [SerializeField]
    float distanceModifier;
    [SerializeField]
    float breakModifier;

    void FixedUpdate()
    {
        rb.AddForce(Vector3.left * (SussitaManager.Instance.GetCurrentSpeed() * distanceModifier - SussitaManager.Instance.GetCurrentMomentum() * breakModifier) );
    }
}
