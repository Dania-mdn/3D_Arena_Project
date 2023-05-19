using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(InputController))]
public class PlayerController : MonoBehaviour
{
	[Header("Player")]
	[HideInInspector] public float MoveSpeed;
	[HideInInspector] public float RotationSpeed;
	[HideInInspector] public float SpeedChangeRate;

	[Header("Player Grounded")]
	[SerializeField] private bool _grounded = true;
	[SerializeField] private float _groundedOffset = -0.14f;
	[SerializeField] private float _groundedRadius = 0.5f;
	[SerializeField] private LayerMask _groundLayers;
	[SerializeField] private GameObject _cinemachineCameraTarget;
	[SerializeField] private float _topClamp = 90.0f;
	[SerializeField] private float _bottomClamp = -90.0f;

	// cinemachine
	private float _cinemachineTargetPitch;

	// player
	private float _speed;
	private float _verticalVelocity;
	private float _rotationVelocity;
	private float _gravity = 9.8f;

	//system
	private CharacterController _controller;
	private InputController _input;
	private const float _threshold = 0.01f;

	private void Start()
	{
		_controller = GetComponent<CharacterController>();
		_input = GetComponent<InputController>();
	}
	private void Update()
	{
		Gravity();
		GroundedCheck();
		Move();
	}
    private void LateUpdate()
    {
        CameraRotation();
    }
    private void GroundedCheck()
	{
		Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - _groundedOffset, transform.position.z);
		_grounded = Physics.CheckSphere(spherePosition, _groundedRadius, _groundLayers, QueryTriggerInteraction.Ignore);
	}
    private void CameraRotation()
    {
        if (_input.Look.sqrMagnitude >= _threshold)
        {
            _cinemachineTargetPitch += _input.Look.y * RotationSpeed * Time.deltaTime;
            _rotationVelocity = _input.Look.x * RotationSpeed * Time.deltaTime;

            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, _bottomClamp, _topClamp);

            _cinemachineCameraTarget.transform.localRotation = Quaternion.Euler(_cinemachineTargetPitch, 0.0f, 0.0f);

            transform.Rotate(Vector3.up * _rotationVelocity);
        }
    }

    private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
    {
        if (lfAngle < -360f) lfAngle += 360f;
        if (lfAngle > 360f) lfAngle -= 360f;
        return Mathf.Clamp(lfAngle, lfMin, lfMax);
    }

    private void Move()
	{
		float targetSpeed = MoveSpeed;

		float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

		float speedOffset = 0.1f;
		float inputMagnitude = 1f;

		if (currentHorizontalSpeed < targetSpeed - speedOffset || currentHorizontalSpeed > targetSpeed + speedOffset)
		{
			_speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude, Time.deltaTime * SpeedChangeRate);

			_speed = Mathf.Round(_speed * 1000f) / 1000f;
		}
		else
		{
			_speed = targetSpeed;
		}

		Vector3 inputDirection = new Vector3(_input.Move.x, 0.0f, _input.Move.y).normalized;

		if (_input.Move != Vector2.zero)
		{
			inputDirection = transform.right * _input.Move.x + transform.forward * _input.Move.y;
		}
        else
        {
			targetSpeed = 0.0f;
		}

		_controller.Move(inputDirection.normalized * (_speed * Time.deltaTime) + new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
	}
	private void Gravity()
	{
		if (_grounded)
		{
			if (_verticalVelocity < 0.0f)
			{
				_verticalVelocity = -2;
			}
		}
		else
		{
			_verticalVelocity -= _gravity * Time.deltaTime;
		}
	}
	private void OnDrawGizmosSelected()
	{
		Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
		Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

		if (_grounded) Gizmos.color = transparentGreen;
		else Gizmos.color = transparentRed;

		Gizmos.DrawSphere(new Vector3(transform.position.x, transform.position.y - _groundedOffset, transform.position.z), _groundedRadius);
	}
}
