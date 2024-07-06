using UnityEngine;
using UnityEngine.UI;

public class GuageBars : MonoBehaviour 
{
    private Image _healthFiller;
    private Image _liquidFiller;
    private void Start()
    {
        _healthFiller = GameObject.Find("HpFill").GetComponent<Image>();
        _liquidFiller = GameObject.Find("LiquidFill").GetComponent<Image>();
    }    
    public void SetHealth(float health)
    {
        _healthFiller.fillAmount = health;
    }
    public void SetLiquid(float litter)
    {
        _liquidFiller.fillAmount = litter;
    }
}
