public class BlueEnemyCharacteristic : Characteristic
{
    public float BulletSpeed = 4.0f;
    public float RateOfFire; 

    private void OnEnable()
    {
        EventManager.KillAllEnemy += Destroy;
    }
    private void OnDisable()
    {
        EventManager.KillAllEnemy -= Destroy;
    }
}
