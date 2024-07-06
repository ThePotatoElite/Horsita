using UnityEngine;

public class MoveFaker : MonoBehaviour
{
    [SerializeField]
    float distanceModifier;

    void Update()
    {
        transform.position += Vector3.left * SussitaManager.instance.GetCurrentSpeed() * Time.deltaTime;
    }
}
