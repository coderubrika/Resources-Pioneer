using Assets.Scripts.Utils.ScriptableObjects;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Utils
{
    [ExecuteAlways]
    public class CameraForEditor : MonoBehaviour
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private TransformConfig transformConfig;
        private Camera _selfCamera;

        private void Update()
        {
            if (Application.isEditor)
            {
                if (_camera != null)
                {
                    _selfCamera = GetComponent<Camera>();
                    if (_selfCamera == null)
                    {
                        _selfCamera = gameObject.AddComponent<Camera>();
                        _selfCamera.transform.position = transformConfig.Postion;
                        _selfCamera.transform.rotation = transformConfig.Rotation;

                        _selfCamera.fieldOfView = _camera.fieldOfView;
                        _selfCamera.farClipPlane = _camera.farClipPlane;
                        _selfCamera.nearClipPlane = _camera.nearClipPlane;
                        _selfCamera.depth = _camera.depth;
                        _selfCamera.orthographic = _camera.orthographic;
                        _selfCamera.pixelRect = _camera.pixelRect;
                        _selfCamera.orthographicSize = _camera.orthographicSize;
                    }
                    else if (!_selfCamera.enabled)
                    {
                        _selfCamera.enabled = true;
                    }
                }
                
            }

            if (Application.isPlaying)
            {
                if (_selfCamera != null && _selfCamera.enabled)
                {
                    _selfCamera.enabled = false;
                }
            }
        }

    }
}