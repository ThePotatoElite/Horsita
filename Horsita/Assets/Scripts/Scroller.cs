using UnityEngine;

public class Scroller : MonoBehaviour
{
    private SussitaManager _sussitaManager;
    [SerializeField] float resetPositionX;
    [SerializeField] float thresholdPositionX;

    private Vector3 _startPosition;

    void Start()
    {
        _sussitaManager = FindFirstObjectByType<SussitaManager>();
        if (_sussitaManager == null)
        {
            Debug.LogError("SussitaManager not found in the scene...");
        }
        _startPosition = transform.position;
    }

    void Update()
    {
        if (_sussitaManager != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        float sussitaSpeed = _sussitaManager.GetCurrentSpeed();
        float movement = sussitaSpeed * Time.deltaTime;
        transform.position += Vector3.left * movement;
        if (transform.position.x < thresholdPositionX)
        {
            ResetPosition();
        }
    }

    void ResetPosition()
    {
        transform.position = new Vector3(resetPositionX, _startPosition.y, _startPosition.z);
    }
}