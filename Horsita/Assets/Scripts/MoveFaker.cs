using UnityEngine;

public class MoveFaker : MonoBehaviour
{
    [SerializeField]
    float distanceModifier;
    [SerializeField]
    float breakModifier;
    [SerializeField]
    float Repetition = 0;
    [SerializeField] bool MoveVertically = false;
    [SerializeField] float VerticalStrength = 0;
    private float startingY;
    private float startingCameraY;

    private void Start()
    {
        startingCameraY = Camera.main.transform.position.y;
        startingY = transform.position.y;
    }
    void Update()
    {
        transform.position += Vector3.left * (SussitaManager.instance.GetCurrentSpeed() * distanceModifier + SussitaManager.instance.GetCurrentMomentum() * breakModifier) * Time.deltaTime;

        if (Repetition >0 && transform.position.x < -Repetition)
        {
            
            transform.position += Vector3.right * Repetition *2;
        }

        if (MoveVertically)
        {
            transform.position = new Vector3(transform.position.x, startingY + (startingCameraY - Camera.main.transform.position.y)*VerticalStrength*distanceModifier,transform.position.z);
        }
    }
}
