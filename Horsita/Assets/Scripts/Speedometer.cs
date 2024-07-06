using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] RectTransform pivot;
    
    [SerializeField] float NoSpeedAngle;
    [SerializeField] float MaxSpeedAngle;

    Quaternion Rotation;

    // Update is called once per frame
    void Update()
    {
        Rotation = Quaternion.Euler(0, 0, Mathf.Lerp(NoSpeedAngle, MaxSpeedAngle, SussitaManager.Instance.GetCurrentSpeed() / SussitaManager.Instance.GetMaxSpeed()));
        Debug.Log(Rotation);
        
        pivot.rotation = Rotation;
    }
}
