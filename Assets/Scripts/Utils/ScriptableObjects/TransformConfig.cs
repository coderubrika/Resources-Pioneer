using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Configs/TransformConfig", fileName = "TransformConfig")]
    public class TransformConfig : ScriptableObject
    {
        public Vector3 Postion;
        public Vector3 LocalPostion;

        public Quaternion Rotation;
        public Quaternion LocalRotation;

        public Vector3 LocalScale;

        public Transform Transform
        {
            set
            {
                Postion = value.position;
                LocalPostion = value.localPosition;

                Rotation = value.rotation;
                LocalRotation = value.localRotation;

                LocalScale = value.localScale;
            }
        }
    }
}