using UnityEngine;

public class MoveFaker : MonoBehaviour
{
    [SerializeField]
    float distanceModifier;
    [SerializeField]
    float breakModifier;

    void Update()
    {
        transform.position += Vector3.left * (SussitaManager.instance.GetCurrentSpeed() * distanceModifier + SussitaManager.instance.GetCurrentMomentum() * breakModifier) * Time.deltaTime;
    }
}
