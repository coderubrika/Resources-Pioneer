using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    private bool _pressed = false;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _lockRotationSpeed = 1;

    public void Move(Vector2 moveInput)
    {
        if (moveInput == Vector2.zero) return;

        if (_pressed)
        {
            Rotate(moveInput);

            Vector3 movement = (moveInput.x * Vector3.right + moveInput.y * Vector3.forward) * _speed * Time.deltaTime;
            _characterController.Move(movement);
        }
    }

    private void Rotate(Vector2 moveInput)
    {
        Quaternion targerRotation = Quaternion.LookRotation(new Vector3(moveInput.x, 0f, moveInput.y), Vector3.up);
        _characterController.transform.rotation = Quaternion.Slerp(_characterController.transform.rotation, targerRotation, _lockRotationSpeed * Time.deltaTime);
    }

    public void ApplyPress()
    {
        _pressed = true;
    }

    public void ApplyRelease()
    {
        _pressed = false;
    }
}
