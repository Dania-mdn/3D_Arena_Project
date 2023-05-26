using UnityEngine;
public class BolletPlayer : Bollet
{
    [HideInInspector] public PlayerCharacteristic PlayerCharacteristic;
    [SerializeField] private int _strenthForKillBlueEnemy = 50;
    [SerializeField] private int _strenthForKillRedEnemy = 15;
    [SerializeField] private int _strenthForKillRicoshet = 5;
    [Tooltip("Çíà÷åíèå â ïğîöåíòíîì ñîîòíîøåíèè")]
    [SerializeField] private int _HelthForKillRicoshetInPrecent = 50;

    [SerializeField] private LayerMask _enemyLayer;
    private int _minPlayerHealth = 25;
    private int _hitCount = 0;

    public override void OnCollisionEnter(Collision collision)
    {
        if(_hitCount == 0)
        {
            _hitCount++;
            if (collision.gameObject.TryGetComponent<BlueEnemyCharacteristic>(out BlueEnemyCharacteristic CharacteristicBlue))
            {
                DestroyHitEnemy(CharacteristicBlue, _strenthForKillBlueEnemy);
            }
            else if (collision.gameObject.TryGetComponent<RedEnemyCharacteristic>(out RedEnemyCharacteristic CharacteristicRed))
            {
                DestroyHitEnemy(CharacteristicRed, _strenthForKillRedEnemy);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            if (collision.gameObject.TryGetComponent<Characteristic>(out Characteristic Characteristic))
            {
                if(CheckChance(1, 2))
                {
                    DestroyHitEnemy(Characteristic, _strenthForKillRicoshet);
                }
                else
                {
                    DestroyHitEnemy(Characteristic, 0);
                    EventManager.DoKillEnemyRicoñhet(_HelthForKillRicoshetInPrecent);
                }
            }
            Destroy(gameObject);
        }
    }
    private void DestroyHitEnemy(Characteristic Characteristic, int powerForKillEnemy)
    {
        Characteristic.Destroy();
        EventManager.DoKillEnemy(powerForKillEnemy);
        Invoke("Ricoñhet", 0.01f);
    }
    private void Ricoñhet()
    {
        if (CheckChance(_minPlayerHealth, PlayerCharacteristic.Health))
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, 5f, _enemyLayer);

            if (colliders.Length > 0)
            {
                Transform closestEnemy = colliders[0].transform;
                float closestDistance = Vector3.Distance(transform.position, closestEnemy.position);

                for (int i = 1; i < colliders.Length; i++)
                {
                    float distance = Vector3.Distance(transform.position, colliders[i].transform.position);
                    if (distance < closestDistance)
                    {
                        closestEnemy = colliders[i].transform;
                        closestDistance = distance;
                    }
                }
                direction = (closestEnemy.position + Vector3.up * closestEnemy.transform.localScale.y - transform.position).normalized;
                _rigidbody.velocity = direction * BoolSpeed;
            }
            else
            {
                _rigidbody.velocity = direction * BoolSpeed;
                Invoke("DestroyBullet", 5);
            }
        }
        else
        {
            DestroyBullet();
        }
    }
    private bool CheckChance(int numerator, int denominator)
    {
        int randomValue = Random.Range(1, denominator + 1);

        if (randomValue <= numerator)
            return true;
        else
            return false;
    }
    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
