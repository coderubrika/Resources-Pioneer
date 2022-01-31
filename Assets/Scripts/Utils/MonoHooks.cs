using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Utils
{
    [DisallowMultipleComponent]
    public sealed class MonoHooks : MonoBehaviour
    {
        private Dictionary<MonoHooksNoParamEnum, UnityEvent> _eventsRegistry;

        private Dictionary<MonoHooksNoParamEnum, UnityEvent> _EventsRegistry
        {
            get
            {
                if (_eventsRegistry == null) _eventsRegistry = new Dictionary<MonoHooksNoParamEnum, UnityEvent>();
                return _eventsRegistry;
            }
        }

        private Dictionary<MonoHooksWithParamEnum, UnityEvent<object>> _eventsWithParamRegistry;
        private Dictionary<MonoHooksWithParamEnum, UnityEvent<object>> _EventsWithParamRegistry
        {
            get
            {
                if (_eventsWithParamRegistry == null) _eventsWithParamRegistry = new Dictionary<MonoHooksWithParamEnum, UnityEvent<object>>();
                return _eventsWithParamRegistry;
            }
        }

        [SerializeField] private List<KeyValuePairStruct<MonoHooksNoParamEnum, UnityEvent>> _eventsListNoParam;
        [SerializeField] private List<KeyValuePairStruct<MonoHooksWithParamEnum, UnityEvent<object>>> _eventsListWithParam;
            
        public void AddActionToHook(UnityAction action, MonoHooksNoParamEnum monoHooks)
        {

            if (!_EventsRegistry.ContainsKey(monoHooks)) _EventsRegistry[monoHooks] = new UnityEvent();
            _EventsRegistry[monoHooks].AddListener(action);
        }

        public void AddActionToHook(UnityAction<object> action, MonoHooksWithParamEnum monoHooks)
        {
            if (!_EventsWithParamRegistry.ContainsKey(monoHooks)) _EventsWithParamRegistry[monoHooks] = new UnityEvent<object>();
            _EventsWithParamRegistry[monoHooks].AddListener(action);
        }

        private void Awake()
        {
            if (_eventsListNoParam != null)
            {
                foreach (var pair in _eventsListNoParam)
                {
                    if (!_EventsRegistry.ContainsKey(pair.Key)) _EventsRegistry[pair.Key] = new UnityEvent();
                    _EventsRegistry[pair.Key].AddListener(() => pair.Value.Invoke());
                }
            }


            if (_eventsListWithParam != null)
            {
                foreach (var pair in _eventsListWithParam)
                {
                    if (!_EventsWithParamRegistry.ContainsKey(pair.Key)) _EventsWithParamRegistry[pair.Key] = new UnityEvent<object>();
                    _EventsWithParamRegistry[pair.Key].AddListener((param) => pair.Value.Invoke(param));
                }
            }
            

            Application.onBeforeRender += () => ExecuteAction(MonoHooksNoParamEnum.BeforeRender);
        }

        private void ExecuteAction(MonoHooksNoParamEnum hooksEnum)
        {
            if (_EventsRegistry.ContainsKey(hooksEnum) && _EventsRegistry[hooksEnum] != null)
            {
                _EventsRegistry[hooksEnum].Invoke();
            }
        }

        private void ExecuteAction<T>(MonoHooksWithParamEnum hooksEnum, T param)
        {
            if (_EventsWithParamRegistry.ContainsKey(hooksEnum) && _EventsWithParamRegistry[hooksEnum] != null)
            {
                _EventsWithParamRegistry[hooksEnum].Invoke(param);
            }
        }

        private void Start()
        {
            ExecuteAction(MonoHooksNoParamEnum.Awake);
            ExecuteAction(MonoHooksNoParamEnum.Start);
        }

        private void Update()
        {
            ExecuteAction(MonoHooksNoParamEnum.Update);
        }

        private void FixedUpdate()
        {
            ExecuteAction(MonoHooksNoParamEnum.FixedUpdate);
        }

        private void LateUpdate()
        {
            ExecuteAction(MonoHooksNoParamEnum.LateUpdate);
        }

        private void OnEnable()
        {
            ExecuteAction(MonoHooksNoParamEnum.OnEnable);
        }

        private void OnDisable()
        {
            ExecuteAction(MonoHooksNoParamEnum.OnDisable);
        }

        private void OnDestroy()
        {
            ExecuteAction(MonoHooksNoParamEnum.OnDestroy);
        }

        private void OnTriggerEnter(Collider other)
        {
            ExecuteAction(MonoHooksWithParamEnum.OnTriggerEnter, other);
        }

        private void OnTriggerExit(Collider other)
        {
            ExecuteAction(MonoHooksWithParamEnum.OnTriggerExit, other);
        }

        private void OnTriggerStay(Collider other)
        {
            ExecuteAction(MonoHooksWithParamEnum.OnTriggerStay, other);
        }

        private void OnCollisionEnter(Collision collision)
        {
            ExecuteAction(MonoHooksWithParamEnum.OnCollisionEnter, collision);
        }

        private void OnCollisionExit(Collision collision)
        {
            ExecuteAction(MonoHooksWithParamEnum.OnCollisionExit, collision);
        }

        private void OnCollisionStay(Collision collision)
        {
            ExecuteAction(MonoHooksWithParamEnum.OnCollisionStay, collision);
        }
    }
}