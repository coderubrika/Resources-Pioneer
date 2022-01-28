using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI.MobileJoystick
{
    public class JoystickController : MonoBehaviour
    {
        [SerializeField] private RectTransform _contoller;

        [SerializeField] private float _radius;

        public void MoveController(Vector2 delta)
        {
            _contoller.anchoredPosition = delta * _radius;
        }
    }
}