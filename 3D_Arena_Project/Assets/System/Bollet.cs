using UnityEngine;

public abstract class Bollet : MonoBehaviour
{
    [HideInInspector] public int Damage;
    [HideInInspector] public float BoolSpeed;
    protected Rigidbody _rigidbody;
    protected Vector3 direction;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        direction = transform.forward;
        _rigidbody.velocity = transform.forward * BoolSpeed;
    }

    public virtual void OnCollisionEnter(Collision collision) 
    {
        Destroy(gameObject);
    }
}
