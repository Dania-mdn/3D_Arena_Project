using UnityEngine;
public class BulletBlueEnemy : Bollet
{
    [HideInInspector] public Transform Target;
    private void OnEnable()
    {
        EventManager.CreateClonePlayer += ChanchTarget;
    }
    private void OnDisable()
    {
        EventManager.CreateClonePlayer -= ChanchTarget;
    }
    private void ChanchTarget(Transform newTarget)
    {
        Target = newTarget;
    }
    public override void OnCollisionEnter(Collision collision)
    {
        base.OnCollisionEnter(collision);
        if (collision.gameObject.TryGetComponent<PlayerCharacteristic>(out PlayerCharacteristic characteristic))
        {
            characteristic.TakeDamageForPower(Damage);
        }
    }
    private void Update()
    {
        transform.LookAt(Target.position + Vector3.up * 0.1f);
        _rigidbody.velocity = transform.forward * BoolSpeed;
    }
}
