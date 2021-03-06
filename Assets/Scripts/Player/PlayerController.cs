using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UltEvents;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _characterController;

    [SerializeField] private Platform _platform;

    private bool _pressed = false;
    [SerializeField] private float _speed = 1;
    [SerializeField] private float _lockRotationSpeed = 1;
    [SerializeField] private float _moveTreshhold = 0.7f;

    public UltEvent OnIdle; 
    public UltEvent OnWalk;
    public UltEvent OnRun;

    public void ApplyMoveAffection(float affection)
    {
        if (affection == 0f) OnIdle.Invoke(); 
        else if (affection < _moveTreshhold) OnWalk.Invoke(); 
        else if (affection >= _moveTreshhold) OnRun.Invoke();
    }

    public void Move(Vector2 moveInput)
    {
        if (moveInput == Vector2.zero) return;

        if (_pressed)
        {
            Rotate(moveInput);

            Vector3 movement = (moveInput.x * Vector3.right + moveInput.y * Vector3.forward) * _speed * Time.deltaTime;
            print(_speed);
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

    private void OnTriggerEnter(Collider other)
    {
        Resource resource = other.GetComponent<Resource>();

        if (resource && _platform.HasFreePoints())
        {
            _platform.Put(resource);
        }
    }
}
