
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI.MobileJoystick
{
    public class JoystickMobile : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onShowSensor;
        [SerializeField] private UnityEvent _onHideSensor;
        public UnityEvent<Vector2> OnJoystickAffection;

        [SerializeField] private float _allowedRadius;

        [SerializeField] private InputActionsCatcher _inputActionsCatcher;

        private Vector2 _touchPoint = Vector2.zero;

        private Vector2 _allowedPosition = Vector2.zero;
        private float _allowedPart = 0f;

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

        private Vector2 CalcJoystickAffection()
        {
            if (_needDetect)
            {
                Vector2 offset = (_inputActionsCatcher.Position - _touchPoint);

                float magnitude = offset.magnitude;
                _allowedPart = _allowedRadius / magnitude;
                
                if (_allowedPart < 1)
                {
                    _allowedPosition = Vector2.Lerp(_touchPoint, _inputActionsCatcher.Position, _allowedPart);
                }
                else _allowedPosition = _inputActionsCatcher.Position;

                return (_allowedPosition - _touchPoint) / _allowedRadius;
            }

            else if (_needFading)
            {
                if ((_touchPoint - _allowedPosition).sqrMagnitude == 0f) _needFading = false;
                return (Vector2.Lerp(_touchPoint, _allowedPosition, Time.deltaTime) - _touchPoint) / _allowedRadius;

            }
            else return Vector2.zero;
        }

        

        private void Update()
        {
            Vector2 affection = CalcJoystickAffection();
            OnJoystickAffection.Invoke(affection);
            
        }

    }
}


