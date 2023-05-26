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
		NewPlayerPosition = Vector3.zero;
		_enemies = GameObject.FindGameObjectsWithTag("Enemy");
		float radius = _ground.transform.localScale.x / 2;

		for (float x = -radius; x <= radius; x++)
		{
			for (float z = -radius; z <= radius; z++)
			{
				Vector3 point = new Vector3(x, _ground.transform.position.y + 0.2f, z);

				if (Vector3.Distance(point, _ground.transform.position) <= radius)
				{
					float distanceSum = 0f;
					foreach (GameObject otherX in _enemies)
					{
						foreach (GameObject otherZ in _enemies)
						{
							Vector3 otherPoint = new Vector3(otherX.transform.position.x, _ground.transform.position.y + 0.2f, otherZ.transform.position.z);

							if (point != otherPoint)
								distanceSum += Vector3.Distance(point, otherPoint);
						}
					}

					if (distanceSum > maxDistance)
					{
						maxDistance = distanceSum;
						NewPlayerPosition = point;
					}
				}
			}
		}
		_player.transform.position = NewPlayerPosition + _ground.transform.position;
	}
}
