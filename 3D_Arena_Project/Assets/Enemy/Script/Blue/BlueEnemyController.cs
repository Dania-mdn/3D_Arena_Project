using System.Collections;
using UnityEngine;

[RequireComponent(typeof(BlueEnemyCharacteristic))]
public class BlueEnemyController : EnemyController
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;

    private BlueEnemyCharacteristic _blueEnemyCharacteristic;

    private float _cooldownTimer;
    private void Start()
    {
        _blueEnemyCharacteristic = GetComponent<BlueEnemyCharacteristic>(); 
        _isReadyToAttack = true;
    }
    public void Update()
    {
        transform.LookAt(Target);

        if (_isReadyToAttack)
        {
            GameObject bullet = Instantiate(_bullet, _bulletSpawnPoint.transform.position, transform.rotation);
            BulletBlueEnemy _bulletBlueEnemy = bullet.GetComponent<BulletBlueEnemy>();
            _bulletBlueEnemy.BoolSpeed = _blueEnemyCharacteristic.BulletSpeed;
            _bulletBlueEnemy.Damage = _blueEnemyCharacteristic.Damage;
            _bulletBlueEnemy.Target = Target;
            _isReadyToAttack = false;
            _cooldownTimer = _blueEnemyCharacteristic.RateOfFire;
            StartCoroutine(cooldown());
        }
    }
    IEnumerator cooldown()
    {
        while (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
            yield return null;
        }

        _isReadyToAttack = true;
    }
}
