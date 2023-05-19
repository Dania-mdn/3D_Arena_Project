using UnityEngine;

public class PlayerCharacteristic : Characteristic
{
    [Range(0, 100)]
    [SerializeField] private int _strength = 50;

    private PlayerController _playerController;
    [SerializeField] private float _moveSpeed = 4.0f;
    [SerializeField] private float _rotationSpeed = 1.0f;
    [SerializeField] private float _speedChangeRate = 10.0f;

    private AttackHandler _attackHandler;
    [SerializeField] private float _bulletSpeed = 4.0f;
    [SerializeField] private float _rateOfFire;

    private void Start()
    {
        _playerController = GetComponent<PlayerController>();
        _playerController.MoveSpeed = _moveSpeed;
        _playerController.RotationSpeed = _rotationSpeed;
        _playerController.SpeedChangeRate = _speedChangeRate;

        _attackHandler = GetComponent<AttackHandler>();
        _attackHandler.BulletSpeed = _bulletSpeed;
        _attackHandler.BulletDamage = _damage;
        _attackHandler._rateOfFire = _rateOfFire;
    }
    public void TakeDamageForHealt(int damageForHealt)
    {
        _health -= damageForHealt;
        if (_health < 0)
            EventManager.DoEndGame();
    }
    public void TakeDamageForPower(int damageForPower)
    {
        _strength -= damageForPower;
    }
}
