using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    [ExecuteAlways]
    public class Platform : MonoBehaviour
    {
        [SerializeField] private Vector3Int _maxCountObj = Vector3Int.one;
        [SerializeField] private Vector3 _sizeObj;
        [SerializeField] private Vector3 _step;

        [SerializeField] private bool _showBlocksGizmo = false;
        [SerializeField] private bool _showBlockGizmo = false;
        [SerializeField] private bool _showStartGizmo = false;
        [SerializeField] private bool _showPlatformGizmo = true;
        
        [Min(0)]
        [SerializeField] private int _maxCount = 1;

        private Queue<Vector3> _freePoints;

        private void Awake()
        {
            _freePoints = new Queue<Vector3>(GetPoints());
        }

        public bool Put(Resource resource)
        {
            if (resource.transform.localScale != _sizeObj) return false;
            if (_freePoints.Count == 0) return false;

            resource.Grab(this);
            return true;

        }

        public bool HasFreePoints()
        {
            return _freePoints.Count > 0;
        }

        public Vector3 GetFreePoint()
        {
            return _freePoints.Dequeue();
        }

        public void GiveBackToFreePoints(Vector3 point)
        {
            _freePoints.Enqueue(point);
        }

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
                return transform.position;
            }
        }

        private Vector3[] GetPoints(bool full = false)
        {
            _maxCount = Mathf.Clamp(_maxCount, 0, _maxCountObj.x * _maxCountObj.y * _maxCountObj.z);
            int maxCount = full ? _maxCountObj.x * _maxCountObj.y * _maxCountObj.z : _maxCount;

            if (maxCount == 0) return new Vector3[0];

            Vector3[] centers = new Vector3[maxCount];

            int index = 0;

            for (int y = 1; y <= _maxCountObj.y; y++)
            {
                for (int z = 1; z <= _maxCountObj.z; z++)
                {
                    for (int x = 1; x <= _maxCountObj.x; x++)
                    {
                        float xDim = _startPoint.x + _sizeObj.x * x + _step.x * (x - 1) - _sizeObj.x / 2f;
                        float yDim = _startPoint.y + _sizeObj.y * y + _step.y * (y - 1) - _sizeObj.y / 2f;
                        float zDim = _startPoint.z - (_sizeObj.z * z + _step.z * (z - 1) - _sizeObj.z / 2f);

                        centers[index] = new Vector3(xDim, yDim, zDim);
                        index += 1;
                        if (index == maxCount) return centers;
                    }
                }
            }

            return centers;
        }

        private void OnTriggerEnter(Collider other)
        {
            
        }

        private void OnTriggerExit(Collider other)
        {

        }

        private void OnDrawGizmos()
        {
            Vector3 cubePosition = transform.position + _areaSize / 2f - Vector3.forward * _areaSize.z;

            if (_showBlockGizmo)
            {
                Gizmos.color = new Color(0, 1, 0, 0.3f);
                Gizmos.DrawCube(cubePosition, _areaSize);
            }
            
            if (_showPlatformGizmo)
            {
                Gizmos.color = new Color(0, 1, 1, 0.7f);
                Vector3 bottomScale = _areaSize;
                bottomScale.y = 0.01f;
                Vector3 bottomPosition = cubePosition;
                bottomPosition.y -= _areaSize.y / 2;
                Gizmos.DrawCube(bottomPosition, bottomScale);
            }

            if (_showStartGizmo)
            {
                Gizmos.color = new Color(1f, 1f, 0f, 0.9f);
                Gizmos.DrawCube(_startPoint, Vector3.one * 0.03f);
            }

            if (_showBlocksGizmo)
            {
                Vector3[] centers = GetPoints();

                foreach (Vector3 center in centers)
                {
                    Gizmos.color = new Color(0f, 0.8f, 0f, 1f);
                    Gizmos.DrawCube(center, _sizeObj);
                }
            }
        }
    }
}