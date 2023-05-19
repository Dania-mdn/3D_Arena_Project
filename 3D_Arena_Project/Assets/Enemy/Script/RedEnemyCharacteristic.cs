using UnityEngine;

public class RedEnemyCharacteristic : Characteristic
{
    [SerializeField] private int RedEnemyHealth = 50;

    private RedEnemyController _redEnemyController;

    public override int Health
    {
        get { return RedEnemyHealth; }
        set { RedEnemyHealth = Mathf.Clamp(value, 0, 50); }
    }

    [SerializeField] private int _muveUpDistance = 3;
    [SerializeField] private float _timeDelay;
    [SerializeField] private float _moveSpeed;

    private void Start()
    {
        _redEnemyController = GetComponent<RedEnemyController>();
    }
}
