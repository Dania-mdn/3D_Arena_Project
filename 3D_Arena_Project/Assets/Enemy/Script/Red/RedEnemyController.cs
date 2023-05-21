using System.Collections;
using UnityEngine;

[RequireComponent(typeof(RedEnemyCharacteristic))]
public class RedEnemyController : EnemyController
{
    private CharacterController _controller;
    private RedEnemyCharacteristic _redEnemyCharacteristic;

    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _redEnemyCharacteristic = GetComponent<RedEnemyCharacteristic>(); 
        StartCoroutine(muveUp());
    }
    public void Update()
    {
        transform.LookAt(Target);

        if (_isReadyToAttack)
        {
            AttackToTarget();
        }
    }

    public void AttackToTarget()
    {
        _controller.Move(transform.forward * (_redEnemyCharacteristic.MoveSpeedToTarget * Time.deltaTime));
    }

    IEnumerator muveUp()
    {
        while (_redEnemyCharacteristic.TimeDelay > 0)
        {
            while (transform.position.y < _redEnemyCharacteristic.MuveUpDistance)
            {
                _controller.Move(Vector3.up * (_redEnemyCharacteristic.MuveUpSpeed * Time.deltaTime));
                yield return null;
            }
            _redEnemyCharacteristic.TimeDelay -= Time.deltaTime;
           yield return null;
        }

        _isReadyToAttack = true;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.TryGetComponent<PlayerCharacteristic>(out PlayerCharacteristic characteristic))
        {
            characteristic.TakeDamageForHealt(_redEnemyCharacteristic.Damage);
            Destroy(gameObject);
        }
    }
}
