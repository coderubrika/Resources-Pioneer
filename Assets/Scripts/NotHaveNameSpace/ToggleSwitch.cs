using Assets.Scripts.NotHaveNameSpace.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NotHaveNameSpace
{
    public class ToggleSwitch : IToglable
    {
        private bool _enabled;

        public ToggleSwitch(bool startState = false)
        {
            _enabled = startState;
        }

        public void Disable()
        {
            _enabled = false;
        }

        public void Enable()
        {
            _enabled = true;
        }

        public bool IsEnable()
        {
            return _enabled;
        }

        public void Toggle()
        {
            _enabled = !_enabled;
        }
    }
}
