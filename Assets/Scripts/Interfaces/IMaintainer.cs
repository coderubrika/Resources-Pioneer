using UnityEngine;

namespace Assets.Scripts.Interfaces
{
    public interface IMaintainer
    {
        public Vector3 GetFreePoint();
        public void GiveBackToFreePoints(Vector3 point);
    }
}
