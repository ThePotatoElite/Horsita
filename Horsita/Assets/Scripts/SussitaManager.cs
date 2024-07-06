using UnityEngine;

public class SussitaManager : MonoBehaviour //MonoSingleton<SussitaManager>
{
    ///// <summary>
    ///// This is basically the player
    ///// </summary>
    //static SussitaManager _instance;
    //public static SussitaManager Instance { get => _instance; set => _instance = value; }


    [SerializeField] float extraGravity = 4f; // (IRL Sussita can get to 100 km/h by 15 seconds)
    [SerializeField] float accelerationTime = 4f; // (IRL Sussita can get to 100 km/h by 15 seconds)
    [SerializeField] float decelerationTime = 2f;
    [SerializeField] Rigidbody sussitaRb;
    [SerializeField] private float _maxSpeed = 260f; // (Sussita can only reach 160 km/h)
    private static float _velocity = 0f;
    private static float _momentum = 0f;
    private bool _isAccelerating = false;
    private bool _isBraking = false;
    public static SussitaManager Instance;
    public float AntiDrag = 1f;
    public float Health { get; set; } = 100;
    public float MaxHealth { get; set; } = 100;

    public static System.Action<float> OnHealthChanged;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
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
    //private void FixedUpdate()
    //{
    //    sussitaRb.AddForce(Vector3.down * extraGravity);
    //}
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

    public void ManageVelocity()
    {
        float previousVel = _velocity;

        if (_isAccelerating && _velocity < _maxSpeed)
        {
            _velocity += (_maxSpeed / accelerationTime) * Time.deltaTime; // * AntiDrag;
            _momentum = 0;
        }
        else if (_isBraking && _velocity > 0)
        {
            _velocity -= _momentum = (_maxSpeed / decelerationTime) * Time.deltaTime;
            //_momentum = _velocity*-1.3f;
        }
        else
        {
            _velocity -= _momentum = _velocity * .5f * Time.deltaTime; //normal drag/decay
        }

        _velocity = Mathf.Clamp(_velocity, 0, _maxSpeed);


        //float velocityInMps = _velocity * 1000f / 3600f; // Convert velocity to m/s for Rigidbody
        //Vector3 movement = transform.forward * velocityInMps;
        //sussitaRb.linearVelocity = new Vector3(movement.x, sussitaRb.linearVelocity.y, movement.z);
        Debug.Log($"Current velocity is: {_velocity}");
        // Debug.Log($"Current velocity is: {_velocity} | Drag : {AntiDrag}");
    }

    public void ChangeVelocity(float decreaseVelocity)
    {
        _velocity *= decreaseVelocity;
    }

    public float GetCurrentSpeed()
    {
        return _velocity;
    }
    public float GetCurrentMomentum()
    {
        return _momentum;
    }

    public float GetMaxSpeed()
    {
        return _maxSpeed;
    }
    
    public void TakeDamage(float damageAmount)
    {
        Health -= damageAmount;
        OnHealthChanged?.Invoke(Health/MaxHealth);
        if (Health <= 0)
        {
            Debug.Log("Sussita is dead! R.I.P!");
        }
        // UpdateHpBar();
    }
}