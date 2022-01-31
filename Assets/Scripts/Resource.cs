using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Resource : MonoBehaviour
    {
        private Platform _maintainer;

        private float _timer = 0;
        [SerializeField] private float _speed, _targetTime;

        private Vector3 _pointPlace;

        public UnityEvent OnComeToDestination;

        private void Awake()
        {
            OnComeToDestination = new UnityEvent();
        }

        public void Grab(Platform maintainer)
        {
            if (_maintainer != null) Release();
            _maintainer = maintainer;
            _pointPlace = maintainer.GetFreePoint();
            StartCoroutine(MoveAnimation(_pointPlace));
        }

        public IEnumerator MoveAnimation(Vector3 to)
        {
            Vector3 oldPosition = transform.position;

            while (_timer < _targetTime)
            {
                _timer += Time.deltaTime * _speed;

                transform.position = Vector3.Lerp(oldPosition, to, _timer / _targetTime);

                yield return null;
            }
            transform.position = to;
            _timer = 0;
        }

        private void Release()
        {
            _maintainer.GiveBackToFreePoints(_pointPlace);
        }
    }
}