using Assets.Scripts.NotHaveNameSpace.Interfaces;

namespace Assets.Scripts.NotHaveNameSpace
{
    public class Stream<TSome>
    {
        private IRecivable<TSome> _recivable;

        public Stream(IRecivable<TSome> recivable)
        {
            _recivable = recivable;
        }

        public void Put(TSome some)
        {
            _recivable.Recive(some);
        }

    }
}
