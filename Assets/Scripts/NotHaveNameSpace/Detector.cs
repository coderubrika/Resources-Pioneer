using Assets.Scripts.NotHaveNameSpace.Interfaces;
using Assets.Scripts.Utils;
using System;
using UnityEngine.Events;

namespace Assets.Scripts.NotHaveNameSpace
{
    public class Detector<TScanable> where TScanable : IScanable
    {
        public UnityEvent<IScanable> OnDetect;
        private IScaner<IScanable> _scaner;
        private MonoHook _monoHook;
        private ToggleSwitch _enabled; 
        public Detector(IScaner<IScanable> scaner, MonoHook monoHook)
        {
            _monoHook = monoHook;
            OnDetect = new UnityEvent<IScanable>();
            _scaner = scaner;
            _enabled = new ToggleSwitch(false);

            _monoHook.AddActionToHook(Check, MonoHooksNoParamEnum.Update);
        }

        public void Check()
        {
            if (!_enabled.IsEnable()) return;

            IScanable[] scanables = _scaner.Scan();

            foreach (IScanable scanable in scanables)
            {
                TScanable tScanable = (TScanable) scanable;

                if (tScanable != null)
                {
                    OnDetect.Invoke(tScanable);
                }
            }
        }
    }
}
