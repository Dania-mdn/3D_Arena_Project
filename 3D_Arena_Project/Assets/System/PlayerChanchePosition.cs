using UnityEngine;

public class PlayerChanchePosition : MonoBehaviour
{
	[SerializeField] private GameObject _ground;
	[SerializeField] private GameObject _player;
	private GameObject[] _enemies;
	private float maxDistance = 0f;
	private Vector3 NewPlayerPosition;

    private void OnEnable()
    {
		EventManager.PlayerNewPosition += MoveToRandomPosition;
	}
    private void OnDisable()
    {
		EventManager.PlayerNewPosition -= MoveToRandomPosition;
	}
    private void MoveToRandomPosition()
    {
		_enemies = GameObject.FindGameObjectsWithTag("Enemy");

		for(int i = 0; i < 1; i++)
		{
			Vector2 randomCirclePos = Random.onUnitSphere.normalized * (_ground.transform.localScale.x / 2.2f);
			Vector3 NewPosition = _ground.transform.position + new Vector3(randomCirclePos.x, _ground.transform.position.y + 0.2f, randomCirclePos.y);

			foreach (GameObject enemy in _enemies)
			{
				float distance = Vector3.Distance(NewPosition, enemy.transform.position);
				if (distance > maxDistance)
				{
					maxDistance = distance;
					NewPlayerPosition = NewPosition;
				}
			}
		}
		_player.transform.position = NewPlayerPosition;
	}
}
