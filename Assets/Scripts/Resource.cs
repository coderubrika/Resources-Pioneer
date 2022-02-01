using Assets.Scripts.Interfaces;
using Assets.Scripts.Tests;
using Assets.Scripts.Utils;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Resource : MonoBehaviour
    {
        [SerializeField] private ResourceType _resourceType; 

        private Platform _maintainer;

        private Plant _initer;
        private bool _needCallbackIniter = true;

        private float _timer = 0;
        private float _targetTime;

        private Vector3 _pointPlace;

        public UnityEvent OnComeToDestination;
        private bool _isGrabed = true;
        public bool IsGrabed => _isGrabed;
        private void Awake()
        {
            OnComeToDestination = new UnityEvent();
        }
        
        public void Init(Plant initer, float targetTime)
        {
            _initer = initer;
            _targetTime = targetTime;
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
            _isGrabed = false;

            while (_timer < _targetTime)
            {
                _timer += Time.deltaTime;

                transform.position = Vector3.Lerp(oldPosition, _maintainer.transform.TransformPoint(to) , _timer / _targetTime);

                yield return null;
            }
            transform.position = _maintainer.transform.TransformPoint(to);
            _timer = 0;
            _isGrabed = true;

            if (_needCallbackIniter)
            {
                _needCallbackIniter = false;
                _initer.ResourceDelivered = true;
            }
        }

        private void Release()
        {
            _maintainer.GiveBackToFreePoints(_pointPlace);
        }

        
    }
}