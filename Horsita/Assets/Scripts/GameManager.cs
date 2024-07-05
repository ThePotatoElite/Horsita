using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Shop")] 
    [SerializeField] public int playerLiraAmount = 0;

    [Header("UI Elements")]
    [SerializeField] TextMeshProUGUI coinText;

    private void Start()
    {
        coinText.text = playerLiraAmount.ToString();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        coinText.text = playerLiraAmount.ToString();
    }
}