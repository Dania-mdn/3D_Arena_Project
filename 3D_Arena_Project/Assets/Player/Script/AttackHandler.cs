using System.Collections;
using UnityEngine;

[RequireComponent(typeof(InputController))]
public class AttackHandler : MonoBehaviour
{
	[SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _bulletSpawnPoint;
    [Tooltip("Время в между выстрелами всекундах")]
    [HideInInspector] public float _rateOfFire;
    [HideInInspector] public float BulletSpeed;
    [HideInInspector] public float BulletDamage;
    [HideInInspector] private float _cooldownTimer;
    private bool _isReadyToShoot = true;

    public void Shoot()
    {
        if (_isReadyToShoot)
        {
            GameObject bullet = Instantiate(_bullet, _bulletSpawnPoint.transform.position, _bulletSpawnPoint.transform.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * BulletSpeed;
            _isReadyToShoot = false;
            _cooldownTimer = _rateOfFire;
            StartCoroutine(cooldown());
        }
    }
    public void Ulta()
    {
        
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
