using Assets.Scripts.NotHaveNameSpace.Interfaces;
using Assets.Scripts.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.NotHaveNameSpace
{
    public class ScanerOnTrigger<TSome> : IScaner<TSome>
    {
        private Dictionary<TSome, TSome> _scanables;
        private void OnTriggerEnter(object other)
        {
            Collider collider = other as Collider;

            TSome some = collider.GetComponent<TSome>();

            if (some != null)
            {
                _scanables.Add(some, some);
            }
        }

        private void OnTriggerExit(object other)
        {
            Collider collider = other as Collider;

            TSome some = collider.GetComponent<TSome>();

            if (some != null)
            {
                _scanables.Remove(some);
            }
        }

        public ScanerOnTrigger(MonoHook monoHook)
        {
            _scanables = new Dictionary<TSome, TSome> ();

            monoHook.AddActionToHook(OnTriggerEnter, MonoHooksWithParamEnum.OnTriggerEnter);
            monoHook.AddActionToHook(OnTriggerExit, MonoHooksWithParamEnum.OnTriggerExit);
        }

        public TSome[] Scan()
        {
            return _scanables.Values.ToArray();
        }
    }
}
