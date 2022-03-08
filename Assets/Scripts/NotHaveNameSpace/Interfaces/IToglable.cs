using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NotHaveNameSpace.Interfaces
{
    public interface IToglable
    {
        public void Toggle();

        public void Enable();

        public void Disable();

        public bool IsEnable();
    }
}
