using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private GameObject[] _enemy;
    [SerializeField] private GameObject _ground;
    [Range(0.1f, 2f)]
    [SerializeField] private float _spawnHeight = 1f;
    private float _coldawn = 0;
    [Range(0, 10)]
    [SerializeField] private float _spawnTimer = 5;
    [Range(0, 10)]
    [SerializeField] private float _minSpawnTime = 2;
    [Range(0, 1)]
    [SerializeField] private float _timeReductionStep = 0.5f;
    private float _countSpawnEnemy = 1;

    private void Update()
    {
        _coldawn -= Time.deltaTime;

        if (_coldawn > 0) return;

        if (_spawnTimer > _minSpawnTime)
            _spawnTimer -= _timeReductionStep;
        else
            _countSpawnEnemy++;

        SpawnObject();
        _coldawn = _spawnTimer; 
    }

    private void SpawnObject()
    {
        for (int i = 0; i < _countSpawnEnemy; i++)
        {
            Vector2 randomCirclePos = Random.onUnitSphere.normalized * (_ground.transform.localScale.x / 2);
            Vector3 spawnPosition = _ground.transform.position + new Vector3(randomCirclePos.x, _spawnHeight, randomCirclePos.y);

            EnemyController spawnedObject = Instantiate(_enemy[CheckChance(1, 4)], spawnPosition, Quaternion.identity).GetComponent<EnemyController>();
            spawnedObject.Target = _target;
        }
    }

    private int CheckChance(int numerator, int denominator)
    {
        int randomValue = Random.Range(1, denominator + 1);

        if (randomValue <= numerator)
            return 0;
        else
            return 1;
    }
}
