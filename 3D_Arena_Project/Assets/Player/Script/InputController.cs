using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

public class InputController : MonoBehaviour
{
	[Header("Character Input Values")]
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

	public void ShootInput(bool newShutState)
	{
		_shoot = newShutState;
		_attackHandler.Shoot();
		_shoot = false;
	}

	public void UltaInput(bool newUltaState)
	{
		_ulta = newUltaState;
		_attackHandler.Ulta();
		_ulta = false;
	}
}
