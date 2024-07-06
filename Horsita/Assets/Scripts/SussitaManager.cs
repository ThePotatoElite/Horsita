using UnityEngine;

public class SussitaManager : MonoBehaviour
{
    ///// <summary>
    ///// This is basically the player
    ///// </summary>
    //static SussitaManager _instance;
    //public static SussitaManager Instance { get => _instance; set => _instance = value; }


    [SerializeField] float accelerationTime = 7f; // (IRL Sussita can get to 100 km/h by 15 seconds)
    [SerializeField] float decelerationTime = 3f;
    [SerializeField] Rigidbody sussitaRb;
    [SerializeField] private float _maxSpeed = 160f; // (Sussita can only reach 160 km/h)
    private static float _velocity = 0f;
    private static float _momentum = 0f;
    private bool _isAccelerating = false;
    private bool _isBraking = false;
    public static SussitaManager instance;
    
    public float Health { get; set; } = 100;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }    
    }

    void Update()
    {
        HandleInput();
        ManageVelocity();
    }
    
    void HandleInput()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            OnGasPressed();
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.D))
        {
            OnGasReleased();
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            OnBrakePressed();
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.A))
        {
            OnBrakeReleased();
        }
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
        float previousVel = _velocity;

        if (_isAccelerating && _velocity < _maxSpeed)
        {
            _velocity += (_maxSpeed / accelerationTime) * Time.deltaTime;
        }
        else if (_isBraking && _velocity > 0)
        {
            _velocity -= (_maxSpeed / decelerationTime) * Time.deltaTime;
        }
        _velocity = Mathf.Clamp(_velocity, 0, _maxSpeed);

        _momentum = (_velocity - previousVel) *-1f;

        float velocityInMps = _velocity * 1000f / 3600f; // Convert velocity to m/s for Rigidbody
        Vector3 movement = transform.forward * velocityInMps;
        sussitaRb.linearVelocity = new Vector3(movement.x, sussitaRb.linearVelocity.y, movement.z);
        Debug.Log("Current velocity is: " + _velocity);
    }

    public float GetCurrentSpeed()
    {
        return _velocity;
    }
    public float GetCurrentMomentum()
    {
        return _momentum;
    }
    
    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
        if (Health <= 0)
        {
            Debug.Log("Sussita is dead");
        }
        // UpdateHpBar();
    }
}