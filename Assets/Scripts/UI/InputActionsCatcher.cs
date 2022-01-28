using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets.Scripts.UI
{
    public class InputActionsCatcher : MonoBehaviour
    {
        private Vector2 _delta = Vector2.zero;
        private Vector2 _position = Vector2.zero;

        public Vector2 Delta => _delta;
        public Vector2 Position => _position;

        public UnityEvent OnPress;
        public UnityEvent OnRelease;


        public void OnTapPosition(InputValue inputValue)
        {
            _position = inputValue.Get<Vector2>();
        }

        public void OnTapPressed(InputValue _)
        {
            OnPress.Invoke();
        }

        public void OnTapReleased(InputValue _)
        {
            OnRelease.Invoke();
        }

        public void OnTapDelta(InputValue inputValue)
        {
            _delta = inputValue.Get<Vector2>();
        }
    }
}