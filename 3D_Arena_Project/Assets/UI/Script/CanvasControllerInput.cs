using UnityEngine;

public class CanvasControllerInput : MonoBehaviour
{
    [Header("Output")]
    [SerializeField] private InputController _inputController;

    public void MoveInput(Vector2 MoveDirection)
    {
        _inputController.MoveInput(MoveDirection);
    }

    public void LookInput(Vector2 LookDirection)
    {
        _inputController.LookInput(LookDirection);
    }

    public void Shoot()
    {
        _inputController.ShootInput();
    }

    public void Ulta()
    {
        _inputController.UltaInput();
    }
}
