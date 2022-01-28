using Assets.Scripts.UI;
using Assets.Scripts.UI.MobileJoystick;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Containers
{
    public class PlayerContainer : MonoBehaviour
    {
        [SerializeField] private GameObject _container;
        [SerializeField] private JoystickMobile _joystickMobile;
        [SerializeField] private InputActionsCatcher _inputActionsCatcher;
        private void Awake()
        {
            GameObject instance = Instantiate(_container, transform);
            PlayerController playerController = instance.transform.GetComponentInChildren<PlayerController>();

            _joystickMobile.OnJoystickAffection.AddListener(playerController.Move);
            _inputActionsCatcher.OnPress.AddListener(playerController.ApplyPress);
            _inputActionsCatcher.OnRelease.AddListener(playerController.ApplyRelease);
        }
    }
}
