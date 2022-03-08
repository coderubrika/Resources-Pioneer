
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.MobileJoystick
{
    public class JoystickMobile : MonoBehaviour
    {
        // тут нужно радикально переписывать всю логику

        [SerializeField] private UnityEvent _onShowSensor;
        [SerializeField] private UnityEvent _onHideSensor;
        
        public UnityEvent<Vector2> OnJoystickAffection;
        public UnityEvent<float> OnAffectionForce;
            
        [SerializeField] private float _allowedRadius;

        [SerializeField] private InputActionsCatcher _inputActionsCatcher;

        private Vector2 _touchPoint = Vector2.zero;

        private Vector2 _allowedPosition = Vector2.zero;

        private bool _needDetect = false;
        private bool _needFading = false;

        [SerializeField] private RectTransform _joystick;

        private void Awake()
        {
            _inputActionsCatcher.OnPress.AddListener(() => {
                _onShowSensor.Invoke();
                _needDetect = true;
                _needFading = false;
                _touchPoint = _inputActionsCatcher.Position;
                _joystick.position = _touchPoint;
            });

            _inputActionsCatcher.OnRelease.AddListener(() => {
                _onHideSensor.Invoke();
                _needDetect = false;
                _needFading = true;
            });
        }

        private void CalcJoystickAffection()
        {
            if (_needDetect)
            {
                Vector2 normalizedOffset = (_inputActionsCatcher.Position - _touchPoint) / _allowedRadius;

                float magnitude = normalizedOffset.magnitude;

                if (magnitude <= 1f)
                {
                    OnJoystickAffection.Invoke(normalizedOffset);
                    OnAffectionForce.Invoke(magnitude);
                }
                else
                {
                    OnJoystickAffection.Invoke(normalizedOffset / magnitude);
                    OnAffectionForce.Invoke(1f);
                }
            }
            else
            {
                OnJoystickAffection.Invoke(Vector2.zero);
                OnAffectionForce.Invoke(0f);
            }
        }

        
        private void Update()
        {
            CalcJoystickAffection();
        }

    }
}


