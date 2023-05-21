using UnityEngine;

public class RedEnemyCharacteristic : Characteristic
{
    [SerializeField] private int RedEnemyHealth = 50;

    private void OnEnable()
    {
        EventManager.KillAllEnemy += Destroy;
    }
    private void OnDisable()
    {
        EventManager.KillAllEnemy -= Destroy;
    }
    public override int Health
    {
        get { return RedEnemyHealth; }
        set { RedEnemyHealth = Mathf.Clamp(value, 0, 50); }
    }

    public int MuveUpDistance = 3;
    public float MuveUpSpeed = 1;
    public float TimeDelay;
    public float MoveSpeedToTarget;

}
