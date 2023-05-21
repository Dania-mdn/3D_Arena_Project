using UnityEngine;

public class Characteristic : MonoBehaviour
{
    protected int _minhealth = 100;
    protected int _maxhealth = 100;
    [SerializeField] protected int _health = 100;

    public virtual int Health
    {
        get { return _health; }
        set { _health = Mathf.Clamp(value, 0, _maxhealth); }
    }

    public int Damage;
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
