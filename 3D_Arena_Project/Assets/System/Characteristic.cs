using UnityEngine;

public class Characteristic : MonoBehaviour
{
    protected int _health = 100;

    public virtual int Health
    {
        get { return _health; }
        set { _health = Mathf.Clamp(value, 0, 100); }
    }

    [SerializeField] protected float _damage;
}
