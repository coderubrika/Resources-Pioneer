using Assets.Scripts.Utils.ScriptableObjects;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(MonoHooks))]
    public class LookAt : MonoBehaviour
    {
        [SerializeField] private TransformConfig _transformConfig;

        [SerializeField] private Transform _destination;
        [SerializeField] bool _needLookAt = false;
        [SerializeField] private UpdateMode _updateMode = UpdateMode.Update;

        private MonoHooks _monoHooks;

        private void Awake()
        {
            Enum.TryParse(_updateMode.ToString(), out MonoHooksNoParamEnum monoHooksEnum);

            _monoHooks = GetComponent<MonoHooks>();


            _monoHooks.AddActionToHook(() =>
            {
                if (_needLookAt) transform.LookAt(_destination);
                _transformConfig.Transform = transform;

            }, monoHooksEnum);

            _monoHooks.AddActionToHook(() => { transform.rotation = _transformConfig.Rotation; }, 
                MonoHooksNoParamEnum.Awake);
        }
    }
}