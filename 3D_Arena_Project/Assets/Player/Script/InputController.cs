using UnityEngine;

public class InputController : MonoBehaviour
{
	public Vector2 Move;
	public Vector2 Look;
	[SerializeField] private bool _shoot;
	[SerializeField] private bool _ulta;

	private AttackHandler _attackHandler;

    private void Start()
    {
		_attackHandler = GetComponent<AttackHandler>();
	}

    public void MoveInput(Vector2 newMoveDirection)
	{
		Move = newMoveDirection;
	}

	public void LookInput(Vector2 newLookDirection)
	{
		Look = newLookDirection;
	}

	public void ShootInput()
	{
		_attackHandler.Shoot();
	}

	public void UltaInput()
	{
		_attackHandler.Ulta();
	}
}
