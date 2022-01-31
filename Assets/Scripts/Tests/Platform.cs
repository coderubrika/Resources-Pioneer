using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Tests
{
    [ExecuteAlways]
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Vector3Int _maxCountObj = Vector3Int.one;
        [SerializeField] private Vector3 _sizeObj;
        [SerializeField] private Vector3 _step;

        private Vector3 _areaSize
        {
            get
            {
                Vector3 area = Vector3.zero;
                for (int i = 0; i < 3; i++)
                {
                    area[i] = _maxCountObj[i] * _sizeObj[i] + (_maxCountObj[i] - 1) * _step[i];
                }

                return area;
            }
        }
        private Vector3 _startPoint
        {
            get
            {
                return transform.position - _areaSize / 2 + Vector3.forward * _areaSize.z;
            }
        }

        // как написовать все кубики, ну чтобы это сделать, нужно получить все их центры и размеры,
        // с размерами легко, как получить центры

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0, 1, 0, 0.3f);
            Gizmos.DrawCube(transform.position, _areaSize);

            Gizmos.color = new Color(0, 1, 1, 0.7f);
            Vector3 bottomScale = _areaSize;
            bottomScale.y = 0.01f;
            Vector3 bottomPosition = transform.position;
            bottomPosition.y -= _areaSize.y / 2;
            Gizmos.DrawCube(bottomPosition, bottomScale);

            Gizmos.color = new Color(1f, 1f, 0f, 0.9f);
            Gizmos.DrawCube(_startPoint, Vector3.one * 0.03f);

            Vector3 start = transform.position - _areaSize / 2;

            Gizmos.color = new Color(1f, 0f, 0f, 0.8f);

            for (int x = 1; x <= _maxCountObj.x; x++)
            {
                for (int y = 1; y <= _maxCountObj.y; y++)
                {
                    for (int z = 1; z <= _maxCountObj.z; z++)
                    {
                        float xDim = start.x + _sizeObj.x * x + _step.x * (x - 1) - _sizeObj.x / 2f;
                        float yDim = start.y + _sizeObj.y * y + _step.y * (y - 1) - _sizeObj.y / 2f;
                        float zDim = start.z + _sizeObj.z * z + _step.z * (z - 1) - _sizeObj.z / 2f;

                        Vector3 center = new Vector3(xDim, yDim, zDim);

                        Gizmos.DrawCube(center, _sizeObj);
                    }
                }
            }


        }
    }
}