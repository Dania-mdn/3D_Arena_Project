using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerCharacteristic))]
[RequireComponent(typeof(InputController))]
public class AttackHandler : MonoBehaviour
{
	[SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;
    private float _cooldownTimer;
    private bool _isReadyToShoot = true;

    private PlayerCharacteristic _playerCharacteristic;

    private void Start()
    {
        _playerCharacteristic = GetComponent<PlayerCharacteristic>();
    }
    public void Shoot()
    {
        if (_isReadyToShoot)
        {
            GameObject bullet = Instantiate(_bullet, _bulletSpawnPoint.transform.position, _bulletSpawnPoint.transform.rotation);
            BolletPlayer bolletPlayer = bullet.GetComponent<BolletPlayer>();
            bolletPlayer.PlayerCharacteristic = _playerCharacteristic;
            bolletPlayer.BoolSpeed = _playerCharacteristic.BulletSpeed;
            _isReadyToShoot = false;
            _cooldownTimer = _playerCharacteristic.RateOfFire;
            StartCoroutine(cooldown());
        }
    }
    public void Ulta()
    {
        EventManager.DoKillAllEnemy();
        _playerCharacteristic.resetPower();
    }

    IEnumerator cooldown()
    {
        while (_cooldownTimer > 0)
        {
            _cooldownTimer -= Time.deltaTime;
            yield return null;
        }

        _isReadyToShoot = true;
    }
}
