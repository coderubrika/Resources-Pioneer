using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.NotHaveNameSpace.Interfaces
{
    public interface IRecivable<T>
    {
        public void Recive(T t);
    }
}
