using UnityEngine;
using UnityEngine.UI;

public class GuageBars : MonoBehaviour 
{
    [SerializeField]
    private Image _healthFiller;
    //[SerializeField]
    //private Image _liquidFiller;
    //private void Start()
    //{
    //    _healthFiller = GameObject.Find("HpFill").GetComponent<Image>();
    //    //_liquidFiller = GameObject.Find("LiquidFill").GetComponent<Image>();
    //}    

    private void Start()
    {
        SussitaManager.OnHealthChanged += SetHealth;
    }
    public void SetHealth(float health)
    {
        _healthFiller.fillAmount = health;
    }
    //public void SetMaxHealth(float health)
    //{
    //    _healthFiller.fillAmount = health;
    //}

    //public void SetLiquid(float litter)
    //{
    //    _liquidFiller.fillAmount = litter;
    //}
    private void OnDisable()
    {
        SussitaManager.OnHealthChanged -= SetHealth;
    }
}
