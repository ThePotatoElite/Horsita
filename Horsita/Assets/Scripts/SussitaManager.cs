using UnityEngine;

public class SussitaManager : MonoBehaviour
{
    [SerializeField] float accelerationTime = 7f; // (IRL Sussita can get to 100 km/h by 15 seconds)
    [SerializeField] float decelerationTime = 3f;
    [SerializeField] Rigidbody sussitaRb;
    [SerializeField] private float _maxSpeed = 160f; // (Sussita can only reach 160 km/h)
    private static float _velocity = 0f;
    private bool _isAccelerating = false;
    private bool _isBraking = false;

    void Update()
    {
        ManageVelocity();
    }

    public void OnGasPressed()
    {
        _isAccelerating = true;
        _isBraking = false;
    }
    
    public void OnGasReleased()
    {
        _isAccelerating = false;
    }

    public void OnBrakePressed()
    {
        _isBraking = true;
        _isAccelerating = false;
    }
    
    public void OnBrakeReleased()
    {
        _isBraking = false;
    }

    void ManageVelocity()
    {
        if (_isAccelerating && _velocity < _maxSpeed)
        {
            _velocity += (_maxSpeed / accelerationTime) * Time.deltaTime;
        }
        else if (_isBraking && _velocity > 0)
        {
            _velocity -= (_maxSpeed / decelerationTime) * Time.deltaTime;
        }

        _velocity = Mathf.Clamp(_velocity, 0, _maxSpeed);
        float velocityInMps = _velocity * 1000f / 3600f; // Convert velocity to m/s for Rigidbody
        Vector3 movement = transform.forward * velocityInMps;
        sussitaRb.linearVelocity = new Vector3(movement.x, sussitaRb.linearVelocity.y, movement.z);
        Debug.Log("Current velocity is: " + _velocity);
    }

    public float GetCurrentSpeed()
    {
        return _velocity;
    }
}