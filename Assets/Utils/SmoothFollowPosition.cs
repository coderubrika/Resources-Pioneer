using System.Collections;
using UnityEngine;

namespace Assets.Utils
{
    public class SmoothFollowPosition : MonoBehaviour
    {

        [SerializeField] private Transform _target;
        [SerializeField] private float _smoothSpeed = 1f;
        [SerializeField] private Vector3 _offset;



        private void LateUpdate()
        {
            Vector3 desiredPosition = _target.position + _offset;

            transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed * Time.deltaTime);
        }
    }
}