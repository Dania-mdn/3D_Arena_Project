using UnityEngine;

public class PlayerCharacteristic : Characteristic
{
    [SerializeField] private int _maxPower = 100;
    [SerializeField] private int _minPower = 0;
    [Range(0, 100)]
    [SerializeField] private int _Power = 50;

    public float MoveSpeed = 4.0f;
    public float RotationSpeed = 1.0f;
    public float SpeedChangeRate = 10.0f;

    public float BulletSpeed = 4.0f;
    [Tooltip("Âğåìÿ ìåæäó âûñòğåëàìè âñåêóíäàõ")]
    public float RateOfFire;

    private void OnEnable()
    {
        EventManager.KillEnemy += AddValueForPower;
        EventManager.KillEnemyRicoñhet += AddValueForHealt;
    }
    private void OnDisable()
    {
        EventManager.KillEnemy -= AddValueForPower;
        EventManager.KillEnemyRicoñhet -= AddValueForHealt;
    }
    private void Start()
    {
        EventManager.DoSetMaxPlayerHelth(_maxhealth);
        EventManager.DoSetPlayerHealth(_health);
        EventManager.DoSetPlayerPower(_Power);
    }
    public void TakeDamageForHealt(int damageForHealt)
    {
        _health -= damageForHealt;
        EventManager.DoSetPlayerHealth(_health);
        if (_health < 0) EventManager.DoEndGame();
    }
    public void TakeDamageForPower(int damageForPower)
    {
        _Power -= damageForPower;
        _Power = Mathf.Clamp(_Power, _minPower, _maxPower);
        EventManager.DoSetPlayerPower(_Power);
    }
    public void resetPower()
    {
        _Power = _minPower;
    }
    public void AddValueForHealt(int valueForHealt)
    {
        _health = _maxhealth / 100 * valueForHealt;
        _health = Mathf.Clamp(_health, _minhealth, _maxhealth);
        EventManager.DoSetPlayerHealth(_health);
    }
    public void AddValueForPower(int valueForPower)
    {
        _Power += valueForPower;
        _Power = Mathf.Clamp(_Power, _minPower, _maxPower);
        EventManager.DoSetPlayerPower(_Power);
    }
}
